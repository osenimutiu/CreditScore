import { Component, OnInit } from '@angular/core';
import { CurveServiceProxy, TblWoe_AgeDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-woe-age',
  templateUrl: './woe-age.component.html',
  styles: [
  ]
})
export class WoeAgeComponent implements OnInit {
  WOE = [];
  Age = [];
  woe_ageCurve: TblWoe_AgeDto[] = [];
  Linechart:any = [];
  woe_ageTitle: string = 'Age';
  constructor(private _service: CurveServiceProxy) { }

  ngOnInit(): void {
    this.plotAgeWoeCurve();
  }
  plotAgeWoeCurve(){
    this._service.getWoeAge().subscribe(res => { 
       this.woe_ageCurve = res;
       this.woe_ageCurve.forEach(x => {
         this.WOE.push(x.woe);
         this.Age.push(x.age);
       });
       this
       this.Linechart = new Chart('woe_age', {
         type: 'line',
         data: {
           labels: this.Age,
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
