import { Component, OnInit } from '@angular/core';
import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl } from '@angular/forms';

import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'
import { Project } from '../../project';
import { EmployeeService } from '../../employee.service';
import { Employee, JobHistory } from '../../employee';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
  providers: [DatePipe]
})
export class EmployeeDetailsComponent implements OnInit {
  positions: Position[];
  projects: Project[];
  employee: Employee;

  employeeForm: FormGroup;
  zipCodePattern = "^[0-9]{2}(-[0-9]{3})?$";
  project: FormControl;

  employeeProjects: Project[];

  constructor(private route: ActivatedRoute,
     private location: Location,
      private employeeService: EmployeeService,
      private datePipe: DatePipe,
      private positionService: PositionService,
      private projectService: ProjectService,
      private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getEmployee();
  }

  buildForm(): void{
    this.employeeForm = this.formBuilder.group({
      id:[''],
      managerName:[''],
      position: [this.employee.position != null? this.employee.position?.id:'Select position... '],
      projects:[''],
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

    this.project = new FormControl('');
  }

  getPositionsDictionary(id: string): void{
    this.positionService.getNotAssignedPositions(id).subscribe(x => {this.positions = x;});
  }
  getProjectsDictionary(id: string): void{
    this.projectService.getNotAssignedProjects(id).subscribe(x => {this.projects = x}); 
  }

  getEmployee(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id).subscribe(x => {this.employee = x; 
      this.getEmployeeProjects();
      this.getPositionsDictionary(id);
      this.getProjectsDictionary(id);
      this.buildForm();
      (<FormGroup>this.employeeForm)
      .setValue(this.employee, {onlySelf: true});});
  }

  getEmployeeProjects(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployeeProjects(id).subscribe(x => {this.employeeProjects = x});
  }

  goBack(): void{
    this.location.back();
  }

  deleteEmployee(): void{
    this.employeeService.deleteEmployee(this.employee.id).subscribe(x => this.goBack());
  }
  
  updateEmployee(): void{
    if(this.employeeForm.valid)
      this.employeeService.updateEmployee(this.employeeForm.getRawValue(), this.employee.id).subscribe();
  }

  makeManager(): void{
    console.warn('Method not implemented');
  }

  changePosition(): void{
    var jobHistoryEntry : JobHistory = {employeeId: this.employee.id, positionId:this.employeeForm.get("position").value,salary: 1500};
    this.employeeService.changePosition(this.employee.id, jobHistoryEntry)
    .subscribe(x => {
      this.getPositionsDictionary(this.employee.id);
    });
 
  }
  assignToProject(): void{
    this.employeeService.assignToProject(this.employee.id, this.project.value)
    .subscribe(x => {
       this.getEmployeeProjects();
       this.getProjectsDictionary(this.employee.id);
      });
  }

  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(this.employee.id, id)
    .subscribe(x => { 
      this.getEmployeeProjects();
      this.getProjectsDictionary(this.employee.id);
    });
  }

}