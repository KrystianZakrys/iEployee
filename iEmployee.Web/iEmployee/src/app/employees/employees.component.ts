import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';
import { Location } from '@angular/common'
import { EmployeeService }  from '../employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'sex', 'addressCountry', 'addressCity','addressStreet','actions'];
  dataSource: Employee[];
  filteringOpen = false;
  
  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void{
    this.employeeService.getEmployees().subscribe(x => this.dataSource = x);
  }
}
