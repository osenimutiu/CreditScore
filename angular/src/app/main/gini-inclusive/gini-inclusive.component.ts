import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { GiniInclusiveDto, GiniInclusiveServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-gini-inclusive',
  templateUrl: './gini-inclusive.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class GiniInclusiveComponent implements OnInit {
  Cumm_Percentage_Defaulters = [];
  Cumm_Percentage_Customers = [];
  Y_Fit = [];
  Linechart:any = [];
  giniInclusive: GiniInclusiveDto[] = [];
  title: string = 'Cummulative Accuracy Profile';
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  constructor(private _service: GiniInclusiveServiceProxy) { }

  ngOnInit(): void {
    this.plotginiInclusive();
  }

  plotginiInclusive(){
   this._service.getGiniInclusives().subscribe(res => {
      this.giniInclusive = res;
      this.giniInclusive.forEach(x => {
        this.Cumm_Percentage_Defaulters.push(x.cumPercDefaulters);
        this.Y_Fit.push(x.y_fit);
        this.Cumm_Percentage_Customers.push(x.cumPercApplicants);
      });
      this
      this.Linechart = new Chart('gini', {
        type: 'line',
        data: {
          labels: this.Cumm_Percentage_Customers,
          datasets: [
            {
            data: this.Cumm_Percentage_Defaulters, 
            label: 'Cummulative Accuracy Profile',  
            borderColor: '#fc9803',  
            backgroundColor: "#fc9803",
            },
            {
              data: this.Y_Fit, 
              label: 'Fitted Curve',  
              borderColor: '#0394fc',  
              backgroundColor: '#0394fc',
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
