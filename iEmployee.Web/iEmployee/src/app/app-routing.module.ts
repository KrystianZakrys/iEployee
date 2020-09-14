import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employee/employees/employees.component';
import { EmployeeDetailsComponent } from './employee/employee-details/employee-details.component';
import { ProjectsComponent } from './project/projects/projects.component';
import { EmployeeProjectsComponent } from './employee/employee-projects/employee-projects.component';
import { EmployeeAddComponent } from './employee/employee-add/employee-add.component';
import { ProjectDetailsComponent } from './project/project-details/project-details.component';
import { ProjectAddComponent } from './project/project-add/project-add.component';

const routes: Routes = [
  {path: '', redirectTo: '/employees', pathMatch: 'full'},
  {path:'project', loadChildren: () => import('./project/project.module').then(m => m.ProjectModule)},
  {path:'employee',loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
