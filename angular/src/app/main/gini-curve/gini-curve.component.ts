import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, GiniCurveDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-gini-curve',
  templateUrl: './gini-curve.component.html',
  styles: [
  ]
})
export class GiniCurveComponent implements OnInit {
  Cumm_Number_Defaulters = [];
  Cumm_Number_Customers = [];
  giniCurve: GiniCurveDto[] = [];
  Linechart:any = [];
  giniTitle: string = 'Gini Curve';
  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotGiniCurve();
  }
  plotGiniCurve(){
    this._service.getGiniCurve().subscribe(res => { 
       this.giniCurve = res;
       this.giniCurve.forEach(x => {
         this.Cumm_Number_Defaulters.push(x.cumm_Perc_Defaulters);
         this.Cumm_Number_Customers.push(x.cumm_Perc_Customers);
       });
       this
       this.Linechart = new Chart('giniCurve', {
         type: 'line',
         data: {
           labels: this.Cumm_Number_Customers,
           datasets: [
             {
             data: this.Cumm_Number_Defaulters,  
             label: 'Cummulative Number of Defaulters',
             borderColor: '#32a8a0',  
             backgroundColor: "#32a8a0",
             }
           ]
 
         },
         options: {  
          //  legend: {  
          //    display: true  
          //  }, 
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
