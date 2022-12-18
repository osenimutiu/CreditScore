import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CalibrationCDto, GiniInclusiveServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-caliberation-bar',
  templateUrl: './caliberation-bar.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CaliberationBarComponent implements OnInit {
pDs = [];
Rating = [];
Barchart:any = [];
caliberations: CalibrationCDto[] = [];
title: string = 'Probability of Default (PDs)';
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  constructor(private _service: GiniInclusiveServiceProxy) { }

  ngOnInit(): void {
    this.plotCaliberation();
  }

  plotCaliberation(){
   this._service.getCalibrations().subscribe(res => {
      this.caliberations = res;
      this.caliberations.forEach(x => {
        this.pDs.push(x.percPD_Odds);
        this.Rating.push(x.rating);
      });
      this
      this.Barchart = new Chart('cal', {
        type: 'bar',
        data: {
          labels: this.Rating,
          datasets: [
            {
            data: this.pDs, 
            label: 'PDs',  
            borderColor: '#0394fc',  
            backgroundColor: "#0394fc",
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
