import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingPremiumFeatues } from './landing-premium-featues';

describe('LandingPremiumFeatues', () => {
  let component: LandingPremiumFeatues;
  let fixture: ComponentFixture<LandingPremiumFeatues>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandingPremiumFeatues],
    }).compileComponents();

    fixture = TestBed.createComponent(LandingPremiumFeatues);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
