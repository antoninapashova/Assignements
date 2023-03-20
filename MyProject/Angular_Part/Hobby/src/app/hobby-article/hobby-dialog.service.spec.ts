import { TestBed } from '@angular/core/testing';

import { HobbyDialogService } from './hobby-dialog.service';

describe('HobbyDialogService', () => {
  let service: HobbyDialogService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HobbyDialogService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
