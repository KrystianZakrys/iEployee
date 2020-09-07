import { Employee } from './employee';

export interface Project{
    id?: string;
    employees?: Employee[];
    name: string;
}