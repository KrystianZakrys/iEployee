import { Component, OnInit } from '@angular/core';
import { Employee, Position } from '../../employee';
import { Location, DatePipe } from '@angular/common'
import { EmployeeService }  from '../../employee.service';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { Project } from '../../project';
import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers: [DatePipe]
})
export class EmployeesComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName','position', 'addressCountry', 'addressCity','addressStreet','managerName','actions'];
  dataSource: Employee[];
  filteringOpen = false;
  filteringMessage = false;

  positions: Position[];
  projects: Project[];

  filterForm: FormGroup;

  constructor(private employeeService: EmployeeService,
    private projectService: ProjectService,
    private positionService: PositionService,
    private formBuilder: FormBuilder,
    private datePipe: DatePipe,
    private location: Location) { }

  ngOnInit(): void {
    this.filterForm = this.formBuilder.group({
      firstName:[''],
      lastName:[''],
      minBirthDate: [''],
      maxBirthDate: [''],
      position: [''],
      project: ['']
    });

    this.getEmployees();
    this.getPositionsDictionary();
    this.getProjectsDictionary();
  }
 
  getPositionsDictionary(): void{
    this.positionService.getPositions().subscribe(x => {this.positions = x;});
  }
  getProjectsDictionary(): void{
    this.projectService.getProjects().subscribe(x => {this.projects = x}); 
  }

  getEmployees(): void{
    this.employeeService.getEmployees().subscribe(x => {this.dataSource = x;});
  }

  filterEmployees(): void{
    const query = this.buildFilterQuery();
    this.employeeService.filterEmployees(query).subscribe(x => {this.dataSource = x;});
  }


  clearFilters(): void{
    this.filterForm.reset();
    this.filterEmployees();
  }
  private buildFilterQuery(): string{
    var query = "?";
    if(this.filterForm.get('firstName').value) query = query.concat(`FirstName=${this.filterForm.get('firstName').value}&`);
    if(this.filterForm.get('lastName').value) query = query.concat(`LastName=${this.filterForm.get('lastName').value}&`);
    if(this.filterForm.get('minBirthDate').value) query = query.concat(`MinBirthDate=${this.datePipe.transform(this.filterForm.get('minBirthDate').value,'yyyy-MM-dd')}&`);
    if(this.filterForm.get('maxBirthDate').value) query = query.concat(`MaxBirthDate=${this.datePipe.transform(this.filterForm.get('maxBirthDate').value,'yyyy-MM-dd')}&`);
    if(this.filterForm.get('position').value) query = query.concat(`PositionId=${this.filterForm.get('position').value}&`);
    if(this.filterForm.get('project').value) query = query.concat(`ProjectId=${this.filterForm.get('project').value}&`);
  
    return query;
  }
}
