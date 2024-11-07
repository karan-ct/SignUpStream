import { Routes } from '@angular/router';
import { LayoutComponent } from './components/common/layout/layout.component';

export const routes: Routes = [
    { path: 'signup', component: LayoutComponent },
    { path: '', redirectTo: '/signup', pathMatch: 'full' }
];
