import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../class/product';
import { Company } from '../../class/company';

@Injectable({
  providedIn: 'root',
})
export class CompenyService {
  private baseUrl = 'https://localhost:7092/api/Company'; 
//קומפוננטה להבאת כל החברות
  constructor(private http: HttpClient) {}
 


  getAllCompany(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl);
  }
}
