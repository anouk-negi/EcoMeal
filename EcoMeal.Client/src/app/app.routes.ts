import { Routes } from '@angular/router';
import { Businesses } from '../Pages/businesses/businesses';
import { PackagesPage } from '../Pages/packages/packages';
import { LoginComponent } from '../Components/login/login';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'business',
        pathMatch: 'full'
    },
    {
        path: 'business',
        component: Businesses
    },
    {
        path: 'packages',
        component: PackagesPage
    },
    {
        path: 'login',
        component: LoginComponent
    },
    {
        path: '**',
        redirectTo: 'business'
    }
];