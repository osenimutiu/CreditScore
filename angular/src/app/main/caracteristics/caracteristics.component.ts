import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CharacteristicsAnalysisDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-caracteristics',
  templateUrl: './caracteristics.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CaracteristicsComponent extends AppComponentBase implements OnInit {
xterList: CharacteristicsAnalysisDto[]=[];
totalamount: number;
devFreq: number;
recFreq: number;
significantResponse: string;
inSignificantResponse: string;
response: string;
attrribute:string;
distList:any=[];
p:number=1
modifiedText: string;
    constructor(private injector: Injector,private _service: ScoreCardServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {super(injector) }

  ngOnInit(): void {
    // this.getXteristics();
    this.getDistAtt();
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

 getXteristics(){
   this._service.getCharacteristicsAnalyses(this.attrribute).subscribe(res => {
     this.xterList = res;
     this.getTotalb();
     this.getFreqDev();
     this.getFreqRec();
   });
 }

   
getTotal(arr){
  return arr.reduce( (sum, curr) => sum + curr.index,0 );
}

getTotalb() {
  let total = 0;
  for (var i = 0; i < this.xterList.length; i++) {
      if (this.xterList[i].index) {
          total += this.xterList[i].index;
          this.totalamount = total;
          if(this.totalamount > 5){
            this.significantResponse = "Significant";
          } else{
            this.inSignificantResponse = "Insiginificant"
          }
      }
  }
  return total;
}

getFreqDev() {
  let total = 0;
  for (var i = 0; i < this.xterList.length; i++) {
      if (this.xterList[i].devFrequency) {
          total += this.xterList[i].devFrequency;
          this.devFreq = total;
      }
  }
  return total;
}
getFreqRec() {
  let total = 0;
  for (var i = 0; i < this.xterList.length; i++) {
      if (this.xterList[i].recFrequency) {
          total += this.xterList[i].recFrequency;
          this.recFreq = total;
      }
  }
  return total;
}

getDistAtt(){
  this._service.getDistinctAttributes().subscribe(r=>{
    this.distList = r;
  })
}

getSelectedItem(val:any){
  this.customFunction(val);
}
 customFunction(val:any){
  this.modifiedText = val + " selected";
  this.getXteristics();
}
}
