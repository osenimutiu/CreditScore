import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SetupQualitativesServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-cooperate-score',
  templateUrl: './cooperate-score.component.html',
  styles: [
  ]
})
export class CooperateScoreComponent extends AppComponentBase implements OnInit {
  cooperateDetail:any=[];
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
p:number=1
listCutOff:any = [];
totaScore: number;
totalCutOff: number;
decision:string;
isEligible:string = "Eligible";

constructor(private inj: Injector,
  private _service: SetupQualitativesServiceProxy,
  private route: ActivatedRoute,
  private router: Router) { super(inj)}

  ngOnInit(): void {
    this.getScoreDetail();
  }

  getScoreDetail(){
    this._service.getDetailScores().subscribe(res=>{
      this.cooperateDetail = res;
      this.getCuOff();
    });
  }
// nini
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getCuOff(){
    this._service.getCutOff().subscribe(res=> {
      this.listCutOff = res;
      this.getTotalCutOff();
      this.makeDecision();
    });
  }
    
  getTotalCutOff() {
    let total = 0;
    for (var i = 0; i < this.listCutOff.length; i++) {
        if (this.listCutOff[i].cutOff) {
            total += this.listCutOff[i].cutOff;
            this.totalCutOff = total;

        }
    }
    return total;
  }

  makeDecision(){
    debugger
    for(var i=0; i < this.cooperateDetail.length; i++){
      if(this.cooperateDetail[i].score > this.totalCutOff){
        this.decision = 'Eligible';
      }
      else
      // else{
        this.decision = 'Non Eligible';
      // }
      console.log(this.decision);
    }
  }
}
