import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfileService } from '../services/applicationServices/profile.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserProfile} from '../models/UserProfile';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  private userId: string;
  private user: UserProfile;
  private dataIsAvailable: boolean = false;
  
  constructor(private profileService: ProfileService, private route: ActivatedRoute, 
    private router: Router, private fb: FormBuilder) { } 

  ngOnInit(): void {
    this.profileService.getCurrentUser().subscribe((userData) => {
      this.user = userData;
      this.dataIsAvailable = true;
      console.log(this.user);
    })

  }



}
