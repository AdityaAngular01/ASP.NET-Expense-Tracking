import { Routes } from '@angular/router';
import { Features } from './pages/landing-layout/features/features';
import { Pricing } from './pages/landing-layout/pricing/pricing';
import { About } from './pages/landing-layout/about/about';
import { Auth } from './pages/landing-layout/Auth/auth';
import { DashboardLayout } from './pages/dashboard-layout/dashboard-layout';
import { Dashboard } from './pages/dashboard-layout/dashboard/dashboard';
import { Expenses } from './pages/dashboard-layout/expenses/expenses';
import { Groups } from './pages/dashboard-layout/groups/groups';
import { Payments } from './pages/dashboard-layout/payments/payments';
import { Categories } from './pages/dashboard-layout/categories/categories';
import { Settings } from './pages/dashboard-layout/settings/settings';
import { LandingLayout } from './pages/landing-layout/landing-layout';
import { LandingMain } from './pages/landing-layout/landing-main/landing-main';
import { DashboardShowcase } from './pages/landing-layout/dashboard-showcase/dashboard-showcase';
import { Analytics } from './pages/landing-layout/analytics/analytics';

export const routes: Routes = [
  {
    path: '',
    component: LandingLayout,
    children: [
      { path: '', component: LandingMain },
      { path: 'features', component: Features },
      { path: 'pricing', component: Pricing },
      { path: 'about', component: About },
      { path: 'dashboard-showcase', component: DashboardShowcase },
      { path: 'analytics', component: Analytics },
      { path: 'auth', component: Auth },
    ],
  },
  {
    path: 'dashboard',
    component: DashboardLayout,
    children: [
      { path: '', component: Dashboard },
      { path: 'expenses', component: Expenses },
      { path: 'groups', component: Groups },
      { path: 'payments', component: Payments },
      { path: 'categories', component: Categories },
      { path: 'settings', component: Settings },
    ],
  },

  { path: '**', redirectTo: '' },
];
