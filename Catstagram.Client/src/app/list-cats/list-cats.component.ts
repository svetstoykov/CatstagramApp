import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cat } from '../models/Cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-list-cats',
  templateUrl: './list-cats.component.html',
  styleUrls: ['./list-cats.component.css']
})
export class ListCatsComponent implements OnInit {

  cats: Array<Cat>;

  constructor(private catService: CatService, private rounter: Router) { }

  ngOnInit(): void {
    this.catService.getCats().subscribe(cats => {
      this.cats = cats;
    })
  }

  routeToCat(id){
    this.rounter.navigate(["cats", id])
  }

}
