import { Injectable } from '@angular/core';
import { Employee } from './employee';
import { HttpClient, HttpHeaders }  from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class PositionService {
  private positionsUrl = `http://localhost:60811/api/Positions`;
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

  getPositions(): Observable<Position[]>{
    return this.http.get<Position[]>(this.positionsUrl)
      .pipe(
        catchError(this.handleError<Position[]>('getPositions',[]))
      );
  }
}
