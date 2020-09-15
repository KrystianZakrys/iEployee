import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../project.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/employee';
import { EmployeeService } from 'src/app/employee.service';
import { FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';
import { ToasterService } from 'angular2-toaster';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css']
})
export class ProjectDetailsComponent implements OnInit {
  project: Project;
  employees: Employee[];
  projectName: FormControl;

  constructor(private projectService: ProjectService,
    private employeeService: EmployeeService,
    private route: ActivatedRoute, 
    private location: Location,
    private toasterService: ToasterService) { }

  ngOnInit(): void {
    this.project = this.route.snapshot.data['project'];
    this.buildForm();
    this.getEmployeesForProject(this.project.id);
  }

  buildForm(): void{
    this.projectName = new FormControl('');
    this.projectName.setValidators(Validators.required);
    this.projectName.setValue(this.project.name);
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

  getEmployeesForProject(id: string): void{
    this.projectService.getProjectEmployees(id).subscribe(x => {
      this.employees = x;
    });
  }

  updateProject(): void{
    if(this.projectName.valid){
      this.project.name = this.projectName.value;
      this.projectService.updateProject(this.project.id, this.project).subscribe(x =>{
        this.toastMessage(x, 'Updating project completed.')
      });
    }      
  }

  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(id, this.project.id)
    .subscribe(x => { 
      this.getEmployeesForProject(this.project.id);
    });
  }

  deleteProject(): void{
    this.projectService.deleteProject(this.project.id).subscribe(x =>{
      this.toastMessage(x, 'Deleting project completed.');
      this.goBack();
    });
  }
}
