import { Component } from '@angular/core';

@Component({
  selector: 'app-apartamento-component',
  templateUrl: './apartamento.component.html'
})
export class ApartamentoComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
