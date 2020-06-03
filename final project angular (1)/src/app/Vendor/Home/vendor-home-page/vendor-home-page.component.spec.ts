import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorHomePageComponent } from './vendor-home-page.component';

describe('VendorHomePageComponent', () => {
  let component: VendorHomePageComponent;
  let fixture: ComponentFixture<VendorHomePageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorHomePageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
