import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserSearch } from '../models/UserSearch';
import { SearchService} from '../services/applicationServices/search.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchForm: FormGroup
  searchResults: Array<UserSearch>

  constructor(private fb: FormBuilder, private router: Router, private searchService: SearchService) {
    this.searchForm = this.fb.group({
      "username": ["", Validators.required]
    })

   }

  ngOnInit(): void {
  }
  
  get username() {
    return this.searchForm.get("username").value;
  }

  getSearchResults(){
    this.searchService
      .search(this.username)
      .subscribe(userResults => this.searchResults = userResults)
  }

}
