import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { UsuariosService } from "../services/usuario/usuario.services";

@Injectable({
  providedIn: 'root'
})
//permite injetar pelo construtor em qualquer classe
export class RouteGuard implements CanActivate {
  //com o @Injectable ele permite instanciar o objeto router ja intanciado tipo Tentity da classe que ele sera usado
  //com o @Injectable ele deixa essas classe global permitindo o  constructor(private guardaRotas: GuardaRotas) { }
  constructor(private router: Router, private usuarioservico: UsuariosService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    //this.usuarioservico
    var autenticado = sessionStorage.getItem("perfil");

    if (autenticado == null || autenticado == '' ) {
      this.router.navigate(['/login']);
      return false;
    }else{
      return true;
    } 
    return false;
  }
}
