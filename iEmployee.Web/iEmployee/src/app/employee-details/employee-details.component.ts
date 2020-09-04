import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';
import { EMPLOYEES } from '../employeesMock';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  employee: Employee;

  constructor(private route: ActivatedRoute, private location: Location, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployee();
  }


  getEmployee(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id).subscribe(x => this.employee = x);
  }

  goBack(): void{
    this.location.back();
  }

  assignToProject(): void{
    console.log(this.employee.firstName + ' '+ this.employee.lastName + ' assigned to project');
  }

  unassignProject(id): void{
    console.log(this.employee.firstName + ' '+ this.employee.lastName + ' unassigned from project')
  }
}
