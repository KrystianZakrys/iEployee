import { Component, OnInit, Input } from '@angular/core';
import { Employee, Address } from '../../employee';

import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../employee.service';
import { FormControl } from '@angular/forms';
import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'
import { Project } from '../../project';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
  providers: [DatePipe]
})
export class EmployeeAddComponent implements OnInit {
  positions: Position[];
  projects: Project[];
  @Input() employee: Employee;

  constructor(private employeeService: EmployeeService, 
    private route: ActivatedRoute,
     private location: Location, 
     private datePipe: DatePipe,
     private positionService: PositionService,
     private projectService: ProjectService) { }

  ngOnInit(): void {
  }

  goBack(): void{
    this.location.back();
  }
  getPositionsDictionary(): void{
    this.positionService.getPositions().subscribe(x => {this.positions = x;});
  }
  getProjectsDictionary(): void{
    this.projectService.getProjects().subscribe(x => {this.projects = x}); 
  }

  submit(firstName: string, lastName: string, sex: number, birthDate: Date, addressCountry: string, addressCity: string, addressStreet: string, addressZipCode: string): void{
    const address: Address = {country: addressCountry, city: addressCity, street:addressStreet, zipCode:  addressZipCode};
    this.employee = {firstName: firstName, lastName: lastName,sex: sex, birthDate: this.datePipe.transform(birthDate,'yyyy-MM-dd'),address: address,managerName:"",position:null};   
    this.employeeService.addEmployee(this.employee).subscribe(x => this.location.back());
  }
}
