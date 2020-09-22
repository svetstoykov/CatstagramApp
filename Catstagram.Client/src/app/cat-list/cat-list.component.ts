import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cat } from '../models/Cat';
import { CatService } from '../services/applicationServices/cat.service';

@Component({
  selector: 'app-list-cats',
  templateUrl: './cat-list.component.html',
  styleUrls: ['./cat-list.component.css']
})
export class CatListComponent implements OnInit {

  cats: Array<Cat>;

  constructor(private catService: CatService, private rounter: Router) { }

  ngOnInit(): void {
    this.getAllUserCats();
  }

  getAllUserCats(){
    this.catService.getCats().subscribe(cats => {
      this.cats = cats;
    })
  }

  routeToCat(id){
    this.rounter.navigate(["cats", id])
  }
}
