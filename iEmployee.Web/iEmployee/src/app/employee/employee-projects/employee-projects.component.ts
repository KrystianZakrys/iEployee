import { Component, OnInit } from '@angular/core';
import { Employee } from '../../employee';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';

@Component({
  selector: 'app-employee-projects',
  templateUrl: './employee-projects.component.html',
  styleUrls: ['./employee-projects.component.css']
})
export class EmployeeProjectsComponent implements OnInit {
  employee: Employee;

  constructor(private employeeService: EmployeeService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    this.getEmployee();
  }
  goBack(): void{
    this.location.back();
  }

  getEmployee(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployee(id).subscribe(x => {this.employee = x;});
  }
}
