import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common'; 

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CidadeComponent } from './cidade/cidade.component';
import { ApartamentoComponent } from './apartamento/apartamento.component';
import { PagamentoComponent } from './pagamento/pagamento.component';
import { EdificioComponent } from './edificio/edificio.component';
import { CidadeService } from './services/cidade/cidade.services';
import { EdificioService } from './services/edificio/edificio.services';
import { ApartamentoService } from './services/apartamento/apartamento.services';
import { PagamentoService } from './services/pagamento/pagamento.services';
import { SPRankingCondominioService } from './services/sprankingcondominio/sprankingcondominio.services';
import { SPRankingCondominioComponent } from './sprankingcondominio/sprankingcondominio.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CidadeComponent,
    EdificioComponent,
    PagamentoComponent,
    ApartamentoComponent,
    SPRankingCondominioComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'apartamento', component: ApartamentoComponent },
      { path: 'edificio', component: EdificioComponent },
      { path: 'cidade', component: CidadeComponent },
      { path: 'pagamento', component: PagamentoComponent },
      { path: 'Ranking-Condominio', component: SPRankingCondominioComponent }
    ])
  ],
  providers: [CidadeService, EdificioService, ApartamentoService, PagamentoService, SPRankingCondominioService,
    DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
