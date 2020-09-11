import { TestBed } from '@angular/core/testing';

import { PositionService } from './position.service';
import { HttpClientTestingModule  } from '@angular/common/http/testing';

describe('PositionService', () => {
  let service: PositionService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule ],
      providers:[PositionService]
    });
    service = TestBed.inject(PositionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
