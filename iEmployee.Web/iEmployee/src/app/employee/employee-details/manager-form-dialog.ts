import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Manager } from 'src/app/manager';
import { ManagerService } from 'src/app/manager.service';
import { ToasterService } from 'angular2-toaster';

@Component({
    selector: 'manager-form-dialog',
    templateUrl: 'manager-form-dialog.html',
})
export class ManagerFormDialog{
    roomNumber: FormControl;

    constructor(public dialogRef: MatDialogRef<ManagerFormDialog>,
        private managerService: ManagerService,
        private toasterService: ToasterService)
    {
        this.roomNumber = new FormControl('');
        this.roomNumber.valueChanges.subscribe(x => {
            console.log(x);
        })
    }       

    ngOnInit() {    
        this.roomNumber = new FormControl('');
    }

    submit(): void{
        this.managerService.addManager(this.roomNumber.value as Manager).subscribe(x =>{
            this.toastMessage(x, "Successfully added manager.");
            this.dialogRef.close();
        });        
    }

    close(): void{
        this.dialogRef.close();
    }

      
  /**
   * Toasts message
   * @param x 
   * @param bodySuccess 
   */
  toastMessage(x: boolean, bodySuccess: string): void{
    if(x)
    {
      this.toasterService.pop('success','Success',bodySuccess);
    }
    else
    {
      this.toasterService.pop('error','Error','Something went wrong.');
    }
    }
}