import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Apartamento } from '../models/apartamento-model/apartamento';
import { ApartamentoService } from '../services/apartamento/apartamento.services';



@Component({
  selector: 'app-apartamento-component',
  templateUrl: './apartamento.component.html'
})



export class ApartamentoComponent implements OnInit {

//aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public apartamento: Apartamento = new Apartamento();
  public apartamentoId: number = 0;
  public returnUrl: string = "";
  public mensagem: string = "";


  constructor(private router: Router, private activatedRouter: ActivatedRoute, private service: ApartamentoService) {


  }

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.apartamentoId = 0;
    //para uso na variavel de templete as variaveis devem estar inicializadas
    
    this.apartamento.codigoApartamento = 0;
    this.apartamento.nomeCidade = "";
    this.apartamento.estado = "";
    this.apartamento.nomeEdificio ="";
    this.apartamento.andares = 0;
    this.apartamento.numeroAptoAndar =0 ;
    this.apartamento.metragem = 0;
    this.apartamento.andar = 0;
    this.apartamento.numeroQuartos = 0;
  }

  Buscar(id:number) {

    this.service.getApartamentoById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
            this.apartamento = getJson;
              console.log(getJson);
          } else { console.log("getJson está vazio!")}
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

  Atualizar(apartamento: Apartamento) {
   console.log(apartamento);
    this.service.updateApartamento(apartamento)
      .subscribe(
        getJson => {
          getJson = apartamento;
          console.log(getJson);
         
          console.log("apartamento Atualizado!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );
  }

  Criar(apartamento: Apartamento) {

    this.service.saveApartamento(apartamento)
      .subscribe(
        getJson => {
          getJson = apartamento
            console.log(getJson);
          console.log("apartamento Criado!")
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
