import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Employee } from './employee';
import { Project } from './project';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDataService {

  createDb(){
    const employees = [
      {id: '1', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'Alicja',lastName:'Alicjaa',sex:1},
      {id: '2', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'B',lastName:'B',sex:1},
      {id: '3', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'C',lastName:'C',sex:1},
      {id: '4', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'D',lastName:'D',sex:1},
      {id: '5', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'E',lastName:'E',sex:1},
      {id: '6', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'F',lastName:'F',sex:1},
      {id: '7', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'G',lastName:'G',sex:1},
      {id: '8', addressCity: 'Białystok', addressCountry: 'Polska',addressStreet:'Legionowa',addressZipCode:'15-875',birthDate: new Date(),firstName:'H',lastName:'H',sex:1},
    ];
    const projects = [
      {id: '1', projectName: '1'},
      {id: '2', projectName: '2'},
      {id: '3', projectName: '3'},
      {id: '4', projectName: '4'},
      {id: '5', projectName: '5'},
      {id: '6', projectName: '6'},
      {id: '7', projectName: '7'},
    ];
    return {employees, projects};
  }

  // genId(array: <T>[]): number {
  //   return array.length > 0 ?  array.length+ 1 : 1;
  // }
  constructor() { }
}
