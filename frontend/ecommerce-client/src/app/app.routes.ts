import { Routes } from '@angular/router';
import { CategoryPage } from './features/category/category-page/category-page';

export const routes: Routes = [
    {
        path: 'categories' ,
        component: CategoryPage
    },
    {
        path: '',
        redirectTo: 'categories' ,
        pathMatch: 'full'
    }
];
