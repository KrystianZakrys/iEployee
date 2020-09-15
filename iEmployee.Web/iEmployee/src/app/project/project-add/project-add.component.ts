import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../project.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { ToasterService } from 'angular2-toaster';
@Component({
  selector: 'app-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.css']
})
export class ProjectAddComponent implements OnInit {
  project: Project;
  projectName: FormControl;
  constructor(private projectService: ProjectService, 
    private route: ActivatedRoute,
     private location: Location,
     private toasterService: ToasterService) { }

  ngOnInit(): void {
    this.projectName = new FormControl('');
    this.projectName.setValidators(Validators.required);
    
  }
  goBack(): void{
    this.location.back();
  }

  toastMessage(x: boolean, bodySuccess: string): void{
    if(x)
    {
      this.toasterService.pop('success','Success',bodySuccess);
    }
    else{
      this.toasterService.pop('error','Error','Something went wrong.');
    }
  }

  submit(): void{
    if(this.projectName.valid)
      this.projectService.addProject({name: this.projectName.value} as Project).subscribe(x => {
        this.toastMessage(x, 'Added project successfully');
        this.location.back();
      });
  }
}
