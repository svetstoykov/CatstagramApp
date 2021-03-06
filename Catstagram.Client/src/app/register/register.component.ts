import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { AuthService } from '../services/authenticationServices/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../../styles/formstyle.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.registerForm = this.fb.group({
      "username": ["", [Validators.required]],
      "email": ["", [Validators.required]],
      "password": ["", [Validators.required]]
    })
   }

   ngOnInit(): void {
    if(this.authService.isAuthenticated()){
      this.router.navigate(["cats"])
    }
  }

  register(){
    this.authService
      .register(this.registerForm.value)
      .subscribe(data => {
        this.router.navigate(['login'],{queryParams: { registered: 'true' } });
      })
  }

  redirectLogin(){
    this.router.navigate(["login"]);
  }

  get username(){
    return this.registerForm.get("username");
  }
  get email(){
    return this.registerForm.get("email");
  }
  get password(){
    return this.registerForm.get("password");
  }
  

}
