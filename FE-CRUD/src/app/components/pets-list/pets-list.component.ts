import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { Pet } from 'src/app/interfaces/pet';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PetService } from 'src/app/services';

@Component({
  selector: 'app-pets-list',
  templateUrl: './pets-list.component.html',
  styleUrls: ['./pets-list.component.scss'],
})
export class PetsListComponent implements AfterViewInit, OnInit {
  loading: boolean = false;
  dataSource = new MatTableDataSource<Pet>();
  displayedColumns: string[] = [
    'name',
    'age',
    'race',
    'color',
    'weight',
    'actions',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private _snackBar: MatSnackBar, private service: PetService) {}

  ngOnInit(): void {
    this.getPets();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getPets() {
    this.loading = true;
    this.service.getPets().subscribe({
      next: (data) => {
        this.dataSource.data = data;
        this.loading = false;
      },
      error: (error) => {
        this.loading = false;
        alert('Ocurrio un error');
      },
    });
  }

  deletePet(id: number) {
    this.loading = true;

    this.service.deletePet(id).subscribe((data) => {
      this.loading = false;
      this.getPets();
      this._snackBar.open('Elemento eliminado correctamente');
    });
  }
}
