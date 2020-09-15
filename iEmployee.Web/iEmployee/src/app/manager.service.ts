import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Manager } from './manager';
import { catchError, map, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ManagerService {
  private managersUrl = `http://localhost:60811/api/Managers`;
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

  getManagers(): Observable<Manager[]>{
    return this.http.get<Manager[]>(this.managersUrl)
      .pipe(
        catchError(this.handleError<Manager[]>('getManagers',[]))
      );
  }

  getManager(id: string): Observable<Manager>{
    const url = `${this.managersUrl}/${id}`;
    return this.http.get<Manager>(url).
      pipe(
        catchError(this.handleError<Manager>(`getManager id=${id}`))
      );
  }

  addManager(manager: Manager): Observable<boolean>{
    return this.http.post<boolean>(this.managersUrl, manager, this.httpOptions)
    .pipe(
      catchError(this.handleError<boolean>('addManager'))
    );
  }

  updateManager(manager: Manager, id: string): Observable<boolean>{
    return this.http.put<boolean>(`${this.managersUrl}/${id}`, manager,this.httpOptions)
      .pipe(
        catchError(this.handleError<boolean>(`updateManager id=${id}`))
      )
  }

  deleteManager(manager: Manager | string): Observable<boolean>{
    const id = typeof manager === 'string'? manager : manager.managerId;
    const url = `${this.managersUrl}/${id}`;
    return this.http.delete<boolean>(url, this.httpOptions).pipe(
      catchError(this.handleError<boolean>('deleteManager'))
    );
  }

}
