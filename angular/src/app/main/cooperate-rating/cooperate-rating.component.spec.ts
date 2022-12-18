import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CooperateRatingComponent } from './cooperate-rating.component';

describe('CooperateRatingComponent', () => {
  let component: CooperateRatingComponent;
  let fixture: ComponentFixture<CooperateRatingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CooperateRatingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CooperateRatingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
