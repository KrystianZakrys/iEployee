import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Employee } from './employee';
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

  deleteEmployee(employee: Employee | string): Observable<Employee>{
    const id = typeof employee === 'string'? employee : employee.Id;
    const url = `${this.employeesUrl}/${id}`;
    return this.http.delete<Employee>(url, this.httpOptions).pipe(
      catchError(this.handleError<Employee>('deleteEmployee'))
    );
  }
}
