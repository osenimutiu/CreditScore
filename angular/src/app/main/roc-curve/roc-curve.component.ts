import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, ROCCurveDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';


@Component({
  selector: 'app-roc-curve',
  templateUrl: './roc-curve.component.html',
  styles: [
  ]
})
export class RocCurveComponent implements OnInit {
  True_Positive_Rate = [];
  False_Positive_Rate = [];
  Area = [];
  CutOff = [];
  rocCurve: ROCCurveDto[] = [];
  Linechart:any = [];
  rocTitle: string = 'ROC Curve';

  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotROCCurve();
  }

  plotROCCurve(){
    this._service.getROC().subscribe(res => {
       this.rocCurve = res;
       this.rocCurve.forEach(x => {
         this.True_Positive_Rate.push(x.true_positive);
         this.False_Positive_Rate.push(x.false_positive);
         this.CutOff.push(x.cuttOff);
         this.Area.push(x.area);
       });
       this
       this.Linechart = new Chart('rocCurve', {
         type: 'line',
         data: {
           labels: this.False_Positive_Rate,
           datasets: [
             {
             data: this.True_Positive_Rate,  
             label: 'True Positive Rate',
             borderColor: '#a86d32',  
             backgroundColor: "#a86d32",
             }
             // {
             // data: this.True_Positive_Rate, 
             // label: 'False Positive Count', 
             // borderColor: '#32a8a0',  
             // backgroundColor: "#32a8a0",
             // }
           ]
 
         },
         options: {  
          //  legend: {  
          //    display: false  
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
