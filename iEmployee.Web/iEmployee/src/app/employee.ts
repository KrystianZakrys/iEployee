
export interface Employee{
    Id?: string;
    FirstName: string;
    LastName: string;
    Sex: number;
    BirthDate: string;
    Address: Address;
}

export interface Address{
    Country: string;
    City: string;
    Street: string;
    ZipCode: string;
}