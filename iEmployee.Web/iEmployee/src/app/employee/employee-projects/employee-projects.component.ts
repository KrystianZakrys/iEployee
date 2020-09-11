import { Component, OnInit } from '@angular/core';
import { Employee } from '../../employee';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { Project } from 'src/app/project';
import { FormControl } from '@angular/forms';
import { ProjectService } from 'src/app/project.service';

@Component({
  selector: 'app-employee-projects',
  templateUrl: './employee-projects.component.html',
  styleUrls: ['./employee-projects.component.css']
})
export class EmployeeProjectsComponent implements OnInit {
  employee: Employee;
  projects: Project[];
  projectsDictionary: Project[];
  project: FormControl;
  
  constructor(private employeeService: EmployeeService, 
    private projectService: ProjectService,
    private route: ActivatedRoute, 
    private location: Location) { }

  ngOnInit(): void {
    this.getEmployee();
    this.project = new FormControl('');
  }
  goBack(): void{
    this.location.back();
  }

  getEmployee(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id).subscribe(x => {
      this.employee = x;
      this.getEmployeeProjects(x.id);
      this.getProjectsDictionary(x.id);
    });
  }

  getEmployeeProjects(id: string): void{
    this.employeeService.getEmployeeProjects(id).subscribe(x =>{
        this.projects = x;
    });
  }

  assignToProject(): void{
    this.employeeService.assignToProject(this.employee.id, this.project.value)
    .subscribe(x => {
       this.getEmployeeProjects(this.employee.id);
       this.getProjectsDictionary(this.employee.id);
      });
  }

  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(this.employee.id, id)
    .subscribe(x => { 
      this.getEmployeeProjects(this.employee.id);
      this.getProjectsDictionary(this.employee.id);
    });
  }

  getProjectsDictionary(id: string): void{
    this.projectService.getNotAssignedProjects(id).subscribe(x => {this.projectsDictionary = x;}); 
  }
}
