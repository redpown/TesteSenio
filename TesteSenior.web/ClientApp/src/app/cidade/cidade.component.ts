import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, Injectable, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Cidade } from '../models/cidade-model/cidade';
import { CidadeService } from '../services/cidade/cidade.services';
import { SessionService } from '../services/session/session.services';

@Component({
  selector: 'app-cidade-component',
  templateUrl: './cidade.component.html',
  providers: [NgbModalConfig, NgbModal]
})



export class CidadeComponent implements OnInit {

  @ViewChild('alertas', { read: TemplateRef })
  public templateref: TemplateRef<any> | undefined;
  
  ngAfterViewInit() {
    console.log('ngAfterViewInit', this.templateref?.elementRef);
  }
  
  //aqui só pego o retorno do Observable(q é m array) e jogo no subscribe

  public cidade: Cidade = new Cidade();
  public cidadeId: number[] = [];
  public atencao: number = 0;
  public returnUrl: string = "";
  public checkedBox: boolean = false;
  public mensagem: string = "";
  public cidades: Cidade[] = [];
  public msg: string = "";
  public alerta:any;


  constructor(private router: Router,
    private activatedRouter: ActivatedRoute,
    private cidadeService: CidadeService,
    config: NgbModalConfig,
    private storageService: SessionService,
    private modalService: NgbModal) {
   
    // customize default values of modals used by this component tree
    config.backdrop = 'static';
    config.keyboard = false;
  }

  ngOnInit() {
    this.ngAfterViewInit();
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    //this.cidadeId.push(0);
    //para uso na variavel de templete as variaveis devem estar inicializadas
    this.cidade = new Cidade();
    this.cidade.codigoCidade = 0;
    this.cidade.nomeCidade = "";
    this.cidade.estado = "";
    this.msg = "ola";
    this.carregarCidades();
    this.storageService.set("isLogado", "true");

  }



  Buscar(id: number) {

    this.cidadeService.getCidadeById(id)
      .subscribe(
        getJson => {
          if (getJson != null) {
            this.cidade = getJson;
            console.log(getJson);
          } else { console.log("getJson está vazio!") }
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );

  }

  Atualizar(cidade: Cidade) {

    this.cidadeService.updateCidade(cidade)
      .subscribe(
        getJson => {
          getJson = this.cidade
          console.log(getJson);
          this.ngOnInit();
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
          this.ngOnInit();
          console.log(getJson);
          console.log("Cidade Criada!")
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
      );
  }

  Deletar(id: number) {

    this.cidadeService.deleteCidade(id)
      .subscribe(
        () => {this.ngOnInit()}
      );
      
      this.carregarCidades();
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


  modalEditar(templateID: any,cidadeModal:Cidade) {
    //const modalRef = this.modalService.open(templateID);
   // modalRef.result
    this.modalService.open(templateID);
    //this.cidade = cidadeModal;
    this.cidade = cidadeModal;
    
  }

   modalCriar(templateID: any) {
    this.modalService.open(templateID);
   }

   modalExcluir(templateID: any) {
     console.log(this.cidadeId)
    if(this.cidadeId.length>0){
      this.atencao = 0;
    }
    else{
      this.atencao = 1;
    }
    this.modalService.open(templateID);
   }
   modalExcluirId(templateID: any,id:number) {
    this.cidadeId=[];
    this.cidadeId.push(id); 
    this.modalService.open(templateID);
   }
   modalCancelar(templateID: any) {
    this.modalService.dismissAll();
    this.cidade.Limpar();
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
let vetor:any = this.cidadeId.find(f => f == id);
    if(vetor==id){
      for( var i = 0; i < this.cidadeId.length; i++){ 
    
        if ( this.cidadeId[i] == id) { 
    
          this.cidadeId.splice(i, 1); 
        }
    
      }
    }else{
      this.cidadeId.push(id);   

    }
    console.log("find: "+this.cidadeId.find(f => f == id));
    console.log(this.cidadeId);
   }
   excluirSelecionado(id:number[]){

    for(var i =0;i<id.length;i++){
      this.Deletar(id[i]);
      this.modalService.dismissAll();
    }
    this.cidadeId=[];
  }
   atualizarSelecionado(){
    this.Atualizar(this.cidade)
    this.modalService.dismissAll();
   }
}
