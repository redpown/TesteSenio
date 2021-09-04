import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, Injectable, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Generic } from '../models/generic-model/generic';
import { QualidadeMetricas } from '../models/qualidade-metricas-model/qualidade-metricas';
import { GenericoService } from '../services/generico/generico.services';

import { QualidadeMetricasService } from '../services/qualidade-metricas/qualidade-metricas.services';


@Component({
  selector: 'app-qualidademetricas-component',
  templateUrl: './qualidademetricas.component.html',
  providers: [NgbModalConfig, NgbModal]
})



export class QualidadeMetricasComponent implements OnInit {

  @ViewChild('alertas', { read: TemplateRef })
  public templateref: TemplateRef<any> | undefined;
  
  ngAfterViewInit() {
    console.log('ngAfterViewInit', this.templateref?.elementRef);
  }
  
  //aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public exames: Generic[] = [];
  public tipo: Generic[] = [];
  public status: Generic[] = [];
  public coleta: Generic[] = [];
  public qualidadeMetrica: QualidadeMetricas = new QualidadeMetricas();
  public qualidadeMetricasIds: number[] = [];
  public atencao: number = 0;
  public returnUrl: string = "";
  public checkedBox: boolean = false;
  public mensagem: string = "";
  public qualidadeMetricas: QualidadeMetricas[] = [];
  public msg: string = "";
  public alerta:any;


  constructor(private router: Router,
    private activatedRouter: ActivatedRoute,
    private qualidadeMetricasService: QualidadeMetricasService,
    private genericos: GenericoService,
    config: NgbModalConfig,
    private datePipe: DatePipe,
    private modalService: NgbModal) {
   
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit() {
    this.ngAfterViewInit();
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    //this.qualidadeMetricasId.push(0);
    //para uso na variavel de templete as variaveis devem estar inicializadas
    this.qualidadeMetrica = new QualidadeMetricas();
    this.qualidadeMetrica.qmId = 0;
    this.qualidadeMetrica.qmQuantidade = 0;
    this.qualidadeMetrica.qmExameStatusId = 0;
    this.qualidadeMetrica.qmExameId = 0;
    this.qualidadeMetrica.qmTipoExame = 0;
    this.qualidadeMetrica.qmTotal = 0;
    this.qualidadeMetrica.qmData = "";
    this.qualidadeMetrica.qmColetaId = 0;

    this.msg = "ola";
    this.carregarGenericos();
    this.carregarqualidadeMetricass();

  }

  setDescricaoExame(qm: QualidadeMetricas) {
      return this.exames.find(x => x.id == qm.qmExameId)?.descricao;
  }
  setDescricaoStatusExame(qm: QualidadeMetricas) {
    return this.status.find(x => x.id == qm.qmExameStatusId)?.descricao;
  }
  setDescricaoColeta(qm: QualidadeMetricas) {
    return this.coleta.find(x => x.id == qm.qmColetaId)?.descricao;
  }
  setDescricaoTipoExame(qm: QualidadeMetricas) {
    return this.tipo.find(x => x.id == qm.qmTipoExame)?.descricao;
  }


  Buscar(id: number) {

    this.qualidadeMetricasService.getQualidadeMetricasById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
            this.qualidadeMetrica = getJson;
            this.qualidadeMetrica.qmData = this.datePipe.transform(getJson.qmData, 'yyyy-MM-dd')?.toString();
            console.log(getJson);
          } else { console.log("getJson está vazio!") }
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
     
  }

  Atualizar(qualidadeMetricas: QualidadeMetricas) {

    this.qualidadeMetricasService.updateQualidadeMetricas(qualidadeMetricas)
      .subscribe(
        getJson => {
          getJson = this.qualidadeMetrica
          console.log(getJson);
          this.ngOnInit();
          console.log("qualidadeMetricas Atualizada!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
  }

  Criar(CriarQm: QualidadeMetricas) {
  
    console.log("valores Formulario qmColetaId: " + CriarQm.qmColetaId);
    console.log("valores Formulario qmData: " + CriarQm.qmData);
    console.log("valores Formulario qmExameId: " + CriarQm.qmExameId);
    console.log("valores Formulario qmExameStatusId: " + CriarQm.qmExameStatusId);
    console.log("valores Formulario qmTipoExame: " + CriarQm.qmTipoExame);
    console.log("valores Formulario qmTotal: " + CriarQm.qmTotal);
    console.log("valores Formulario qmQuantidade: " + CriarQm.qmQuantidade);
    console.log("valores Formulario qmId: " + CriarQm.qmId);
    console.log("valores Corretos qualidadeMetrica: " + this.qualidadeMetrica);


    this.qualidadeMetricasService.saveQualidadeMetricas(CriarQm)
      .subscribe(
        getJson => {
          getJson = this.qualidadeMetrica
          this.ngOnInit();
          console.log(getJson);
          console.log("qualidadeMetricas Criada!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
      
  }

  Deletar(id: number) {

    this.qualidadeMetricasService.deleteQualidadeMetricas(id)
      .subscribe(
        () => {this.ngOnInit()}
      );
      
      this.carregarqualidadeMetricass();
  }

  carregarqualidadeMetricass() {

    this.qualidadeMetricasService.getQualidadeMetricass()
      .subscribe(
        getJson => {
          this.qualidadeMetricas = getJson;
          console.log(getJson);
          console.log("qualidadeMetricass carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

  carregarGenericos() {

    this.genericos.getColeta()
      .subscribe(
        getJson => {
          this.coleta = getJson;
          console.log(getJson);
          console.log("genericos carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.genericos.getExames()
      .subscribe(
        getJson => {
          this.exames = getJson;
          console.log(getJson);
          console.log("genericos carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.genericos.getExamesStatus()
      .subscribe(
        getJson => {
          this.status = getJson;
          console.log(getJson);
          console.log("genericos carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.genericos.getTipoExames()
      .subscribe(
        getJson => {
          this.tipo = getJson;
          console.log(getJson);
          console.log("genericos carregadas!");
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }


  modalEditar(templateID: any,qualidadeMetricasModal:QualidadeMetricas) {
    //const modalRef = this.modalService.open(templateID);
   // modalRef.result
    this.modalService.open(templateID);
    //this.qualidadeMetricas = qualidadeMetricasModal;
    this.qualidadeMetrica = qualidadeMetricasModal;
    //formatar a data para o input type = data
    this.qualidadeMetrica.qmData = this.datePipe.transform(qualidadeMetricasModal.qmData, 'yyyy-MM-dd')?.toString();
    
  }

   modalCriar(templateID: any) {
    this.modalService.open(templateID);
   }

   modalExcluir(templateID: any) {
     console.log(this.qualidadeMetricasIds)
    if(this.qualidadeMetricasIds.length>0){
      this.atencao = 0;
    }
    else{
      this.atencao = 1;
    }
    this.modalService.open(templateID);
   }
   modalExcluirId(templateID: any,id:number) {
    this.qualidadeMetricasIds=[];
    this.qualidadeMetricasIds.push(id); 
    this.modalService.open(templateID);
   }
   modalCancelar(templateID: any) {
    this.modalService.dismissAll();
    this.qualidadeMetrica.Limpar();
   }
   checkClickTrueFalse(caixa:boolean){
      if(caixa == false){
       
        caixa = true;
        console.log("caixa = true: " +caixa);
        //return null;
      }else{
       
        caixa = false;
        console.log("caixa = false :"+caixa);
        //return true;
     }
       //this.ngOnInit();
      
   }
   checkClick(id:number){
let vetor:any = this.qualidadeMetricasIds.find(f => f == id);
    if(vetor==id){
      for( var i = 0; i < this.qualidadeMetricasIds.length; i++){ 
    
        if ( this.qualidadeMetricasIds[i] == id) { 
    
          this.qualidadeMetricasIds.splice(i, 1); 
        }
    
      }
    }else{
      this.qualidadeMetricasIds.push(id);   

    }
    console.log("find: "+this.qualidadeMetricasIds.find(f => f == id));
    console.log(this.qualidadeMetricasIds);
   }
   excluirSelecionado(id:number[]){

    for(var i =0;i<id.length;i++){
      this.Deletar(id[i]);
      this.modalService.dismissAll();
    }
    this.qualidadeMetricasIds=[];
  }
   atualizarSelecionado(){
    this.Atualizar(this.qualidadeMetrica)
    this.modalService.dismissAll();
  }
  setStatusExame() {
    console.log("set Status Exame: " + this.qualidadeMetrica.qmExameStatusId);
  }
  setColeta() {
    console.log("set Coleta: " + this.qualidadeMetrica.qmColetaId);
  }
  setTipoExame() {
    console.log("set Tipo Exame: " + this.qualidadeMetrica.qmTipoExame);
  }
  setExame() {
    console.log("set Exame: " + this.qualidadeMetrica.qmExameId);
   
  }
}

