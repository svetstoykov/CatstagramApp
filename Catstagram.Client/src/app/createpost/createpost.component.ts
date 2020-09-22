import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CatService } from '../services/applicationServices/cat.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['../../styles/formstyle.css']
})
export class CreatepostComponent implements OnInit {

  catForm: FormGroup

  constructor(private fb: FormBuilder, private catService: CatService, private router: Router) {
    this.catForm = this.fb.group({
      "imageUrl": ["", Validators.required],
      "description": [""]
    })
   }

  ngOnInit(): void {
  }

  get imageUrl(){
    return this.catForm.get("imageUrl")
  }

  create(){
    this.catService
      .create(this.catForm.value)
      .subscribe(data => {
        this.router.navigate(["cats"])
      })

  }

}
