import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Title } from "@angular/platform-browser";
import { Usuarios } from '../models/usuario-model/usuarios';
import { SessionService } from '../services/session/session.services';
import { UsuariosService } from '../services/usuario/usuario.services';

@Component({
  selector: 'app-user-login',
  templateUrl: './login.component.html'
})
export class UserLoginComponent implements OnInit {

  public usario: Usuarios;
  public usarios: Usuarios[];
  public showLogin: string | null = 'false';
  @Output('parentFun') parentFun: EventEmitter<any> = new EventEmitter();
  constructor(private titleService: Title, private router: Router, private storageService: SessionService, private usuarioService: UsuariosService) {
    this.usario = new Usuarios();
    this.usarios = new Array();

  }
  public usuario: Usuarios = new Usuarios();
  logar(usuarios: Usuarios): void {

    console.log(usuarios);
    this.usuarioService.validarUsuariosByLogin(usuarios)
      .subscribe(
        getJson => {
          console.log(getJson);
          getJson = this.usuario;
          if (this.usuario.email != '') {
            console.log('Nome de usuario');
            console.log(this.usuario.nome);
            this.storageService.set("isLogado", true);
            this.storageService.set("userName", this.usuario.nome);
            this.parentFun.emit();
          }
         
          
        },
        err => {
          console.log(err.error);
          
        }
      );

    
   
  }



  ngOnInit() {

    //this.storageService.clear();
    this.titleService.setTitle("Eme - Login");
    this.carregarUsuarios();
    console.log('child: login.component')
    //console.log('COMP-login: ');
    //console.log(sessionStorage.getItem('isLogado'));

  }


  

  carregarUsuarios() {
    this.usuarioService.getUsuarios()
      .subscribe(
        getJson => {
          this.usarios = getJson;
          console.log(getJson);
          console.log("Usuarios carregadas!");
        },
        err => {
          console.log(err.error);
          

        }
      );

  }
}
