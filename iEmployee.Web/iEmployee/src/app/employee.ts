
export interface Employee{
    address: Address;
    birthDate: string;
    firstName: string;
    managerName?: string;
    id?: string;
    lastName: string;
    sex: number;
    position?: Position;
}

export interface Address{
    country: string;
    city: string;
    street: string;
    zipCode: string;
}

export interface Position{
    id? : string;
    code: string;
    name: string;
    salary: number;
    startDate: Date;
    endDate?:Date;
}

export interface JobHistory{
    salary: number;
    employeeId: string;
    positionId: string;
    startDate: Date;
    endDate: Date;
}