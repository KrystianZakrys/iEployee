import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Employee, JobHistory } from './employee';
import { catchError, map, tap } from 'rxjs/operators';
import { Project } from './project';
import { HIGH_CONTRAST_MODE_ACTIVE_CSS_CLASS } from '@angular/cdk/a11y/high-contrast-mode/high-contrast-mode-detector';

@Injectable({
  providedIn: 'root'
})

export class EmployeeService {
  private employeesUrl = `http://localhost:60811/api/Employees`;
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  /**
   * Creates an instance of employee service.
   * @param http 
   */
  constructor(private http: HttpClient) { }

  /**
   * Handles error
   * @template T 
   * @param [operation] 
   * @param [result] 
   * @returns  
   */
  handleError<T>(operation = 'operation',result?: T){
    return (error: any): Observable<T> =>{
      console.error(error);
      return of(result as T);
    } 
  }

  /**
   * Gets employees
   * @returns employees 
   */
  getEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.employeesUrl)
      .pipe(
        catchError(this.handleError<Employee[]>('getEmployees',[]))
      );
  }

  /**
   * Gets employee
   * @param id 
   * @returns employee 
   */
  getEmployee(id: string): Observable<Employee>{
    const url = `${this.employeesUrl}/${id}`;
    return this.http.get<Employee>(url).
      pipe(
        catchError(this.handleError<Employee>(`getEmployee id=${id}`))
      );
  }

  /**
   * Adds employee
   * @param employee 
   * @returns employee 
   */
  addEmployee(employee: Employee): Observable<boolean>{
    return this.http.post<boolean>(this.employeesUrl, employee, this.httpOptions)
    .pipe(
      catchError(this.handleError<boolean>('addEmployee'))
    );
  }

  /**
   * Updates employee
   * @param employee 
   * @param id 
   * @returns employee 
   */
  updateEmployee(employee: Employee, id: string): Observable<boolean>{
    return this.http.put<boolean>(`${this.employeesUrl}/${id}`, employee,this.httpOptions)      
      .pipe(
        catchError(this.handleError<boolean>(`updateEmployee id=${id}`))
      )
  }

  /**
   * Deletes employee
   * @param employee 
   * @returns employee 
   */
  deleteEmployee(employee: Employee | string): Observable<boolean>{
    const id = typeof employee === 'string'? employee : employee.id;
    const url = `${this.employeesUrl}/${id}`;
    return this.http.delete<boolean>(url, this.httpOptions).pipe(
      catchError(this.handleError<boolean>('deleteEmployee'))
    );
  }

  /**
   * Filters employees
   * @param employeesQuery 
   * @returns employees 
   */
  filterEmployees(employeesQuery: string): Observable<Employee[]>{
    return this.http.get<Employee[]>(`${this.employeesUrl}/Find${employeesQuery}`)
    .pipe(
      catchError(this.handleError<Employee[]>('getEmployees',[]))
    );
  }

  /**
   * Changes position
   * @param employeeId 
   * @param jobHistoryEntry 
   * @returns position 
   */
  changePosition(employeeId: string, jobHistoryEntry: JobHistory): Observable<boolean>{
    return this.http.post<boolean>(`${this.employeesUrl}/changePos/${employeeId}`,jobHistoryEntry, this.httpOptions)
    .pipe(
      catchError(this.handleError<boolean>('changePosition'))
    );
  }

  /**
   * Assigns to project
   * @param employeeId 
   * @param projectId 
   * @returns to project 
   */
  assignToProject(employeeId: string, projectId: string): Observable<Employee>{
    return this.http.put<Employee>(`${this.employeesUrl}/assign/${employeeId}/${projectId}`,null, this.httpOptions)
    .pipe(
      catchError(this.handleError<Employee>(`assignToProject employee=${employeeId}; project=${projectId}`))
    );
  }

  /**
   * Unassign from project
   * @param employeeId 
   * @param projectId 
   * @returns from project 
   */
  unassignFromProject(employeeId: string, projectId: string): Observable<Employee>{
    return this.http.put<Employee>(`${this.employeesUrl}/unassign/${employeeId}/${projectId}`,null, this.httpOptions)
    .pipe(
      catchError(this.handleError<Employee>(`unassignToProject employee=${employeeId}; project=${projectId}`))
    );
  }

  /**
   * Gets employee projects
   * @param id 
   * @returns employee projects 
   */
  getEmployeeProjects(id: string): Observable<Project[]>{
    const url = `${this.employeesUrl}/Projects/${id}`;
    return this.http.get<Project[]>(url)
    .pipe(
      catchError(this.handleError<Project[]>('getEmployeeProjects',[]))
    );
  }
}
