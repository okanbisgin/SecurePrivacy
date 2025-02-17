import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UserEditDialogComponent } from '../user-edit-dialog/user-edit-dialog.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  displayedColumns: string[] = ['name', 'email', 'actions'];

  constructor(
    private userService: UserService,
    private snackBar: MatSnackBar,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((data) => {
      this.users = data;
    });
  }

  deleteUser(id: string | undefined): void {
    if (!id) return;
    this.userService.deleteUser(id).subscribe(() => {
      this.users = this.users.filter(user => user.id !== id);
      this.snackBar.open('User deleted', 'Close', { duration: 2000 });
    });
  }

  editUser(user: User): void {
    const dialogRef = this.dialog.open(UserEditDialogComponent, {
      width: '400px',
      data: user
    });

    dialogRef.afterClosed().subscribe(updatedUser => {
      if (updatedUser) {
        const index = this.users.findIndex(u => u.id === updatedUser.id);
        if (index !== -1) {
          this.users[index] = updatedUser;
        }
      }
    });
  }
}
