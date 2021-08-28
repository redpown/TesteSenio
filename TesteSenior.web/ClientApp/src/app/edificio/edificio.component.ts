import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Edificio } from '../models/edificio-model/edificio';
import { EdificioService } from '../services/edificio/edificio.services';


@Component({
  selector: 'app-edificio-component',
  templateUrl: './edificio.component.html'
})



export class EdificioComponent implements OnInit {

//aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public edificio: Edificio = new Edificio() ;
  public edificioId: number = 0;
  public returnUrl: string ="";
  public mensagem: string ="";


  constructor(private router: Router, private activatedRouter: ActivatedRoute, private service: EdificioService) {


  }

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.edificioId = 0;
    //para uso na variavel de templete as variaveis devem estar inicializadas
   
    this.edificio.codigoEdificio = 0;
    this.edificio.andares = 0;
    this.edificio.numeroAptoAndar = 0;
    this.edificio.estado = "";
    this.edificio.nomeCidade = "";
    this.edificio.nomeEdificio = "";
  }

  Buscar(id:number) {

    this.service.getEdificioById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
              this.edificio = getJson;
              console.log(getJson);
          } else { console.log("getJson está vazio!")}
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

  Atualizar(edifcio: Edificio) {

    this.service.updateEdificio(edifcio)
      .subscribe(
        getJson => {
            getJson = this.edificio
            console.log(getJson);
          console.log("edificio Atualizado!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );
  }

  Criar(edifcio: Edificio) {

    this.service.saveEdificio(edifcio)
      .subscribe(
        getJson => {
            getJson = this.edificio
            console.log(getJson);
            console.log("edificio Criado!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
  }

  Deletar(id:number) {

    this.service.deleteEdificio(id)
      .subscribe(
        ()=>console.log("Deletado!")
      );

  }
}
