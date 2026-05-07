import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-expenses',
  imports: [CommonModule],
  templateUrl: './expenses.html',
  styleUrl: './expenses.css',
})
export class Expenses {
  expenses = [
    {
      id: 1,
      title: 'Dinner at BBQ Nation',
      category: 'Food',
      group: 'Friends Group',
      amount: 2400,
      paidBy: 'Aditya',
      date: '07 May 2026',
      status: 'Pending',
    },
    {
      id: 2,
      title: 'Goa Resort Booking',
      category: 'Travel',
      group: 'Goa Trip',
      amount: 12500,
      paidBy: 'Rahul',
      date: '05 May 2026',
      status: 'Settled',
    },
    {
      id: 3,
      title: 'Netflix Subscription',
      category: 'Entertainment',
      group: 'Personal',
      amount: 799,
      paidBy: 'Aditya',
      date: '04 May 2026',
      status: 'Paid',
    },
    {
      id: 4,
      title: 'Office Team Lunch',
      category: 'Food',
      group: 'Office',
      amount: 5400,
      paidBy: 'Neha',
      date: '02 May 2026',
      status: 'Pending',
    },
    {
      id: 5,
      title: 'Uber Ride',
      category: 'Transport',
      group: 'Personal',
      amount: 350,
      paidBy: 'Aditya',
      date: '01 May 2026',
      status: 'Paid',
    },
  ];
}
