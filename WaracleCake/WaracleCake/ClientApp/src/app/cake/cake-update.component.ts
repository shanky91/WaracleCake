import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CakeService} from '../services/cake.service'
import { Cake } from '../models/cake';

@Component({
  selector: 'app-cake-update',
  templateUrl: './cake-update.component.html',
  styleUrls: ['./cake-update.component.css']
})
export class CakeUpdateComponent {
  form: FormGroup;
  errorMessage: any;
  formName: string;
  formComment: string;
  formImageUrl: string;
  formYumFactor: string;

  constructor(private cakeService: CakeService, private formBuilder: FormBuilder, private router: Router) {
    this.formName = 'name';
    this.formComment = 'comment';
    this.formImageUrl = 'imageUrl';
    this.formYumFactor = 'yumFactor';

    this.form = this.formBuilder.group(
      {
        name: ['', [Validators.required]],
        comment: ['', [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(200)]],
        imageUrl: ['', [Validators.required]],
        yumFactor: ['', [
          Validators.required,
          Validators.pattern("^[1-5]*$")]],
      }
    )
  }

  save() {
    if (!this.form.valid) {
      return;
    }


    let cake: Cake = {
      name: this.form.get(this.formName).value,
      comment: this.form.get(this.formComment).value,
      imageUrl: this.form.get(this.formImageUrl).value,
      yumFactor: +(this.form.get(this.formYumFactor).value)
    };

    this.cakeService.saveCake(cake)
      .subscribe((data) => {
        this.router.navigate(['/']);
      },
      (error) => {this.errorMessage = error});
  }

  cancel() {
    this.router.navigate(['/']);
  }

  get name() { return this.form.get(this.formName); }
  get comment() { return this.form.get(this.formComment); }
  get imageUrl() { return this.form.get(this.formImageUrl); }
  get yumFactor() { return this.form.get(this.formYumFactor); }
}

