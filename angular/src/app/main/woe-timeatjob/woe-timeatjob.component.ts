import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, TblWoe_TimeatJobDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-woe-timeatjob',
  templateUrl: './woe-timeatjob.component.html',
  styles: [
  ]
})
export class WoeTimeatjobComponent implements OnInit {
  WOE = [];
  TimeAtJob = [];
  woe_timeatJobCurve: TblWoe_TimeatJobDto[] = [];
  Linechart:any = [];
  woe_timeatJobTitle: string = 'Time at Job';
  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotTimeatJobCurve();
  }

  plotTimeatJobCurve(){
    this._service.getTimeatJob().subscribe(res => { 
       this.woe_timeatJobCurve = res;
       this.woe_timeatJobCurve.forEach(x => {
         this.WOE.push(x.woe);
         this.TimeAtJob.push(x.timeatJob);
       });
       this
       this.Linechart = new Chart('woe_timeatjob', {
         type: 'line',
         data: {
           labels: this.TimeAtJob,
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
