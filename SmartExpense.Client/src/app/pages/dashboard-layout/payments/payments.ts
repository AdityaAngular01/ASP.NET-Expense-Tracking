import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-payments',
  imports: [CommonModule],
  templateUrl: './payments.html',
  styleUrl: './payments.css',
})
export class Payments {
  payments = [
    {
      id: 'PAY-1001',
      paidBy: 'Aditya',
      paidTo: 'Rahul',
      amount: 4500,
      group: 'Goa Trip',
      method: 'UPI',
      status: 'Completed',
      date: '07 May 2026',
      transactionId: 'TXN982374',
    },
    {
      id: 'PAY-1002',
      paidBy: 'Neha',
      paidTo: 'Aman',
      amount: 2200,
      group: 'Office Lunch',
      method: 'Bank Transfer',
      status: 'Pending',
      date: '06 May 2026',
      transactionId: 'TXN982375',
    },
    {
      id: 'PAY-1003',
      paidBy: 'Rahul',
      paidTo: 'Aditya',
      amount: 7800,
      group: 'Flat Expenses',
      method: 'Cash',
      status: 'Completed',
      date: '05 May 2026',
      transactionId: 'TXN982376',
    },
    {
      id: 'PAY-1004',
      paidBy: 'Priya',
      paidTo: 'Sneha',
      amount: 1500,
      group: 'Travel Group',
      method: 'UPI',
      status: 'Failed',
      date: '04 May 2026',
      transactionId: 'TXN982377',
    },
  ];
}
