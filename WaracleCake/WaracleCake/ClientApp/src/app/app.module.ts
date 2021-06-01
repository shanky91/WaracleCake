import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CakeComponent } from './cake/cake.component';
import { CakeService } from './services/cake.service';
import { CakeUpdateComponent } from './cake/cake-update.component';
import { CakeDetailsComponent } from './cake/cake-details.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CakeComponent,
    CakeUpdateComponent,
    CakeDetailsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'cake', component: CakeComponent },
      { path: 'cake/:id', component: CakeDetailsComponent },
      { path: 'add', component: CakeUpdateComponent },
    ]),
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [
    CakeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
