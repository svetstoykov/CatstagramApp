import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CatDetails } from '../models/CatDetails';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-cat-details',
  templateUrl: './cat-details.component.html',
  styleUrls: ['../../styles/formstyle.css'],
})
export class CatDetailsComponent implements OnInit {
  cat: CatDetails;
  catId: string;

  constructor(private catService: CatService, private route: ActivatedRoute) {
    this.route.params.subscribe((url) => {
      this.catId = url['id'];
    });
  }

  ngOnInit():void {
    this.catService.getCatById(this.catId).subscribe((catData) => {
      this.cat = catData;
    });
  }
}
