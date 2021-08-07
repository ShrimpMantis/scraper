import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ScraperService {
  private readonly endPointUrl="http://localhost:55424/api/webScraper";

  constructor(private http: HttpClient) { }

  getUrlResult(urls:string[]){
    let httpParams= new HttpParams();
    httpParams= httpParams.set('returnType','string');
    urls.forEach(url => {
      httpParams= httpParams.append('urls',url);
    });

    let headers= new HttpHeaders();
    headers= headers.set("Access-Control-Allow-Origin","*");
    headers= headers.set("Accept","application/json");
    headers= headers.append("Accept","text/plain");
   
   
    const options={params: httpParams,headers:headers};

     return this.http.get(this.endPointUrl,options)
                       .pipe(
                         map((result:any)=>{
                            console.log("result", result);
                            return result;
                         })
                       );
                  
  }
}
