import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';
import { EMPLOYEES } from '../employeesMock';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {

  
  employee: Employee;

  constructor(private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
  }

  goBack(): void{
    this.location.back();
  }

  submit(): void{
    this.location.back();
  }
}
