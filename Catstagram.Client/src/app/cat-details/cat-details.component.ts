import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CatDetails } from '../models/CatDetails';
import { CatUpdate } from '../models/CatUpdate';
import { CatService } from '../services/cat.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-cat-details',
  templateUrl: './cat-details.component.html',
  styleUrls: ['../../styles/formstyle.css'],
})
export class CatDetailsComponent implements OnInit {

  catId: string;
  cat: CatDetails;
  catUpdate: CatUpdate;
  catUpdateForm: FormGroup;
  descriptionEditable: boolean;

  constructor(
    private catService: CatService, 
    private route: ActivatedRoute, 
    private router: Router,
    private fb: FormBuilder) {
      this.getCatId();
      this.initializeCatUpdateForm();
  }



  private initializeCatUpdateForm() {
    this.catUpdateForm = this.fb.group({
      "description": [""]
    });
  }

  ngOnInit():void {
    this.catService.getCatById(this.catId).subscribe((catData) => {
      this.cat = catData;
    });
  }

  deleteCat(){
    this.catService.deleteCatById(this.catId).subscribe(res => {
      this.router.navigate(["cats"]);
    });
  }

  updateCat(){

    if(this.description === this.cat.description){
      this.descriptionEditable = false;
      return;
    }

    this.catUpdate = {
      id: parseInt(this.catId),
      description: this.description
    }

    this.catService.updateCat(this.catUpdate)
    .subscribe(res => {
      this.descriptionEditable = false;
      this.ngOnInit();
    })
  }

  editDescription(){
    this.descriptionEditable = true;
  }

  private getCatId() {
    this.route.params.subscribe((url) => {
      this.catId = url['id'];
    });
  }

  get description(){
    return this.catUpdateForm.get("description").value;
  }
}
