import { Component, OnInit  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute  } from '@angular/router';
import { CakeService} from '../services/cake.service'
import { Cake } from '../models/cake';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cake-details',
  templateUrl: './cake-details.component.html',
  styleUrls: ['./cake-details.component.css']
})
export class CakeDetailsComponent implements OnInit {
  cakeId: number;
  cake$: Observable<Cake>;

  constructor(private cakeService: CakeService, private router: Router, private avRoute: ActivatedRoute) {
    const idParam = 'id';
    if (this.avRoute.snapshot.params[idParam]) {
      this.cakeId = this.avRoute.snapshot.params[idParam];
    }
  }

  ngOnInit() {
    this.loadCake();
  }

  loadCake(){
    this.cake$ = this.cakeService.getCake(this.cakeId);
  }  
}

