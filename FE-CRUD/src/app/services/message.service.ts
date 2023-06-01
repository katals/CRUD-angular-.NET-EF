import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  constructor(private snackBar: MatSnackBar) {}

  successMessage(action: string) {
    this.snackBar.open(`The pet was ${action} succesfully`, '', {
      duration: 4000,
      horizontalPosition: 'center',
    });
  }

  errorMessage(action: string) {
    this.snackBar.open(
      `The pet had an error trying to ${action} the pet `,
      '',
      {
        duration: 4000,
        horizontalPosition: 'center',
      }
    );
  }
}
