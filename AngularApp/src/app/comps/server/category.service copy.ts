import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../../class/category';
//servise  של הבאת כל הקטגוריות 

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(public cf:HttpClient) { }
  getC():Observable<Array<Category>>
  {
    return this.cf.get<Array<Category>>('https://localhost:7092/api/Category')
  }
}

