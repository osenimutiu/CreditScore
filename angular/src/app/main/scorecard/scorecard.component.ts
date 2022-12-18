import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ScoreCardReportDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-scorecard',
  templateUrl: './scorecard.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScorecardComponent extends AppComponentBase implements OnInit {
listScoreCard: ScoreCardReportDto[] = [];
listDistinct:any= [];
characteristicBin: string = '';
modifiedText: string;
significantResponse: string;
inSignificantResponse: string;
p:number = 1;
totalamount: number;
cutOff:number= 600;
isActive:boolean = false;

  constructor(private injector: Injector,
    private _service: ScoreCardServiceProxy,
    private route: ActivatedRoute,
   private router: Router) {  super(injector)}

  ngOnInit(): void {
    this.getScoreCardReport();
    this.getDictinctXterBin();
  }
  getScoreCardReport(){
    this._service.getScoreCardReport().subscribe(res => {
      this.listScoreCard = res;
    });
  }
  getDictinctXterBin(){
    this._service.getDistinctCharactBins().subscribe(res => {
      this.listDistinct = res;
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  onCharacteristicBinSelected(val:any){
    this.customFunction(val);
    this.Search();
    // this.getSignificancy();
    this.getTotalb();
   }

  customFunction(val:any){
    this.modifiedText = val + " ";
  }
  Search(){
    if(this.characteristicBin != ""){
      this.listScoreCard = this.listScoreCard.filter(res=>{ 
        return res.characteristicBin.toLocaleLowerCase().match(this.characteristicBin.toLocaleLowerCase());
      });
    }else if(this.characteristicBin == ""){
      this.ngOnInit();
    } 
  }

  getTotal(arr){
    return arr.reduce( (sum, curr) => sum + curr.scoreCardPoints,0 );
  }

  getSignificancy(){
    let x = this.listScoreCard.length;
    if(x > 0){
      this.significantResponse = "Significant";
    }
    else{
      this.inSignificantResponse = "Insiginificant";
    }
  }

  getTotalb() {
    this.isActive = true;
    let total = 0;
    for (var i = 0; i < this.listScoreCard.length; i++) {
        if (this.listScoreCard[i].scoreCardPoints) {
            total += this.listScoreCard[i].scoreCardPoints;
            this.totalamount = total;
            if(this.totalamount == this.cutOff || this.totalamount > this.cutOff){
              this.significantResponse = "Accept";
            } else{
              this.inSignificantResponse = "Reject";
            }
        }
    }
    return total;
}
}
