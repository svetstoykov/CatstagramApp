import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['../../styles/formstyle.css']
})
export class CreatepostComponent implements OnInit {

  catForm: FormGroup

  constructor(private fb: FormBuilder, private catService: CatService) {
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
        console.log(data);
      })
  }

}
