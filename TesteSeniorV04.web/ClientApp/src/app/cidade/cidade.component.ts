import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { Cidade } from '../models/cidade-model/cidade';
import { CidadeService } from '../services/cidade/cidade.services';

@Component({
  selector: 'app-cidade-component',
  templateUrl: './cidade.component.html'
})

@Injectable({
  providedIn: 'root'
})


export class CidadeComponent implements OnInit {
  private baseURL: string;
  cidade = {} as Cidade;
  cidades: Cidade[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
    http.get<Cidade[]>(baseUrl + 'api/tabelacidade').subscribe(result => {
      this.cidades = result;
    }, error => console.error(error));
   
  }
  
  ngOnInit() {
    //this.cidadeService.getCidades();
    console.log(this.baseURL + 'api/tabelacidade');
  }
/*
 getCidades() {
  this.cidadeService.getCidades().subscribe((cidades: Cidade[]) => {
    this.cidades = cidades;
  });
}
  */
}
