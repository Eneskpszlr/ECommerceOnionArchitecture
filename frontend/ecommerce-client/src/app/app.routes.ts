import { Routes } from '@angular/router';
import { CategoryPage } from './features/category/category-page/category-page';
import { ProductPage } from './features/product/product-page/product-page';
import { OrderPage } from './features/order/order-page/order-page';
import { AppUserPage } from './features/appUser/app-user-page/app-user-page';
import { OrderDetailPage } from './features/orderDetail/order-detail-page/order-detail-page';

export const routes: Routes = [
  { path: '', redirectTo: 'categories', pathMatch: 'full' },

  { path: 'categories', component: CategoryPage },
  { path: 'products', component: ProductPage },
  { path: 'orders', component: OrderPage },
  { path: 'order-details', component: OrderDetailPage },

  { path: 'users', component: AppUserPage },

  { path: '**', redirectTo: 'categories' },
];
