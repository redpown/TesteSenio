import { Component } from '@angular/core';

@Component({
  selector: 'app-pagamento-component',
  templateUrl: './pagamento.component.html'
})
export class PagamentoComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
