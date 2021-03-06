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
import { Dashboard } from './models/dashboard-model/dashboard';
import { DashboardService } from './services/dashboard/dashboard.services';
import { UserLoginComponent } from './login/login.component';
import { SessionService } from './services/session/session.services';
import { UsuariosService } from './services/usuario/usuario.services';
import { RouteGuard } from './routeguard/routeguard';




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
    DashBoardComponent,
    UserLoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ChartsModule,
    NgxPaginationModule,
    RouterModule.forRoot([
      { path: 'login', component: AppComponent },
      { path: 'apartamento', component: ApartamentoComponent, canActivate: [RouteGuard]  },
      { path: 'edificio', component: EdificioComponent, canActivate: [RouteGuard]  },
      { path: 'cidade', component: CidadeComponent, canActivate: [RouteGuard]  },
      { path: 'pagamento', component: PagamentoComponent, canActivate: [RouteGuard]  },
      { path: 'metricas-de-qualidade', component: QualidadeMetricasComponent, canActivate: [RouteGuard] },
      { path: 'dashboard', component: DashBoardComponent, canActivate: [RouteGuard] },
      { path: 'Ranking-Condominio', component: SPRankingCondominioComponent, canActivate: [RouteGuard]  }

    ])
  ],
  providers: [CidadeService, EdificioService, ApartamentoService, PagamentoService, SPRankingCondominioService,
    QualidadeMetricasService, GenericoService, DashboardService, SessionService,UsuariosService,
    DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
