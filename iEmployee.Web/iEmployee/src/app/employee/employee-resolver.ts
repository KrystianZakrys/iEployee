import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Employee  } from '../employee';
import { EmployeeService } from '../employee.service';

@Injectable()
export class EmployeeResolver implements Resolve<Employee>{
    constructor(private employeeService: EmployeeService){}

    resolve(route: ActivatedRouteSnapshot): Employee | Observable<Employee> | Promise<Employee> {
        return this.employeeService.getEmployee(route.params['id']);
    }

}