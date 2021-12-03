import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AfterViewInit, Component, Input, ViewChild } from '@angular/core';
import { UserLoginComponent } from './login/login.component';
import { Title } from "@angular/platform-browser";
import { Router } from '@angular/router'
import { SessionService } from './services/session/session.services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements AfterViewInit {
  [x: string]: any;

  @ViewChild(UserLoginComponent)
  child!: UserLoginComponent;

  title = 'login';

  public VerifyLogin: string | null = 'false';
  //public VerifyLogin: boolean = false;
  public logado: string = '';
  constructor(private titleService: Title,private session: SessionService,private router: Router) {

  }
  ngOnInit() {
    this.session.set('isLogado','false');
    this.VerifyLogin ='false'
      this.showMenu();
  }

  showMenu() {
    //while (!this.VerifyLogin) {
    //  console.log('---------Menu-----------');
    this.VerifyLogin = this.session.get("isLogado");
    console.log('Comp App: -----------');
    console.log(this.VerifyLogin);
    //if(this.VerifyLogin){this.ngOnInit()}

    //}
  }
 setSessionLogin(){
if(this.VerifyLogin=='false'){
  this.VerifyLogin ='true';
}else{
  this.VerifyLogin ='false';
}
console.log(this.VerifyLogin);
 }
  ngAfterViewInit() {
    //this.child.ngOnInit();
  }

  parentFun(){
    if(this.VerifyLogin=='false'){
      this.VerifyLogin ='true';
    }else{
      this.VerifyLogin ='false';
    }
    this.router.navigateByUrl("metricas-de-qualidade");
  }

  Loginout(){

      this.VerifyLogin ='false';
      this.titleService.setTitle("Eme - Login");
      this.router.navigateByUrl("login");

    }

}

