import { Injectable } from '@angular/core';
import { Country } from '../models/country.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor(private http: HttpClient) { }

  getConutriesList() {
    return this.http.get<Country[]>('/countries.json');
  }
}
