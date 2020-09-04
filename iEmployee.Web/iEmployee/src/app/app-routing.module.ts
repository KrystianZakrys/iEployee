import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { ProjectsComponent } from './projects/projects.component';
import { EmployeeProjectsComponent } from './employee-projects/employee-projects.component';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import { ProjectAddComponent } from './project-add/project-add.component';

const routes: Routes = [
  {path: '', redirectTo: '/employees', pathMatch: 'full'},
  {path: 'employees', component: EmployeesComponent},
  {path: 'employee/details/:id', component: EmployeeDetailsComponent},
  {path: 'projects', component: ProjectsComponent},
  {path: 'employee/projects/:id', component: EmployeeProjectsComponent},
  {path: 'employee/add', component: EmployeeAddComponent},
  {path: 'projects/details/:id', component: ProjectDetailsComponent},
  {path: 'projects/add', component: ProjectAddComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
