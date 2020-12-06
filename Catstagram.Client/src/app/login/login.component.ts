import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router,ActivatedRoute, ParamMap } from '@angular/router';
import { AuthService } from '../services/authenticationServices/auth.service';  


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../../styles/formstyle.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  infoMessage = "";
  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private route:ActivatedRoute) {
    this.loginForm = this.fb.group({
      "username": ["", [Validators.required]],
      "password": ["", [Validators.required]]
    })
  }

  ngOnInit(): void {
    if(this.authService.isAuthenticated()){
      this.router.navigate(["cats"])
    }

    this.route.queryParams
      .subscribe(params => {
        if(params.registered !== undefined && params.registered === 'true') {
            this.infoMessage = 'Registration Successful! Please Login!';
        }
      });
  }

  login(){
    this.authService
    .login(this.loginForm.value)
    .subscribe(data => {
      this.authService.saveToken(data["token"]);
      this.router.navigate(["cats"])
    })
  }

  redirectToRegister(){
    this.router.navigate(["register"])
  }

  get username(){
    return this.loginForm.get("username");
  }

  get password(){
    return this.loginForm.get("password");
  }
}
