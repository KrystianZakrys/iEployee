import { Routes } from '@angular/router';


import { EmployeesComponent  } from './employees/employees.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import {EmployeeProjectsComponent  } from './employee-projects/employee-projects.component';
import { EmployeeAddComponent } from './employee-add/employee-add.component';
import { EmployeeResolver } from './employee-resolver';

export const employeeRoutes: Routes = [
    {
        path: '', children: [
            {path: 'employees', component: EmployeesComponent},
            {path: 'employee/details/:id', component: EmployeeDetailsComponent, resolve: {employee: EmployeeResolver}},
            {path: 'employee/projects/:id', component: EmployeeProjectsComponent},
            {path: 'employee/add', component: EmployeeAddComponent},
        ]
    },
];
