import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticalDetailsComponent } from './artical-details.component';

describe('ArticalDetailsComponent', () => {
  let component: ArticalDetailsComponent;
  let fixture: ComponentFixture<ArticalDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticalDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticalDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
