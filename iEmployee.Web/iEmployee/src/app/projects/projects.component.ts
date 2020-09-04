import { Component, OnInit } from '@angular/core';
import { Project }  from '../project';
import { ProjectService } from '../project.service';
import { Observable } from 'rxjs';
import { PROJECTS } from '../projectsMock';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {
  displayedColumns: string[] = ['id', 'projectName','actions'];
  dataSource: Project[];
  constructor(private projectService: ProjectService) { }

  ngOnInit(): void {
    this.getProjects();
  }

  getProjects(): void{
    this.projectService.getProjects()
     .subscribe(x => this.dataSource = x);
  }
}
