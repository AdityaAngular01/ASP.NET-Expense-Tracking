import { Routes } from '@angular/router';
import { Landing } from './pages/landing/landing';
import { Features } from './pages/features/features';
import { Pricing } from './pages/pricing/pricing';
import { About } from './pages/about/about';
import { Auth } from './pages/Auth/auth';
import { DashboardLayout } from './pages/dashboard-layout/dashboard-layout';
import { Dashboard } from './pages/dashboard-layout/dashboard/dashboard';
import { Expenses } from './pages/dashboard-layout/expenses/expenses';
import { Groups } from './pages/dashboard-layout/groups/groups';
import { Payments } from './pages/dashboard-layout/payments/payments';
import { Categories } from './pages/dashboard-layout/categories/categories';
import { Settings } from './pages/dashboard-layout/settings/settings';

export const routes: Routes = [
  { path: '', component: Landing },
  { path: 'features', component: Features },
  { path: 'pricing', component: Pricing },
  { path: 'about', component: About },
  {
    path: 'dashboard',
    component: DashboardLayout,
    children:[
      { path: '', component: Dashboard},
      { path: 'expenses', component: Expenses },
      { path: 'groups', component: Groups },
      { path: 'payments', component: Payments },
      { path: 'categories', component: Categories },
      { path: 'settings', component: Settings },
    ]
  },

  {
    path: 'auth',
    component: Auth
  },

  { path: '**', redirectTo: '' },
];
