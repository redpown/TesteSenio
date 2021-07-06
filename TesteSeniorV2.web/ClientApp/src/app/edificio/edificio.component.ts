import { Component } from '@angular/core';

@Component({
  selector: 'app-edificio-component',
  templateUrl: './edificio.component.html'
})
export class EdificioComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
