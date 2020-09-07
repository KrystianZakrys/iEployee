import { Component, OnInit, Input } from '@angular/core';
import { Employee, Address } from '../employee';

import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../employee.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
  providers: [DatePipe]
})
export class EmployeeAddComponent implements OnInit {

  @Input() employee: Employee;

  constructor(private employeeService: EmployeeService, private route: ActivatedRoute
    , private location: Location, private datePipe: DatePipe) { }

  ngOnInit(): void {
  }

  goBack(): void{
    this.location.back();
  }

  submit(firstName: string, lastName: string, sex: number, birthDate: Date, addressCountry: string, addressCity: string, addressStreet: string, addressZipCode: string): void{
    const address: Address = {Country: addressCountry, City: addressCity, Street:addressStreet, ZipCode:  addressZipCode};
    this.employee = {FirstName: firstName, LastName: lastName,Sex: sex, BirthDate: this.datePipe.transform(birthDate,'yyyy-MM-dd'),Address: address};   
    this.employeeService.addEmployee(this.employee).subscribe(x => this.location.back());
  }
}
