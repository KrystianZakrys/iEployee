import { Employee } from './employee';

export interface Manager{
    managerId: string;
    roomNumber: number;
    subordinates: string[];
    employee: Employee;
    employeeId?: string;
}