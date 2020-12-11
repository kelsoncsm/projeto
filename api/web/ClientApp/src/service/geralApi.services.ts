
import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";


@Injectable({
  providedIn: "root",
})
export class GeralApiService {


  numberChars = new RegExp('[^0-9]', 'g');
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(private http: HttpClient) { }

  getDadosCovid(): Observable<any[]> {
     return this.http.get<any[]>('https://localhost:44383/api/getList');


    // return this.http.get<any[]>('https://api.covid19api.com/summary');

  }

  

}
