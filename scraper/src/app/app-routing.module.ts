import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ScraperFormComponent } from './scraper-form/scraper-form.component';


const routes: Routes = [{
  path:'', component:ScraperFormComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
