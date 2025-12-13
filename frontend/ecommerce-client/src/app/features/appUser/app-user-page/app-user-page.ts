import { Component, OnInit, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppUserService } from '../../../core/services/api/app-user-service';
import { AppUser } from '../../../core/models/app-user.model';
import { AppUserUpsert } from '../../../core/models/app-user-upsert.model';

@Component({
  selector: 'app-app-user-page',
  imports: [CommonModule],
  templateUrl: './app-user-page.html',
  styleUrl: './app-user-page.css',
})
export class AppUserPage implements OnInit {

  private appUserService = inject(AppUserService);

  protected appUsers = signal<AppUser[]>([]);
  protected selectedAppUser = signal<AppUser | null>(null);

  protected newUserName = signal('');
  protected newPassword = signal('');

  protected editUserName = signal('');
  protected editPassword = signal('');

  async ngOnInit(): Promise<void> {
    await this.loadUsers();
  }

  async loadUsers(): Promise<void> {
    this.appUsers.set(await this.appUserService.getAll());
  }

  /* ---------- CREATE ---------- */

  onNewUserNameChange(e: Event) {
    this.newUserName.set((e.target as HTMLInputElement).value);
  }

  onNewPasswordChange(e: Event) {
    this.newPassword.set((e.target as HTMLInputElement).value);
  }

  async addUser(e: Event) {
    e.preventDefault();

    const body: AppUserUpsert = {
      userName: this.newUserName(),
      password: this.newPassword(),
    };

    await this.appUserService.create(body);
    await this.loadUsers();

    this.newUserName.set('');
    this.newPassword.set('');
  }

  /* ---------- DELETE ---------- */

  async deleteUser(id: number) {
    await this.appUserService.remove(id);
    await this.loadUsers();
    if (this.selectedAppUser()?.id === id) this.cancelEdit();
  }

  /* ---------- UPDATE ---------- */

  startEdit(user: AppUser) {
    this.selectedAppUser.set(user);
    this.editUserName.set(user.userName);
  }

  onEditUserNameChange(e: Event) {
    this.editUserName.set((e.target as HTMLInputElement).value);
  }

  onEditPasswordChange(e: Event) {
    this.editPassword.set((e.target as HTMLInputElement).value);
  }

  async updateUser(e: Event) {
    e.preventDefault();
    if (!this.selectedAppUser()) return;

    const body: AppUserUpsert = {
      id: this.selectedAppUser()!.id,
      userName: this.editUserName(),
      password: this.editPassword(),
    };

    await this.appUserService.update(body);
    await this.loadUsers();
    this.cancelEdit();
  }

  cancelEdit() {
    this.selectedAppUser.set(null);
    this.editUserName.set('');
    this.editPassword.set('');
  }
}
