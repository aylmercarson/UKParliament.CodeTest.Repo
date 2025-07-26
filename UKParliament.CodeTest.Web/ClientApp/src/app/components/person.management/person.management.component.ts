import { ChangeDetectionStrategy, Component, OnInit, inject } from "@angular/core";
import { PersonStore } from "src/app/stores/person.store";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatDatepickerModule} from '@angular/material/datepicker';
import { DepartmentStore } from "src/app/stores/department.store";
import { DatePipe } from "@angular/common";
import { PersonService } from "src/app/services/person.service";
import { PersonViewModel } from "src/app/models/person-view-model";
import { NotificationService } from "src/app/services/notification.service";
import { DeleteconfirmationdialogComponent } from "src/app/dialogs/deleteconfirmationdialog/deleteconfirmationdialog.component";
import { MatLuxonDateModule } from "@angular/material-luxon-adapter";

@Component({
  selector: 'app-users',
  templateUrl: './person.management.component.html',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  styles         : [
        /* language=SCSS */
        `
            .person-grid {
                grid-template-columns: auto;

                @screen sm {
                    grid-template-columns: 48px auto 112px 72px;
                }

                @screen md {
                    grid-template-columns: auto auto auto 72px;
                }

                @screen lg {
                    grid-template-columns: 10% 10% 10% 16% 16% 10% 2% 2%;
                }
            }
        `,
    ],
    imports: [DatePipe, FormsModule, MatLuxonDateModule, MatDatepickerModule, ReactiveFormsModule, MatFormFieldModule, MatIconModule, MatInputModule, MatSelectModule, MatButtonModule],
})
export class PersonManagementComponent implements OnInit
{
    personStore = inject(PersonStore);
    personService = inject(PersonService);
    departmentStore = inject(DepartmentStore);
    notificationService = inject(NotificationService);
    readonly dialog = inject(MatDialog);
    selectedPersonId: string = '';
    form!: FormGroup;

    isLoading: boolean = false;

    ngOnInit(): void
    {
      this.buildForm();
    }

    deletePerson(personId: string, name: string): void
    {
      // Open the confirmation dialog
      const dialogConfig = new MatDialogConfig();

      // Configure the dialog options
      dialogConfig.disableClose = true; // Prevents closing the dialog by clicking outside
      dialogConfig.autoFocus = false;   // Disable autofocus to manually control focus
      dialogConfig.width = '30%';       // Set the width of the dialog
      dialogConfig.data = { name: name }; // Pass data to the dialog component
      const dialogRef = this.dialog.open(DeleteconfirmationdialogComponent, dialogConfig)
      .afterClosed()
      .subscribe((confirm: boolean) => {
          if (confirm) {
            this.personService.deletePerson(personId)
            .subscribe({  
              next: (x) => {
                this.personStore.loadUsers();
                this.form.reset();
                this.notificationService.showNotification("Person deleted.", "Close", 'success-snackbar');
              },  
              error: (err) => {
                this.notificationService.showNotification("Error deleting person.", "Close", 'error-snackbar');
              },
              complete: () =>
              {
                this.selectedPersonId = '';
              }
          });
        }
        else{
          this.form.reset();
          this.selectedPersonId = '';
        }
    });
  }
  
  onSubmit(): void{
    let person:PersonViewModel = this.form.value;

    if(this.selectedPersonId == ''){
      this.addPerson(person);
    }
    else{
      this.updatePerson(person);
    }

    this.selectedPersonId = '';
}

  addPerson(person:PersonViewModel){
    this.personService.addPerson(person)
    .subscribe({  
        next: (x) => {
          this.personStore.loadUsers();
          this.form.reset();
          this.notificationService.showNotification("Person added.", "Close", 'success-snackbar');
        },  
        error: (err) => {
          console.log(err.error);
          this.notificationService.showNotification(err.error, "Close", 'error-snackbar');
        }
    });
  }
    
  updatePerson(person:PersonViewModel){
    person.id = this.selectedPersonId;
    this.personService.updatePerson(person)
    .subscribe({  
        next: (x) => {
          this.personStore.loadUsers();
          this.form.reset();
          this.notificationService.showNotification("Person updated.", "Close", 'success-snackbar');
        },  
        error: (err) => {
          console.log(err);
            this.notificationService.showNotification("Error updating person details.", "Close", 'error-snackbar');
        }
    });
  }

  selectPerson(personId: string){
      this.selectedPersonId = personId;
       this.personService.getPersonById(personId)
          .subscribe({  
          next: (person) => {
            this.form.patchValue(person);
          },  
          error: (err) => {
            console.log(err);
              this.notificationService.showNotification("Error retrieving person details.", "Close", 'error-snackbar');
          }
      });
    }

  cancel(): void{
    this.selectedPersonId = '';
    this.form.reset();
  }

  buildForm(): void{
    this.form =  new FormGroup({
        firstName    : new FormControl('',[
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(20)
          ]),
        lastName   : new FormControl('',[
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(20)
          ]),
        email   : new FormControl('',[
            Validators.required,
            Validators.maxLength(35),
            Validators.email
          ]),
        dateOfBirth   : new FormControl('',[
            Validators.required
          ]),
        mobile : new FormControl('',[
            Validators.required,
            Validators.minLength(10),
            Validators.maxLength(15)
        ]),
        department : new FormControl('',[
            Validators.required
        ]),
    });
  }
}



