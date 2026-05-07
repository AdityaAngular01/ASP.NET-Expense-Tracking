import { Component } from '@angular/core';
import { LandingPremiumCta } from './landing-premium-cta/landing-premium-cta';
import { LandingPremiumFeatues } from './landing-premium-featues/landing-premium-featues';
import { LandingHero } from './landing-hero/landing-hero';

@Component({
  selector: 'app-landing-main',
  imports: [LandingHero, LandingPremiumFeatues, LandingPremiumCta],
  templateUrl: './landing-main.html',
  styleUrl: './landing-main.css',
})
export class LandingMain {}
