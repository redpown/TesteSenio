import { HttpClient } from '@angular/common/http';
import { Component, Inject, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from '../models/cidade-model/cidade';
import { CidadeService } from '../services/cidade/cidade.services';

@Component({
  selector: 'app-cidade-component',
  templateUrl: './cidade.component.html'
})



export class CidadeComponent implements OnInit {

//aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public cidade: Cidade = new Cidade();
  public cidadeId: number =0;
  public returnUrl: string = "";
public mensagem: string = "";
  public cidades: Cidade[] =[];
  public msg: string = "";


  constructor(private router: Router, private activatedRouter: ActivatedRoute,
    private cidadeService: CidadeService) {


  }

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.cidadeId = 0;
    //para uso na variavel de templete as variaveis devem estar inicializadas
    this.cidade = new Cidade();
    this.cidade.codigoCidade = 0;
    this.cidade.nomeCidade = "";
    this.cidade.estado = "";
    this.msg = "ola";
    this.carregarCidades();

  }

  Buscar(id:number) {

    this.cidadeService.getCidadeById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
              this.cidade = getJson;
              console.log(getJson);
          } else { console.log("getJson está vazio!")}
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

  Atualizar(cidade:Cidade) {

    this.cidadeService.updateCidade(cidade)
      .subscribe(
        getJson => {
            getJson = this.cidade
            console.log(getJson);
            console.log("Cidade Atualizada!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );
  }

  Criar(cidade: Cidade) {

    this.cidadeService.saveCidade(cidade)
      .subscribe(
        getJson => {
            getJson = this.cidade
            console.log(getJson);
            console.log("Cidade Criada!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
  }

  Deletar(id:number) {

    this.cidadeService.deleteCidade(id)
      .subscribe(
        ()=>console.log("Deletado!")
      );

  }

  carregarCidades() {

    this.cidadeService.getCidades()
      .subscribe(
        getJson => {
          this.cidades = getJson;
          console.log(getJson);
          console.log("Cidades carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

}
