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
  public creatinina: Dashboard[] = [];
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
  //this.setDatas();
  this.carregarDashboard();

  }


  /*
  lineChartData: ChartDataSets[] = [

  { data: [85, 72, 78, 75, 77, 75], label: 'Exame 01' },
  { data: [15, 12, 18, 15, 17, 15], label: 'Exame 02' },
  { data: [25, 22, 28, 25, 27, 25], label: 'Exame 03' },
  { data: [35, 32, 38, 35, 37, 35], label: 'Exame 04' },
  { data: [45, 42, 48, 45, 47, 45], label: 'Exame 05' },
  { data: [55, 52, 58, 55, 57, 55], label: 'Exame 06' },
  { data: [65, 62, 68, 65, 67, 65], label: 'Exame 07' },
  { data: [75, 72, 78, 75, 77, 75], label: 'Exame 08' }
  
];

  public meses: string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];

lineChartLabels: Label[] = [];

lineChartOptions = {
  responsive: true,
};

lineChartColors: Color[] = [
  {
    borderColor: 'rgb(0, 83, 225)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(255, 8, 9)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(255, 8, 255)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(0, 194, 19)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(255, 160, 9)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(0, 225, 225)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(249, 255, 0)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  },
  {
    borderColor: 'rgb(148, 1, 130)',
    backgroundColor: 'rgba(225, 225, 225,0.28)',
  }
];

lineChartLegend = true;
lineChartPlugins = [];
lineChartType: ChartType = "line";

setDatas(){

 // this.lineChartLabels.includes(this.meses);
  this.lineChartData.push({ data: [105, 102, 108, 105, 107, 105], label: 'Exame 10' });

  }
  */

  carregarDashboard() {


      this.dashboardService.GetAllCreatinina()
        .subscribe(
          getJson => {
            this.creatinina = getJson;
            console.log(getJson);
            //console.log("Cidades carregadas!");
          },
          err => {
            console.log(err.error);
            this.mensagem = err.error;

          }
        );

    


  }

  
}
