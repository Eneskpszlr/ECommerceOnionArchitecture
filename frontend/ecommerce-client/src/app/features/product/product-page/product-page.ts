import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductService } from '../../../core/services/api/product-service';
import { Product } from '../../../core/models/product.model';
import { ProductUpsert } from '../../../core/models/product-upsert.model';

@Component({
  selector: 'app-product-page',
  imports: [CommonModule],
  templateUrl: './product-page.html',
  styleUrl: './product-page.css',
})
export class ProductPage implements OnInit {

  private productService = inject(ProductService);

  // READ
  protected products = signal<Product[]>([]);

  // seçili product
  protected selectedProduct = signal<Product | null>(null);

  // CREATE inputs
  protected newProductName = signal<string>('');
  protected newUnitPrice = signal<number>(0);
  protected newCategoryId = signal<number>(0);

  // UPDATE inputs
  protected editProductName = signal<string>('');
  protected editUnitPrice = signal<number>(0);
  protected editCategoryId = signal<number>(0);

  async ngOnInit(): Promise<void> {
    await this.loadProducts();
  }

  async loadProducts(): Promise<void> {
    this.products.set(await this.productService.getAll());
  }

  /* ---------------- CREATE ---------------- */

  onNewProductNameChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.newProductName.set(value);
  }

  onNewUnitPriceChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.newUnitPrice.set(value);
  }

  onNewCategoryIdChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.newCategoryId.set(value);
  }

  async addProduct(event: Event): Promise<void> {
    event.preventDefault();

    const body: ProductUpsert = {
      productName: this.newProductName(),
      unitPrice: this.newUnitPrice(),
      categoryId: this.newCategoryId(),
    };

    try {
      await this.productService.create(body);
      await this.loadProducts();

      this.newProductName.set('');
      this.newUnitPrice.set(0);
      this.newCategoryId.set(0);
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- DELETE ---------------- */

  async deleteProduct(id: number): Promise<void> {
    try {
      await this.productService.remove(id);
      await this.loadProducts();

      if (this.selectedProduct()?.id === id) {
        this.cancelEdit();
      }
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- UPDATE ---------------- */

  startEdit(product: Product): void {
    this.selectedProduct.set(product);

    this.editProductName.set(product.productName);
    this.editUnitPrice.set(product.unitPrice);
    this.editCategoryId.set(product.categoryId);
  }

  onEditProductNameChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.editProductName.set(value);
  }

  onEditUnitPriceChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.editUnitPrice.set(value);
  }

  onEditCategoryIdChange(event: Event): void {
    const value = +(event.target as HTMLInputElement).value;
    this.editCategoryId.set(value);
  }

  async updateProduct(event: Event): Promise<void> {
    event.preventDefault();

    const current = this.selectedProduct();
    if (!current) return;

    const body: ProductUpsert = {
      id: current.id,
      productName: this.editProductName(),
      unitPrice: this.editUnitPrice(),
      categoryId: this.editCategoryId(),
    };

    try {
      await this.productService.update(body);
      await this.loadProducts();
      this.cancelEdit();
    } catch (error) {
      console.log(error);
    }
  }

  cancelEdit(): void {
    this.selectedProduct.set(null);
    this.editProductName.set('');
    this.editUnitPrice.set(0);
    this.editCategoryId.set(0);
  }
}
