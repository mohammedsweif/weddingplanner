import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsedGelleryComponent } from './used-gellery.component';

describe('UsedGelleryComponent', () => {
  let component: UsedGelleryComponent;
  let fixture: ComponentFixture<UsedGelleryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsedGelleryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsedGelleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
