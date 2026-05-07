import { Component } from '@angular/core';
import { Footer } from '../../shared/footer/footer';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-landing-layout',
  imports: [Footer, RouterOutlet],
  templateUrl: './landing-layout.html',
  styleUrl: './landing-layout.css',
})
export class LandingLayout {}
