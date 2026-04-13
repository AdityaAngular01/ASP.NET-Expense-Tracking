import { Routes } from '@angular/router';
import { Landing } from './pages/landing/landing';
import { Features } from './pages/features/features';
import { Pricing } from './pages/pricing/pricing';
import { About } from './pages/about/about';
import { Login } from './pages/Auth/login/login';
import { Register } from './pages/Auth/register/register';

export const routes: Routes = [
  { path: '', component: Landing },
  { path: 'features', component: Features },
  { path: 'pricing', component: Pricing },
  { path: 'about', component: About },

  { path: 'login', component: Login },
  { path: 'signup', component: Register },

  { path: '**', redirectTo: '' },
];
