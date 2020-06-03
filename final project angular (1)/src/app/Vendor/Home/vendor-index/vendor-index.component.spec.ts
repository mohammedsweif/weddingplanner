import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorIndexComponent } from './vendor-index.component';

describe('VendorIndexComponent', () => {
  let component: VendorIndexComponent;
  let fixture: ComponentFixture<VendorIndexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorIndexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorIndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
