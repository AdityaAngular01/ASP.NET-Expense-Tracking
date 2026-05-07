import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-settings',
  imports: [CommonModule],
  templateUrl: './settings.html',
  styleUrl: './settings.css',
})
export class Settings {
  darkMode = true;
  emailNotifications = true;
  pushNotifications = false;
  smsNotifications = true;
  twoFactorAuth = false;
  compactLayout = false;
  analyticsTracking = true;
  profilePublic = true;
}
