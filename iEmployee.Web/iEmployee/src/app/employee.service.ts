import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Employee, JobHistory } from './employee';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeesUrl = `http://localhost:60811/api/Employees`;
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

  getEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.employeesUrl)
      .pipe(
        catchError(this.handleError<Employee[]>('getEmployees',[]))
      );
  }

  getEmployee(id: string): Observable<Employee>{
    const url = `${this.employeesUrl}/${id}`;
    return this.http.get<Employee>(url).
      pipe(
        catchError(this.handleError<Employee>(`getEmployee id=${id}`))
      );
  }

  addEmployee(employee: Employee): Observable<Employee>{
    return this.http.post<Employee>(this.employeesUrl, employee, this.httpOptions)
    .pipe(
      catchError(this.handleError<Employee>('addEmployee'))
    );
  }

  updateEmployee(employee: Employee, id: string): Observable<Employee>{
    console.log(employee);
    return this.http.put<Employee>(`${this.employeesUrl}/${id}`, employee,this.httpOptions)
      .pipe(
        catchError(this.handleError<Employee>(`updateEmployee id=${id}`))
      )
  }

  deleteEmployee(employee: Employee | string): Observable<Employee>{
    const id = typeof employee === 'string'? employee : employee.id;
    const url = `${this.employeesUrl}/${id}`;
    return this.http.delete<Employee>(url, this.httpOptions).pipe(
      catchError(this.handleError<Employee>('deleteEmployee'))
    );
  }

  filterEmployees(employeesQuery: string): Observable<Employee[]>{
    return this.http.get<Employee[]>(`${this.employeesUrl}/Find${employeesQuery}`)
    .pipe(
      catchError(this.handleError<Employee[]>('getEmployees',[]))
    );
  }

  changePosition(employeeId: string, jobHistoryEntry: JobHistory): Observable<Employee>{
    return this.http.post<Employee>(`${this.employeesUrl}/changePos/${employeeId}`,jobHistoryEntry, this.httpOptions)
    .pipe(
      catchError(this.handleError<Employee>('changePosition'))
    );
  }

  assignToProject(employeeId: string, projectId: string): Observable<Employee>{
    return this.http.put<Employee>(`${this.employeesUrl}/assign/${employeeId}/${projectId}`,null, this.httpOptions)
    .pipe(
      catchError(this.handleError<Employee>(`assignToProject employee=${employeeId}; project=${projectId}`))
    );
  }
}
