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
import { QualidadeMetricasComponent } from './qualidademetricas/qualidademetricas.component';
import { QualidadeMetricasService } from './services/qualidade-metricas/qualidade-metricas.services';
import { GenericoService } from './services/generico/generico.services';
import { ChartsModule } from 'ng2-charts';
import { DashBoardComponent } from './dashboard/dashboard.component';
import { NgxPaginationModule } from 'ngx-pagination';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CidadeComponent,
    EdificioComponent,
    PagamentoComponent,
    ApartamentoComponent,
    QualidadeMetricasComponent,
    SPRankingCondominioComponent,
    DashBoardComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ChartsModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'apartamento', component: ApartamentoComponent },
      { path: 'edificio', component: EdificioComponent },
      { path: 'cidade', component: CidadeComponent },
      { path: 'pagamento', component: PagamentoComponent },
      { path: 'metricas-de-qualidade', component: QualidadeMetricasComponent },
      { path: 'dashboard', component: DashBoardComponent },
      { path: 'Ranking-Condominio', component: SPRankingCondominioComponent }
      
    ])
  ],
  providers: [CidadeService, EdificioService, ApartamentoService, PagamentoService, SPRankingCondominioService,
    QualidadeMetricasService, GenericoService,
    DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
