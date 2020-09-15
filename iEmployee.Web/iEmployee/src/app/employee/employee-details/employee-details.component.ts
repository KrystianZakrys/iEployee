import { Component, OnInit } from '@angular/core';
import { Location, DatePipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl, Form } from '@angular/forms';

import { ProjectService } from 'src/app/project.service';
import { PositionService } from '../../position.service'
import { Project } from '../../project';
import { ManagerService } from '../../manager.service';
import { EmployeeService } from '../../employee.service';
import { Employee, JobHistory, Position} from '../../employee';
import { _CoalescedStyleScheduler } from '@angular/cdk/table';
import { ToasterService } from 'angular2-toaster';
import { MatDialog } from '@angular/material/dialog';
import { ManagerFormDialog } from './manager-form-dialog';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
  providers: [DatePipe]
})
export class EmployeeDetailsComponent implements OnInit {
  positions: Position[];
  projects: Project[];
  employee: Employee;

  employeeForm: FormGroup;

  zipCodePattern = "^[0-9]{2}(-[0-9]{3})?$";
  project: FormControl;
  managerFormDialog: ManagerFormDialog;
  managerRoomNumber: FormControl;

  employeeProjects: Project[];

  constructor(private route: ActivatedRoute,
     private location: Location,
      private employeeService: EmployeeService,
      private datePipe: DatePipe,
      private positionService: PositionService,
      private projectService: ProjectService,
      private managerService: ManagerService,
      private formBuilder: FormBuilder,
      private toasterService: ToasterService,
      public dialog: MatDialog) { }

  ngOnInit(): void {
    this.employee = this.route.snapshot.data['employee'];
    this.getEmployeeProjects();
    this.getDictionaries();
    this.buildForm();    
  }

  /**
   * Builds form
   */
  buildForm(): void{

    this.employeeForm = this.formBuilder.group({
      id:[''],
      managerName:[''],      
      projects:[''],
      firstName:['', [Validators.required, Validators.maxLength(25)]],
      lastName:['', [Validators.required, Validators.maxLength(25)]],
      birthDate: [''],
      sex:[''],
      address: this.formBuilder.group({
        country:['', Validators.required],
        city:['', Validators.required],
        street:['', Validators.required],
        zipCode:['', [Validators.required, Validators.pattern(this.zipCodePattern)]]
      }),
      position: this.formBuilder.group({
        id: [''],
        code:[''],
        salary:[''],
        startDate:[''],
        endDate:[''],
        name:['']
      })
    });

    this.project = new FormControl('');
    this.project.setValidators(Validators.required);

 

    (<FormGroup>this.employeeForm)
    .patchValue(this.employee, {onlySelf: true});
  }

   /**
    * Gets dictionaries
    */
   getDictionaries(): void{
    this.getPositionsDictionary(this.employee.id);
    this.getProjectsDictionary(this.employee.id);
   }

  /**
   * Go back
   */
  goBack(): void{
    this.location.back();
  }
  
  /**
   * Toasts message
   * @param x 
   * @param bodySuccess 
   */
  toastMessage(x: boolean, bodySuccess: string): void{
    if(x)
    {
      this.toasterService.pop('success','Success',bodySuccess);
    }
    else{
      this.toasterService.pop('error','Error','Something went wrong.');
    }
  }

  openManagerForm(): void{
    this.managerFormDialog = this.dialog.open(ManagerFormDialog, {
      width: '250px'
    });
  }

  /**
   * Gets positions dictionary
   * @param id 
   */
  getPositionsDictionary(id: string): void{
    this.positionService.getNotAssignedPositions(id).subscribe(x => {this.positions = x;});
  }

  /**
   * Gets projects dictionary
   * @param id 
   */
  getProjectsDictionary(id: string): void{
    this.projectService.getNotAssignedProjects(id).subscribe(x => {this.projects = x}); 
  }


  /**
   * Gets employee projects
   */
  getEmployeeProjects(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.employeeService.getEmployeeProjects(id).subscribe(x => {this.employeeProjects = x});
  }


  /**
   * Deletes employee
   */
  deleteEmployee(): void{
    this.employeeService.deleteEmployee(this.employee.id).subscribe(x => {
      this.toastMessage(x,'Deleting employee completed.');
      this.goBack();
    });
  }

  /**
   * Updates employee
   */
  updateEmployee(): void{
    if(this.employeeForm.valid)
      this.employeeService.updateEmployee(this.employeeForm.getRawValue(), this.employee.id).subscribe(x =>{
        this.toastMessage(x,'Updating employee completed.');
      });
  }

  /**
   * Makes manager
   */
  makeManager(): void{
    console.warn('Method not implemented');
  }

  /**
   * Changes position
   */
  changePosition(): void{
    var position = this.employeeForm.getRawValue().position;
    var jobHistoryEntry : JobHistory = {
        employeeId: this.employee.id,
        positionId: position.id,
        salary: position.salary,
        startDate: position.startDate,
        endDate: position.endDate
      };
    this.employeeService.changePosition(this.employee.id, jobHistoryEntry)
    .subscribe(x => {
      this.toastMessage(x,"Employee's position changed.");
      this.getPositionsDictionary(this.employee.id);
    });
 
  }

  /**
   * Assigns to project
   */
  assignToProject(): void{
    this.employeeService.assignToProject(this.employee.id, this.project.value)
    .subscribe(x => {
       this.getEmployeeProjects();
       this.getProjectsDictionary(this.employee.id);
      });
  }

  /**
   * Unassigns project
   * @param id 
   */
  unassignProject(id: string): void{
    this.employeeService.unassignFromProject(this.employee.id, id)
    .subscribe(x => { 
      this.getEmployeeProjects();
      this.getProjectsDictionary(this.employee.id);
    });
  }

}