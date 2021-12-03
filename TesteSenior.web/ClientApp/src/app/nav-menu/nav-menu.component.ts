import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { SessionService } from '../services/session/session.services';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  public userName: string = 'teste';
  @Output('Logout') Logout: EventEmitter<any> = new EventEmitter();

  constructor(private session: SessionService) {

  }
  public showMenu: boolean = this.session.get("isLogado");
  ngOnInit() {
  this.userName = this.session.get("userName");
    this.showMenu = this.session.get("isLogado");
    console.log('Comp NavMenu: ');
    console.log(this.userName);
    console.log(this.session.get("userName"));

  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }
  status() {
    console.log('Comp nave-menu');
    console.log(sessionStorage.getItem('isLogado'));

  }

Sair(){

  this.Logout.emit();
}
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
