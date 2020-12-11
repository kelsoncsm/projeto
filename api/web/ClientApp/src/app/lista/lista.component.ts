import { Component, OnInit } from '@angular/core';
import { GeralApiService } from 'src/service/geralApi.services';

@Component({
  selector: 'app-lista-component',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  constructor(private geralApi: GeralApiService) { }


  ngOnInit() {

    this.geralApi.getDadosCovid().subscribe(data => {
      console.log(data)

    }, (error => {
      console.warn(error)
    })
    );
  }

}
