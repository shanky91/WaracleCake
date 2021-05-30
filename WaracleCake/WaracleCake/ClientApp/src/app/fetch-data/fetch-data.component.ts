import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {
  public cakes: Cake[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Cake[]>(baseUrl + 'api/cakes').subscribe(result => {
      this.cakes = result;
    }, error => console.error(error));
  }
}

interface Cake {
  id: number;
  name: string;
  comment: string;
  imageUrl: string;
  yumFactor: number;
}
