import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SPRankingCondominio } from '../models/sprankingcondominio-model/sprankingcondominio';
import { SPRankingCondominioService } from '../services/sprankingcondominio/sprankingcondominio.services';



@Component({
  selector: 'app-sprankingcondominio-component',
  templateUrl: './sprankingcondominio.component.html',
})
export class SPRankingCondominioComponent implements OnInit {
  //aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public spRankingCondominio: SPRankingCondominio[];
  public msg: string;
  public returnUrl: string;
  public mensagem: string;

  ngOnInit() {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.msg = "ola";
    this.carregarSPRankingCondominio();

  }

  constructor(private router: Router, private activatedRouter: ActivatedRoute, private spRankingCondominioService: SPRankingCondominioService) {
    }

  carregarSPRankingCondominio() {

    this.spRankingCondominioService.getSPRankingCondominios()
      .subscribe(
        getJson => {
          this.spRankingCondominio = getJson;
          console.log('data');
          console.log(this.spRankingCondominio);
          console.log("SPRankingCondominio carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

}
