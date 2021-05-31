import { Component, OnInit } from '@angular/core';
import { Cake } from '../models/cake';
import { CakeService} from '../services/cake.service'
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cake',
  templateUrl: './cake.component.html',
  styleUrls: ['./cake.component.css']
})
export class CakeComponent implements OnInit  {
  public cakes$: Observable<Cake[]>;

  constructor(private cakeService: CakeService) {
  }

  ngOnInit() {
    this.loadCakes();
  }

  loadCakes() {
    this.cakes$ = this.cakeService.getCakes();
  }
  
}

