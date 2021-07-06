import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cidade } from '../models/cidade-model/cidade';
import { CidadeService } from '../services/cidade/cidade.services';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  //aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public cidades: Cidade[];
  public msg: string;
  public returnUrl: string;
  public mensagem: string;

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.msg = "ola";
    this.carregarCidades();

  }

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private cidadeService: CidadeService) {
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
