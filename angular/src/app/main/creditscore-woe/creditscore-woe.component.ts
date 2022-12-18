import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreditScoreWOEDto, CurveServiceProxy } from '@shared/service-proxies/service-proxies';
import  Chart  from 'chart.js/auto';

@Component({
  selector: 'app-creditscore-woe',
  templateUrl: './creditscore-woe.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CreditscoreWoeComponent extends AppComponentBase implements OnInit {
distinctList:any=[];
xteristic: string;
WOE = [];
Attributes = [];
creditWoeList: CreditScoreWOEDto[] = [];
p:number=1;
displayTable:boolean;
Linechart:any = [];
modifiedText: string;
  constructor(private injector: Injector,
    private _service: CurveServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {
      super(injector)
     }

  ngOnInit(): void {
    this.getDistinctXteristics()
  }

  getDistinctXteristics(){
    this._service.getDistinctXteristics().subscribe(res => {
      this.distinctList = res;
    });
  }
  // for (let i = 0; i < cars.length; i++) {
  //   text += cars[i] + "<br>";
  // }

  getWOECurve(){
    // this.reload();
    this._service.getCreditScoreWOE(this.xteristic).subscribe(res=>{
      this.creditWoeList = res;
      this.displayTable=true;
      for (let i = 0; i < this.creditWoeList.length; i++) {
        // text += cars[i] + "<br>";
        this.WOE.push(this.creditWoeList[i].woe);
        this.Attributes.push(this.creditWoeList[i].attribute);
      }

      this
      this.Linechart = new Chart('canvas', {
        type: 'line',
        data: {
          labels: this.Attributes,
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

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getSelectedItem(val:any){
    this.customFunction(val);
  }
   customFunction(val:any){
    this.modifiedText = val + " selected";
  }
}
