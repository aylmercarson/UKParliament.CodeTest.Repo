import { inject, Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';  // Importing Material Snackbar

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private _snackBar = inject(MatSnackBar);
  private config!: MatSnackBarConfig;


  constructor() {}

  showNotification(message: string, action: string = 'Close', style:string) {

    this.config = {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
      panelClass: style
    }

    this._snackBar.open(message, 'Close', this.config );
  }
}