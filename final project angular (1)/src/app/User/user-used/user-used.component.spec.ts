import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserUsedComponent } from './user-used.component';

describe('UserUsedComponent', () => {
  let component: UserUsedComponent;
  let fixture: ComponentFixture<UserUsedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserUsedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserUsedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
