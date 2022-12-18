import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, TblWoe_PaymentPerformanceDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-woe-paymentperformance',
  templateUrl: './woe-paymentperformance.component.html',
  styles: [
  ]
})
export class WoePaymentperformanceComponent implements OnInit {
  WOE = [];
  paymentPerformance = [];
  woe_paymentPerformanceCurve: TblWoe_PaymentPerformanceDto[] = [];
  Linechart:any = [];
  paymentPerformanceTitle: string = 'Payment Performance';
  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotWoe_PaymentPerformanceCurve()
  }

  plotWoe_PaymentPerformanceCurve(){
    this._service.getWoe_PaymentPerformance().subscribe(res => { 
       this.woe_paymentPerformanceCurve = res;
       this.woe_paymentPerformanceCurve.forEach(x => {
         this.WOE.push(x.woe);
         this.paymentPerformance.push(x.paymentPerformance);
       });
       this
       this.Linechart = new Chart('woe_paymentperformanceCurve', {
         type: 'line',
         data: {
           labels: this.paymentPerformance,
           datasets: [
             {
             data: this.WOE,  
             label: 'Weight of Evidence',
             borderColor: '#03adfc',  
             backgroundColor: "#03adfc",
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
