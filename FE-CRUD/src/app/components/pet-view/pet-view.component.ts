import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Pet } from 'src/app/interfaces';
import { PetService } from 'src/app/services';

@Component({
  selector: 'app-pet-view',
  templateUrl: './pet-view.component.html',
  styleUrls: ['./pet-view.component.scss'],
})
export class PetViewComponent implements OnInit {
  id: number;
  pet!: Pet;
  loading!: boolean;

  constructor(private service: PetService, private aRoute: ActivatedRoute) {
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.getPet();
  }

  getPet() {
    this.loading = true;
    this.service.getPet(this.id).subscribe((data) => {
      this.loading = false;
      this.pet = data;
    });
  }
}
