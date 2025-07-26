import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DeleteconfirmationdialogComponent } from './deleteconfirmationdialog.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

describe('DeleteconfirmationdialogComponent', () => {
  
  let component: DeleteconfirmationdialogComponent;
  let fixture: ComponentFixture<DeleteconfirmationdialogComponent>;

  const mockDialogRef = {
    close: jasmine.createSpy('close'),
    confirm: jasmine.createSpy('confirm'),
  };

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        { provide: MatDialogRef, useValue: mockDialogRef }, 
        { provide: MAT_DIALOG_DATA, useValue: mockDialogRef }
      ]
    })
    .compileComponents();
});

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteconfirmationdialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('#onNoClick should close the dialog', () => {
    component.onNoClick();
    expect(mockDialogRef.close).toHaveBeenCalled();
  });

    it('#onYesClick should close the dialog', () => {
    component.onYesClick();
    expect(mockDialogRef.close).toHaveBeenCalled();
  });
});
