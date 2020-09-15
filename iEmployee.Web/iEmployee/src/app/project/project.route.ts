import { Routes } from '@angular/router';


import { ProjectsComponent  } from './projects/projects.component';
import { ProjectDetailsComponent } from './project-details/project-details.component';
import {ProjectAddComponent  } from './project-add/project-add.component';
import { ProjectResolver } from './project-resolver';

export const projectRoutes: Routes = [
    {
        path: '', children: [
        {path: 'projects', component: ProjectsComponent},
        {path: 'projects/details/:id', component: ProjectDetailsComponent, resolve: {project: ProjectResolver}},
        {path: 'projects/add', component: ProjectAddComponent}
        ]
    },
];
