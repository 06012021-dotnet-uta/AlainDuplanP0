import { TestBed } from '@angular/core/testing';

import { PlayerserviceService } from './playerservice.service';

describe('PlayerserviceService', () => {
  let service: PlayerserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlayerserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
