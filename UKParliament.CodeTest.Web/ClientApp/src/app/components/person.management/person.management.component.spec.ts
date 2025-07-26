import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonManagementComponent } from './person.management.component';
import { provideHttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('PersonManagementComponent', () => {
  let component: PersonManagementComponent;
  let fixture: ComponentFixture<PersonManagementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [provideHttpClient(), BrowserAnimationsModule]
    })
    .compileComponents();
  });
    
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PersonManagementComponent, BrowserAnimationsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
