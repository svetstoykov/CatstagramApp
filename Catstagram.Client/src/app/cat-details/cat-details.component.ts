import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CatDetails } from '../models/CatDetails';
import { CatUpdate } from '../models/CatUpdate';
import { CatService } from '../services/applicationServices/cat.service';
import { FormBuilder, FormGroup } from '@angular/forms';


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
  dataIsAvailable: boolean = false;

  constructor(
    private catService: CatService, 
    private route: ActivatedRoute, 
    private router: Router,
    private fb: FormBuilder) {
      this.getCatId();
      this.initializeCatUpdateForm();
  }

  ngOnInit():void {
    this.catService.getCatById(this.catId).subscribe((catData) => {
      this.cat = catData;
      this.dataIsAvailable = true;
      this.catUpdateForm.controls["description"].setValue(this.cat.description);
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
  
  private initializeCatUpdateForm() {
    this.catUpdateForm = this.fb.group({
      "description": [""]
    });
  }
  
  get description(){
    return this.catUpdateForm.get("description").value;
  }


}
