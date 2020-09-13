import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../project.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/employee';
import { EmployeeService } from 'src/app/employee.service';
import { FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { ThrowStmt } from '@angular/compiler';

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
    private location: Location) { }

  ngOnInit(): void {
    this.getProject();
    this.projectName = new FormControl('');
    this.projectName.setValidators(Validators.required);
  }

  getProject(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.projectService.getProject(id).subscribe(x => {
      this.project = x; 
      this.projectName.setValue(x.name);
      this.getEmployees(x.id);
    });
  }

  getEmployees(id: string): void{
    this.projectService.getProjectEmployees(id).subscribe(x => {
      this.employees = x;
    });
  }

  goBack(): void{
    this.location.back();
  }

  updateProject(): void{
    if(this.projectName.valid){
      this.project.name = this.projectName.value;
      this.projectService.updateProject(this.project.id, this.project).subscribe(x =>{});
    }      
  }

  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(id, this.project.id)
    .subscribe(x => { 
      this.getEmployees(this.project.id);
    });
  }

  deleteProject(): void{
    this.projectService.deleteProject(this.project.id).subscribe(x =>{this.goBack()});
  }
}
