import { Component } from '@angular/core';

@Component({
  selector: 'app-sprankingcondominio-component',
  templateUrl: './sprankingcondominio.component.html'
})
export class SprankingcondominioComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
