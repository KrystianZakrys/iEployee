import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../project.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Employee } from 'src/app/employee';
import { EmployeeService } from 'src/app/employee.service';
@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css']
})
export class ProjectDetailsComponent implements OnInit {
  project: Project;
  employees: Employee[];

  constructor(private projectService: ProjectService,
    private employeeService: EmployeeService,
    private route: ActivatedRoute, 
    private location: Location) { }

  ngOnInit(): void {
    this.getProject();

  }

  getProject(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.projectService.getProject(id).subscribe(x => {
      this.project = x; 
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

  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(id, this.project.id)
    .subscribe(x => { 
      this.getEmployees(this.project.id);
    });
  }
}
