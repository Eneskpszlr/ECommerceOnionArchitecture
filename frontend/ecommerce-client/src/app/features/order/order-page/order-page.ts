import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderService } from '../../../core/services/api/order-service';
import { Order } from '../../../core/models/order.model';
import { OrderUpsert } from '../../../core/models/order-upsert.model';

@Component({
  selector: 'app-order-page',
  imports: [CommonModule],
  templateUrl: './order-page.html',
  styleUrl: './order-page.css',
})
export class OrderPage implements OnInit {

  private orderService = inject(OrderService);

  // READ
  protected orders = signal<Order[]>([]);

  // seçili order
  protected selectedOrder = signal<Order | null>(null);

  // CREATE inputs
  protected newShippingAddress = signal<string>('');
  protected newAppUserId = signal<number>(0);

  // UPDATE inputs
  protected editShippingAddress = signal<string>('');
  protected editAppUserId = signal<number>(0);

  async ngOnInit(): Promise<void> {
    await this.loadOrders();
  }

  async loadOrders(): Promise<void> {
    this.orders.set(await this.orderService.getAll());
  }

  /* ---------------- CREATE ---------------- */

  onNewShippingAddressChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.newShippingAddress.set(value);
  }

  onNewAppUserIdChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.newAppUserId.set(value);
  }

  async addOrder(event: Event): Promise<void> {
    event.preventDefault();

    const body: OrderUpsert = {
      shippingAddress: this.newShippingAddress(),
      appUserId: this.newAppUserId(),
    };

    try {
      await this.orderService.create(body);
      await this.loadOrders();

      this.newShippingAddress.set('');
      this.newAppUserId.set(0);
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- DELETE ---------------- */

  async deleteOrder(id: number): Promise<void> {
    try {
      await this.orderService.remove(id);
      await this.loadOrders();

      if (this.selectedOrder()?.id === id) {
        this.cancelEdit();
      }
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- UPDATE ---------------- */

  startEdit(order: Order): void {
    this.selectedOrder.set(order);

    this.editShippingAddress.set(order.shippingAddress);
    this.editAppUserId.set(order.appUserId);
  }

  onEditShippingAddressChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.editShippingAddress.set(value);
  }

  onEditAppUserIdChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.editAppUserId.set(value);
  }

  async updateOrder(event: Event): Promise<void> {
    event.preventDefault();

    const current = this.selectedOrder();
    if (!current) return;

    const body: OrderUpsert = {
      id: current.id,
      shippingAddress: this.editShippingAddress(),
      appUserId: this.editAppUserId(),
    };

    try {
      await this.orderService.update(body);
      await this.loadOrders();
      this.cancelEdit();
    } catch (error) {
      console.log(error);
    }
  }

  cancelEdit(): void {
    this.selectedOrder.set(null);
    this.editShippingAddress.set('');
    this.editAppUserId.set(0);
  }
}
