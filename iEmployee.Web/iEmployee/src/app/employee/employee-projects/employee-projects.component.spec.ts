import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeProjectsComponent } from './employee-projects.component';
import { EmployeeService } from 'src/app/employee.service';
import { HttpClientModule } from '@angular/common/http';

describe('EmployeeProjectsComponent', () => {
  let component: EmployeeProjectsComponent;
  let fixture: ComponentFixture<EmployeeProjectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeProjectsComponent ],
      providers: [EmployeeService],
      imports: [HttpClientModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
