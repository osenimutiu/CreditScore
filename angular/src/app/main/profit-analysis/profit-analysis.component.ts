import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfitAnalysisDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-profit-analysis',
  templateUrl: './profit-analysis.component.html',
  styles: [
  ]
})
export class ProfitAnalysisComponent implements OnInit {
profit: ProfitAnalysisDto[]= [];
CutOff = [];
Profit = [];
Linechart:any = [];
profitAnalysisTitle: string = 'Profit Analysis';
  constructor( private _service: ScoreCardServiceProxy,
    private route: ActivatedRoute,
   private router: Router) { }

  ngOnInit(): void {
    this.getProfitAnalysis()
  }
getProfitAnalysis(){
  this._service.getProfitAnalysis().subscribe(res => {
    this.profit = res;
    this.profit.forEach(x => {
      this.CutOff.push(x.cutOff);
      this.Profit.push(x.profit);
    });
    this
    this.Linechart = new Chart('pofitAnal', {
      type: 'line',
      data: {
        labels: this.CutOff,
        datasets: [
          {
          data: this.Profit,  
          label: 'Profit',
          borderColor: '#32a8a0',  
          backgroundColor: "#32a8a0",
          }
        ]

      },
      options: {  
        // legend: {  
        //   display: true  
        // }, 
        scales: {  
          xAxes: {  
            display: true  
          },  
          yAxes: {  
            display: true  
          },  
        }  
      } 
    });
  });
}


reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
