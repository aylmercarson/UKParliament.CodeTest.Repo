import { Dialog } from '@angular/cdk/dialog';
import { Component, Inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-deleteconfirmationdialog',
  standalone: true,
  imports: [MatButtonModule, MatIconModule],
  templateUrl: './deleteconfirmationdialog.component.html'
})
export class DeleteconfirmationdialogComponent {
  //dialogRef = inject(MatDialogRef<DeleteconfirmationdialogComponent>);
  // data = inject<{
  //   name: string;
  // }>(MAT_DIALOG_DATA);

  constructor(
  public dialogRef: MatDialogRef<DeleteconfirmationdialogComponent>,
  @Inject(MAT_DIALOG_DATA) public data: Dialog | any
){}

 onNoClick(): void {
    this.dialogRef.close(false);
  }
  onYesClick(): void {
    this.dialogRef.close(true);
  }
}
