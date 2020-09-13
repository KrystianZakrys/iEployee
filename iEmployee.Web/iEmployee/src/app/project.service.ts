import { Injectable } from '@angular/core';
import { Project } from './project';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Employee } from './employee';
@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private projectsUrl = `http://localhost:60811/api/Projects`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

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

  addProject(project: Project): Observable<Project>{
    return this.http.post<Project>(this.projectsUrl, project, this.httpOptions)
    .pipe(
      catchError(this.handleError<Project>('addProject'))
    );
  }

  getNotAssignedProjects(id: string): Observable<Project[]>{
    const url = `${this.projectsUrl}/NotAssigned/${id}`;
    return this.http.get<Project[]>(url)
    .pipe(
      catchError(this.handleError<Project[]>('getNotAssignedProjects',[]))
    );
  }

  getProjectEmployees(id: string): Observable<Employee[]>{
    const url = `${this.projectsUrl}/Employees/${id}`;
    return this.http.get<Employee[]>(url)
    .pipe(
      catchError(this.handleError<Employee[]>('getProjectEmployees',[]))
    );
  }

  updateProject(id: string, project: Project): Observable<Project>{
    return this.http.put<Project>(`${this.projectsUrl}/${id}`, project, this.httpOptions)
    .pipe(
      catchError(this.handleError<Project>(`updateProject id=${id}`))
    );
  }
  deleteProject(id: string): Observable<Project>{
    return this.http.delete<Project>(`${this.projectsUrl}/${id}`, this.httpOptions)
    .pipe(
      catchError(this.handleError<Project>(`deleteProject id=${id}`))
      );
  }
}
