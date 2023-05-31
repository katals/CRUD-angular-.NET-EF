import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Pet } from '../../interfaces/pet';
import { PetService } from 'src/app/services';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-edit-pet',
  templateUrl: './add-edit-pet.component.html',
  styleUrls: ['./add-edit-pet.component.scss'],
})
export class AddEditPetComponent implements OnInit {
  loading: boolean = false;
  form: FormGroup;
  id!: number;
  titleComponent!: string;

  constructor(
    private fb: FormBuilder,
    private service: PetService,
    private aRoute: ActivatedRoute
  ) {
    this.form = this.fb.group({
      name: ['', Validators.required],
      race: ['', Validators.required],
      age: ['', Validators.required],
      color: ['', Validators.required],
      weight: ['', Validators.required],
    });
    this.id = Number(this.aRoute.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    if (this.id != 0 || null || undefined) {
      this.titleComponent = 'Edit pet';
      this.getPet(this.id);
    } else {
      this.titleComponent = 'Add pet';
    }
  }

  getPet(id: number) {
    this.service.getPet(id).subscribe((data) => {
      console.log(data);
    });
  }

  addPet() {
    const pet: Pet = {
      age: this.form.value.age,
      weight: this.form.value.weight,
      name: this.form.value.name,
      race: this.form.value.race,
      color: this.form.value.color,
    };

    this.service.postPet(pet).subscribe((data) => {});
  }
}
