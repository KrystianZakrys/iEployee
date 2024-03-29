import { Component, OnInit, Input } from '@angular/core';
import { Employee, Address, Position } from '../../employee';

import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'
import { Project } from '../../project';
import { ToasterService } from 'angular2-toaster';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
  providers: [DatePipe]
})
export class EmployeeAddComponent implements OnInit {
  positions: Position[];
  projects: Project[];

  employeeForm: FormGroup;
  zipCodePattern = "^[0-9]{2}(-[0-9]{3})?$";
  employee: Employee;

  constructor(private employeeService: EmployeeService, 
    private route: ActivatedRoute,
     private location: Location, 
     private datePipe: DatePipe,
     private positionService: PositionService,
     private projectService: ProjectService,
     private formBuilder: FormBuilder,
     private toasterService: ToasterService) { }

  ngOnInit(): void {
    this.getPositionsDictionary();
    this.buildForm();
  }
  buildForm(): void{
    this.employeeForm = this.formBuilder.group({
      firstName:['', [Validators.required, Validators.maxLength(25)]],
      lastName:['', [Validators.required, Validators.maxLength(25)]],
      birthDate: [''],
      sex:[''],
      address: this.formBuilder.group({
        country:['', Validators.required],
        city:['', Validators.required],
        street:['', Validators.required],
        zipCode:['', [Validators.required, Validators.pattern(this.zipCodePattern)]]
      })
    });


  }

    
  toastMessage(x: boolean, bodySuccess: string): void{
    if(x)
    {
      this.toasterService.pop('success','Success',bodySuccess);
    }
    else{
      this.toasterService.pop('error','Error','Something went wrong.');
    }
  }
  goBack(): void{
    this.location.back();
  }
  getPositionsDictionary(): void{
    this.positionService.getPositions().subscribe(x => {this.positions = x;});
  }

  submit(): void{ 
    if(this.employeeForm.valid)
      this.employeeService.addEmployee(this.employeeForm.getRawValue()).subscribe(x => {
        this.toastMessage(x, 'Successfully added employee.')
        this.location.back()});
  }
}
