import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, GiniCurveDto, KSTestCurveDto, ROCCurveDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-curve',
  templateUrl: './curve.component.html',
  styles: [
  ]
})
export class CurveComponent implements OnInit {
Cumm_Percentage_Good = [];
Cumm_Percentage_Bad = [];

Score = [];
Linechart:any = [];
ksCurve: KSTestCurveDto[] = [];
ksTitle: string = 'Kolmogorov–Smirnov Test';

  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotKSTest();
  }

  plotKSTest(){
   this._service.getKSTest().subscribe(res => {
      this.ksCurve = res;
      this.ksCurve.forEach(x => {
        this.Cumm_Percentage_Good.push(x.cumm_Perc_Good);
        this.Cumm_Percentage_Bad.push(x.cumm_Perc_Bad);
        this.Score.push(x.score);
      });
      this
      this.Linechart = new Chart('ksTest', {
        type: 'line',
        data: {
          labels: this.Score,
          datasets: [
            {
            data: this.Cumm_Percentage_Good, 
            label: 'Cummulative Percentage Good',  
            borderColor: '#0000FF',  
            backgroundColor: "#0000FF",
            },
            {
              data: this.Cumm_Percentage_Bad, 
              label: 'Cummulative Percentage Bad',  
              borderColor: '#a032a8',  
              backgroundColor: "#a032a8",
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
  
  }
