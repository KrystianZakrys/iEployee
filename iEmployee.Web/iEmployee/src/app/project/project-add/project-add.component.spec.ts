import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectAddComponent } from './project-add.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectService } from 'src/app/project.service';

describe('ProjectAddComponent', () => {
  let component: ProjectAddComponent;
  let fixture: ComponentFixture<ProjectAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectAddComponent ],
      providers: [ProjectService],
      imports: [HttpClientModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
