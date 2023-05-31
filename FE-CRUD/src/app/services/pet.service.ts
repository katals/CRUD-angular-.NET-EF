import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Pet } from '../interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PetService {
  private readonly URL_APP: string = environment.apiUrl;
  private readonly URL_API_PET: string = 'api/pet/';

  constructor(private http: HttpClient) {
    console.log(environment.apiUrl);
  }

  getPets(): Observable<Pet[]> {
    return this.http.get<Pet[]>(`${this.URL_APP}${this.URL_API_PET}`);
  }

  getPet(id: number): Observable<Pet> {
    return this.http.get<Pet>(`${this.URL_APP}${this.URL_API_PET}${id}`);
  }

  deletePet(id: number): Observable<void> {
    return this.http.delete<void>(`${this.URL_APP}${this.URL_API_PET}${id}`);
  }

  postPet(pet: Pet): Observable<Pet> {
    return this.http.post<Pet>(`${this.URL_APP}${this.URL_API_PET}`, pet);
  }

  updatePet(pet: Pet): Observable<Pet> {
    return this.http.put<Pet>(`${this.URL_APP}${this.URL_API_PET}`, pet);
  }
}
