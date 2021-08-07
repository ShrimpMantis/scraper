import { Component, OnInit } from '@angular/core';
import { ScraperService } from '../scraper.service';

@Component({
  selector: 'app-scraper-form',
  templateUrl: './scraper-form.component.html',
  styleUrls: ['./scraper-form.component.css']
})
export class ScraperFormComponent implements OnInit {

  urls:string;
  resultsDictionary:Map<string,string>= new Map();
  showLoading:boolean=false;
  constructor(private service:ScraperService) { }

  ngOnInit() {}

  submitClicked(urls:string){
    console.log("submit Clicked",this.urls);
    this.showLoading= true;
    const urlList= this.urls.trim().split(',');
    const result= this.service.getUrlResult(urlList)
                      .subscribe((results:any)=>{
                          this.showLoading= false;
                          this.resultsDictionary= results;
                      });
    console.log("result", result);
  }


}
