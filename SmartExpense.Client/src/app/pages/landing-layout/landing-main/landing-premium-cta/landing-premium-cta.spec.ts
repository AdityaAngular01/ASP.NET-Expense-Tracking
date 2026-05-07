import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingPremiumCta } from './landing-premium-cta';

describe('LandingPremiumCta', () => {
  let component: LandingPremiumCta;
  let fixture: ComponentFixture<LandingPremiumCta>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandingPremiumCta],
    }).compileComponents();

    fixture = TestBed.createComponent(LandingPremiumCta);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
