import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Client } from '../../class/Client';
import { ClientService } from '../server/client.service';
import { AuthService } from '../server/auth-service.service';
import { FormsModule } from '@angular/forms';
import { Location } from '@angular/common';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() close = new EventEmitter<void>();
//קומפוננטת הרשמה והתחברות 
//בתור בררית מחדל הוא הרשמה
  c: Client = new Client();
  l: string = 'register';

  constructor(private clientService: ClientService, private auth: AuthService ,public location: Location) { }

  ngOnInit(): void {
    this.auth.getFields(this.l);
  }

  closeLogin(): void {
    this.close.emit();
  }
  //מחליף בין הרשמה להתחברות
  l1(){
    debugger
  if(this.l=='register')
    this.register()
  else
  this.login()
     }

  toggleForm(): void {
    this.l = this.l == 'register' ? 'login' : 'register';
  }

  login(): void {
    //שולח לשרת בקשה עם הנתונים 
    //דרך הservise 


    this.clientService.login(this.c.id ? this.c.id : "", this.c.email ? this.c.email : "").subscribe({
      next: (client) => {
        this.clientService.setCurrentUser(client);
        this.closeLogin();
        Swal.fire({
          title: "Good👌",
          text: "התחברת בהצלחה!",
          icon: "success"
        });
        this.location.back()
      },
      error: (err: any) => {
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "החיבור נכשל"
        });
      }
    });
  }
//שולח הרשמה לשרת 
//ע"י קראיה לservise
//בודק אם הוא הצליח  ואם לא מחזיר לא תשובה בהתאם
  register(): void {

    this.clientService.register(this.c).subscribe({
      next: (success) => {
        if (success) {
          this.clientService.setCurrentUser(this.c);
          this.closeLogin();
          Swal.fire({
            title: "Good👌",
            text: "נרשמת בהצלחה!",
            icon: "success"
          });
          this.location.back();
        } else {
          Swal.fire({
            icon: "error",
            title: "Oops...",
            text: "המשתמש קיים במערכת"
          });
        }
      },
      error: (err: any) => {
        Swal.fire({
          icon: "error",
          title: "Oops...",
          text: "שגיאה במהלך הרישום"
        });
        this.location.back();
      }
    });
  }
}
