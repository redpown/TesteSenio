import { ReturnStatement } from '@angular/compiler';
import { Component, OnInit, } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { Dashboard } from '../models/dashboard-model/dashboard';
import { DashboardService } from '../services/dashboard/dashboard.services';

@Component({
  selector: 'app-dashboard-component',
  templateUrl: './dashboard.component.html',
 
})


export  class DashBoardComponent implements OnInit {

//tutorial from https://www.positronx.io/angular-chart-js-tutorial-with-ng2-charts-examples/
//npm install ng2-charts chart.js --save

  public acidoUrico: Dashboard[] = [];
  public creatinina: Dashboard[] =  [];
  public hemograma: Dashboard[] = [];
  public HIV: Dashboard[] = [];
  public LDH: Dashboard[] = [];
  public ureia: Dashboard[] = [];
  public urina1: Dashboard[] = [];
  public mensagem: string = "";



  constructor(private router: Router,
    private activatedRouter: ActivatedRoute,
    private dashboardService: DashboardService) {

  }

ngOnInit() {
  
  this.carregarDashboard();
  //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
  this.setDatas();
  
  }


  
  public lineChartData: ChartDataSets[] = [
  { data: [85, 72, 78, 75, 77, 75], label: 'Exame 01' }
 
  
];

  public meses: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  public lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July','AGoste','Setembre','Outubro','Novembro','Dezembro'];
  public valores: number[] = [];

lineChartOptions = {
  responsive: true,
};
//cores
public lineChartColors: Color[] = [
  {
    borderColor: 'rgb(0, 83, 225)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(255, 8, 9)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(255, 8, 255)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(0, 194, 19)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(255, 160, 9)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(0, 225, 225)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(249, 255, 0)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  },
  {
    borderColor: 'rgb(148, 1, 130)',
    backgroundColor: 'rgba(225, 225, 225,0.00)',
  }
];

lineChartLegend = true;
lineChartPlugins = [];
lineChartType: ChartType = "line";

setDatas(){

 // this.lineChartLabels.includes(this.meses);
 // this.lineChartData.push({ data: [105, 102, 108, 105, 107, 105], label: 'Exame 10' });

  //console.log(this.creatinina[0].mes);

  }
  


  carregarDashboard() {

     this.dashboardService.GetAllHemograma()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.hemograma = getJson;
          this.CarregarDadosDashboard(this.hemograma);
       
         
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.dashboardService.GetAllCreatinina()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.creatinina = getJson;
          this.CarregarDadosDashboard(this.creatinina);

         
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }

    );

    this.dashboardService.GetAllAcidoUrico()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.acidoUrico = getJson;
          this.CarregarDadosDashboard(this.acidoUrico);

        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.dashboardService.GetAllUrina1()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.urina1 = getJson;
          this.CarregarDadosDashboard(this.urina1);


        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.dashboardService.GetAllUreia()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.ureia = getJson;
          this.CarregarDadosDashboard(this.ureia);

        
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.dashboardService.GetAllLDH()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.LDH = getJson;
          this.CarregarDadosDashboard(this.LDH);

        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );

    this.dashboardService.GetAllHIV()
      .subscribe(
        getJson => {
          //se precsio esperar um retorno assincrono, colocar um funcao entro do subscribe
          this.HIV = getJson;
          this.CarregarDadosDashboard(this.HIV);

     
        },
        err => {
          console.log(err.error);
          this.mensagem = err.error;

        }
    );
   

    
   
  }
  CarregarDadosDashboard(obj:Dashboard[]) {
    let val:number[]= [];
    obj.forEach((dado) => {
      if (dado.ano == 2020) {
        //  this.lineChartLabels.push(dado.mes + " - " + dado.ano);
        val.push(dado.total);
      }
    });
    this.lineChartColors.push({
      borderColor: 'rgb(0, 83, 225)',
      backgroundColor: 'rgba(225, 225, 225,0.00)',
    });
    this.lineChartData.push({ data: val, label: obj[0].exame });
    ///removendo o inciador que usei
   // for (var i = 0; i < this.lineChartData.length; i++) {
      if (this.lineChartData[0].label == "Exame 01") {
        this.lineChartData.splice(0, 1);
      }
  //  }

   
    console.log("removendo exame");
    console.log(this.lineChartData);
  }

  /*
  exemplo de de remover em array
function removeItemOnce(arr, value) {
  var index = arr.indexOf(value);
  if (index > -1) {
    arr.splice(index, 1);
  }
  return arr;
}

function removeItemAll(arr, value) {
  var i = 0;
  while (i < arr.length) {
    if (arr[i] === value) {
      arr.splice(i, 1);
    } else {
      ++i;
    }
  }
  return arr;
}
// Usage

*/

  
}
