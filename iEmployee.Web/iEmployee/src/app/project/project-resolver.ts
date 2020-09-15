import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Project  } from '../project';
import { ProjectService } from '../project.service';

@Injectable()
export class ProjectResolver implements Resolve<Project>{
    constructor(private projectService: ProjectService){}

    resolve(route: ActivatedRouteSnapshot): Project | Observable<Project> | Promise<Project> {
        return this.projectService.getProject(route.params['id']);
    }

}