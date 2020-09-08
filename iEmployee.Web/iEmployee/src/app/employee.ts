import { EmployeeAddComponent } from './employee-add/employee-add.component';

export interface Employee{
    firstName: string;
    lastName: string;
    sex: number;
    birthDate: string;
    address: Address;
    manager: string;
    projects: string;
    id?: string;
}

export interface Address{
    country: string;
    city: string;
    street: string;
    zipCode: string;
}