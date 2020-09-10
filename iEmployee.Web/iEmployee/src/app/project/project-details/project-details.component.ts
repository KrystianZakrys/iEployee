import { Component, OnInit } from '@angular/core';
import { Project } from '../../project';
import { ProjectService } from '../../project.service';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.css']
})
export class ProjectDetailsComponent implements OnInit {
  project: Project;
  constructor(private projectService: ProjectService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit(): void {
    this.getProject();

  }

  getProject(): void{
    const id = this.route.snapshot.paramMap.get('id');
    this.projectService.getProject(id).subscribe(x => {this.project = x;});
  }

  goBack(): void{
    this.location.back();
  }
}
