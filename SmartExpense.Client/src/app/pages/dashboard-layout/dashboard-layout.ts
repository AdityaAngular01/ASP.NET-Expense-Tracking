import { Component, OnInit } from '@angular/core';
import { isActive, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { NgClass } from '@angular/common';

interface IDashboardSideLink{
  icon: any;
  link: string;
  title: string;
}
@Component({
  selector: 'app-dashboard-layout',
  imports: [RouterOutlet, RouterLink, RouterLinkActive, NgClass],
  templateUrl: './dashboard-layout.html',
  styleUrl: './dashboard-layout.css',
})
export class DashboardLayout implements OnInit {
  emailAddress: string = 'aditya@gmail.com';

  dashboardSideLinks: IDashboardSideLink[] = [
    {
      icon: '📊',
      link: '/dashboard',
      title: 'Dashboard',
    },
    {
      icon: '💰',
      link: '/dashboard/expenses',
      title: 'Expenses',
    },
    {
      icon: '👥',
      link: '/dashboard/groups',
      title: 'Groups',
    },
    {
      icon: '🧾',
      link: '/dashboard/payments',
      title: 'Payments',
    },
    {
      icon: '🏷️',
      link: '/dashboard/categories',
      title: 'Categories',
    },
    {
      icon: '⚙️',
      link: '/dashboard/settings',
      title: 'Settings',
    },
  ];

  ngOnInit() {}

  protected readonly isActive = isActive;
}
