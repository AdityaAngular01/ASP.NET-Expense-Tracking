import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-groups',
  imports: [CommonModule],
  templateUrl: './groups.html',
  styleUrl: './groups.css',
})
export class Groups {
  groups = [
    {
      id: 1,
      name: 'Goa Trip 2026',
      description: 'Vacation expenses with friends',
      totalExpense: 45200,
      members: ['Aditya', 'Rahul', 'Neha', 'Aman', 'Priya'],
      pendingAmount: 7800,
      createdBy: 'Aditya',
      status: 'Active',
      category: 'Travel',
      recentActivity: 'Rahul added Hotel Expense',
      createdAt: '05 May 2026',
    },
    {
      id: 2,
      name: 'Office Team Lunch',
      description: 'Weekly office lunch split',
      totalExpense: 12400,
      members: ['Aditya', 'Rohit', 'Sneha', 'Karan'],
      pendingAmount: 2100,
      createdBy: 'Rohit',
      status: 'Pending',
      category: 'Food',
      recentActivity: 'Sneha settled payment',
      createdAt: '02 May 2026',
    },
    {
      id: 3,
      name: 'Flat Expenses',
      description: 'Shared apartment expenses',
      totalExpense: 28500,
      members: ['Aditya', 'Rahul', 'Amit'],
      pendingAmount: 0,
      createdBy: 'Rahul',
      status: 'Settled',
      category: 'Living',
      recentActivity: 'Electricity bill added',
      createdAt: '28 Apr 2026',
    },
  ];
}
