import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EditHobbyFormComponent } from './edit-hobby-form.component';

describe('EditHobbyFormComponent', () => {
  let component: EditHobbyFormComponent;
  let fixture: ComponentFixture<EditHobbyFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditHobbyFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditHobbyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
