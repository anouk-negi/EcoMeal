import { Routes } from '@angular/router';
import { Businesses } from '../Pages/businesses/businesses';
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
        path: 'login',
        component: LoginComponent
    },
    {
        path: '**',
        redirectTo: 'business'
    }
];