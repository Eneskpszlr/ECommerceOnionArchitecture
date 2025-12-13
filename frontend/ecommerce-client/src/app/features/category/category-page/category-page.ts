import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryService } from '../../../core/services/api/category-service';
import { Category } from '../../../core/models/category.model';
import { CategoryUpsert } from '../../../core/models/category-upsert.model';

@Component({
  selector: 'app-category-page',
  imports: [CommonModule],
  templateUrl: './category-page.html',
  styleUrl: './category-page.css',
})
export class CategoryPage implements OnInit {

  private categoryService = inject(CategoryService);

  // READ
  protected categories = signal<Category[]>([]);

  // seçili kategori
  protected selectedCategory = signal<Category | null>(null);

  // CREATE inputs
  protected newCategoryName = signal<string>('');
  protected newCategoryDescription = signal<string>('');

  // UPDATE inputs (edit alanları)
  protected editCategoryName = signal<string>('');
  protected editCategoryDescription = signal<string>('');

  async ngOnInit(): Promise<void> {
    await this.loadCategories();
  }

  async loadCategories(): Promise<void> {
    this.categories.set(await this.categoryService.getAll());
  }

  /* ---------------- CREATE ---------------- */

  onNewCategoryNameChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.newCategoryName.set(value);
  }

  onNewCategoryDescriptionChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.newCategoryDescription.set(value);
  }

  async addCategory(event: Event): Promise<void> {
    event.preventDefault();

    const body: CategoryUpsert = {
      categoryName: this.newCategoryName(),
      description: this.newCategoryDescription(),
    };

    try {
      await this.categoryService.create(body);
      await this.loadCategories();

      this.newCategoryName.set('');
      this.newCategoryDescription.set('');
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- DELETE ---------------- */

  async deleteCategory(id: number): Promise<void> {
    // if (!confirm('Silmek istediğine emin misin?')) return;

    try {
      await this.categoryService.remove(id);
      await this.loadCategories();

      // silinen seçili ise temizle
      if (this.selectedCategory()?.id === id) {
        this.cancelEdit();
      }
    } catch (error) {
      console.log(error);
    }
  }

  /* ---------------- UPDATE ---------------- */

  // Düzenle butonuna basınca seçili kategori + inputları doldur
  startEdit(category: Category): void {
    this.selectedCategory.set(category);

    this.editCategoryName.set(category.categoryName);
    this.editCategoryDescription.set(category.description);
  }

  onEditCategoryNameChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.editCategoryName.set(value);
  }

  onEditCategoryDescriptionChange(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.editCategoryDescription.set(value);
  }

  async updateCategory(event: Event): Promise<void> {
    event.preventDefault();

    const current = this.selectedCategory();
    if (!current) return;

    const body: CategoryUpsert = {
      id: current.id,
      categoryName: this.editCategoryName(),
      description: this.editCategoryDescription(),
    };

    try {
      await this.categoryService.update(body);
      await this.loadCategories();
      this.cancelEdit();
    } catch (error) {
      console.log(error);
    }
  }

  cancelEdit(): void {
    this.selectedCategory.set(null);
    this.editCategoryName.set('');
    this.editCategoryDescription.set('');
  }
}