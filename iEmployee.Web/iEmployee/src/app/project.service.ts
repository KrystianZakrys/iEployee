import { Injectable } from '@angular/core';
import { Project } from './project';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private projectsUrl = `api/projects`;

  constructor(private http: HttpClient) { }

  handleError<T>(operation = 'operation',result?: T){
    return (error: any): Observable<T> =>{
      console.error(error);
      return of(result as T);
    } 
  }

  getProjects(): Observable<Project[]>{
    return this.http.get<Project[]>(this.projectsUrl)
      .pipe(
        catchError(this.handleError<Project[]>('getProjects',[]))
      );
  }

  getProject(id: string): Observable<Project>{
    const url = `${this.projectsUrl}/${id}`;
    return this.http.get<Project>(url).
      pipe(
        catchError(this.handleError<Project>(`getProject id=${id}`))
      );
  }
}
