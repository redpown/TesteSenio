import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Pagamento } from '../models/pagamento-model/pagamento';
import { PagamentoService } from '../services/pagamento/pagamento.services';




@Component({
  selector: 'app-pagamento-component',
  templateUrl: './pagamento.component.html',
  
})



export class PagamentoComponent implements OnInit {

//aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public pagamento: Pagamento;
  public pagamentoId: number;
  public returnUrl: string;
  public mensagem: string;


  constructor(private router: Router, private activatedRouter: ActivatedRoute, private service: PagamentoService, private datePipe: DatePipe) {


  }

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.pagamentoId = 0;
    
    //para uso na variavel de templete as variaveis devem estar inicializadas
    this.pagamento = new Pagamento();
    this.pagamento.codigoPagamentoCondominio = 0;
    this.pagamento.nomeCidade = "";
    this.pagamento.estado = "";
    this.pagamento.nomeEdificio = "";
    this.pagamento.andares = 0;
    this.pagamento.numeroAptoAndar = 0 ;
    this.pagamento.metragem = 0;
    this.pagamento.andar = 0;
    this.pagamento.numeroQuartos  = 0;
    this.pagamento.dataPagamento  = "01/01/2021"
    this.pagamento.valorPagamento = null;
  }

  Buscar(id: number) {
    
   
    this.service.getPagamentoById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
            this.pagamento = getJson;
            this.pagamento.dataPagamento = this.datePipe.transform(getJson.dataPagamento, 'yyyy-MM-dd')
            console.log(getJson);
            console.log(this.pagamento);
          } else { console.log("getJson está vazio!")}
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
  
  }

  Atualizar(pagamento: Pagamento) {
   console.log(pagamento);
    this.service.updatePagamento(pagamento)
      .subscribe(
        getJson => {
          getJson = pagamento;
          console.log(getJson);
         
          console.log("Pagamento Atualizado!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );
  }

  Criar(pagamento: Pagamento) {

    this.service.savePagamento(pagamento)
      .subscribe(
        getJson => {
          getJson = pagamento
            console.log(getJson);
          console.log("Pagamento Criado!")
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
