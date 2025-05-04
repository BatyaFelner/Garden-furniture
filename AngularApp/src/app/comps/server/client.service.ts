import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Client } from '../../class/Client';
import { catchError, map, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
//servise להבאת משתמש 
export class ClientService {
  public currentUser: Client | null = null;  
  constructor(public c: HttpClient) { }
 
//הרשמה  - פונקציה בוליאנית שמחזירה האם ההרשמה הצליחה או לא
  register(Client: Client): Observable<boolean> {
    debugger
    return this.c.post<boolean>('https://localhost:7092/api/Client/register', Client);
  }
//מביאה משתמש לפי ID 
  getClientById(id: string): Observable<Client> {
    debugger
  

  let a=this.c.get<Client>(`https://localhost:7092/api/Client/${id}`)
 
     return a;
 
 
  }
  //פונקציה שמקבלת מייל וID
  //  ושולפת מהשרת משתמש לפי ID
  //בודקת פה שבאמת הEMEIL תואם למייל שקבלו מהשרת 
  login(id: string, email: string): Observable<Client> {
    debugger
    return this.getClientById(id).pipe(
      map(client => {
        debugger
        if(client.id==null)
          throw new Error('Dont found user');
        else if (client.email != email && client.id!=null) 
          throw new Error('Email does not match ID');


        
        
        return client;
      })
    );
  }
  //הצבה וקבלה של המשתמש הנוכחי
  getCurrentUser(): Client | null {
    return this.currentUser;
  }

  setCurrentUser(user: Client): void {
    this.currentUser = user;
  }
}
