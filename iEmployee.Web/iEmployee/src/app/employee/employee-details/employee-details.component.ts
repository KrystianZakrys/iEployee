import { Component, OnInit } from '@angular/core';
import { Employee, JobHistory } from '../../employee';
import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'
import { Project } from '../../project';

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

  constructor(private route: ActivatedRoute,
     private location: Location,
      private employeeService: EmployeeService,
      private datePipe: DatePipe,
      private positionService: PositionService,
      private projectService: ProjectService,
      private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getPositionsDictionary();
    this.getProjectsDictionary();
    this.employeeForm = this.formBuilder.group({
      id:'',
      managerName:'',
      position:'',
      firstName:'',
      lastName:'',
      birthDate: '',
      sex:'',
      address: this.formBuilder.group({
        country:'',
        city:'',
        street:'',
        zipCode:''
      }),
      project: ''
    });

    this.getEmployee();
  }

  getPositionsDictionary(): void{
    this.positionService.getPositions().subscribe(x => {this.positions = x;});
  }
  getProjectsDictionary(): void{
    this.projectService.getProjects().subscribe(x => {this.projects = x}); 
  }

  getEmployee(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id).subscribe(x => {this.employee = x; (<FormGroup>this.employeeForm)
      .setValue(this.employee, {onlySelf: false});});
  }

  goBack(): void{
    this.location.back();
  }

  deleteEmployee(): void{
    this.employeeService.deleteEmployee(this.employee.id).subscribe(x => this.goBack());
  }
  
  updateEmployee(): void{
    this.employeeService.updateEmployee(this.employeeForm.getRawValue(), this.employee.id).subscribe(x => console.log(x));
  }
  changePosition(): void{
    var jobHistoryEntry : JobHistory = {employeeId: this.employee.id, positionId:this.employeeForm.get("position").value,salary: 1500};
    this.employeeService.changePosition(this.employee.id, jobHistoryEntry).subscribe();
  }
  assignToProject(): void{
    this.employeeService.assignToProject(this.employee.id, this.employeeForm.get("project").value,).subscribe();
  }

  unassignProject(id): void{
    //console.log(this.employee.FirstName + ' '+ this.employee.LastName + ' unassigned from project')
  }
}
