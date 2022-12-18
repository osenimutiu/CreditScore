import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';
import { forEach } from 'lodash';

@Component({
  selector: 'app-retail-score-details',
  templateUrl: './retail-score-details.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class RetailScoreDetailsComponent extends AppComponentBase implements OnInit {
retailDetail:any=[];
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
p:number=1
listCutOff:any = [];
totaScore: number;
totalCutOff: number;
decision:string;
isEligible:string = "Eligible";

constructor(private inj: Injector,
  private _service: DemoRetailServiceProxy,
  private route: ActivatedRoute,
  private router: Router) { super(inj)}

  ngOnInit(): void {
    this.getScoreDetail();
    // this.getCuOff();
  }
  getScoreDetail(){
    this._service.getDetailScores().subscribe(res=>{
      this.retailDetail = res;
  // 
      // this.retailDemoList.forEach(x => {
      //   if(x.position < 40){
      //     this.isEditable = true;
      //   }
      // });
      // 
      this.getCuOff();
    });
  }
  
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
            // if(this.totalCutOff == this.totalWeighted || this.totalCutOff < this.totalWeighted ){
            //   this.decision = 'Eligible';
            // }else{
            //   this.decision = 'Ineligible';
            // }

        }
    }
    return total;
  }

  makeDecision(){
    debugger
    for(var i=0; i < this.retailDetail.length; i++){
      if(this.retailDetail[i].score > this.totalCutOff){
        this.decision = 'Eligible';
      }
      else
      // else{
        this.decision = 'Non Eligible';
      // }
      console.log(this.decision);
    }
  
  // this.retailDetail.forEach(x=>{
  //   debugger
  //   if(x.score > this.totalCutOff){
  //     this.decision = 'Eligible';
  //   }
  //   else{
  //     this.decision = 'Non Eligible';
  //   }
  // });

}



approve(id: number){
  this.message.confirm(
      '',
      this.l('Are you sure to Approve?'),
      (isConfirmed) => {
          if (isConfirmed) {
            var param = 'Approved';
              this._service.updateStatus(id,param)
              .subscribe(() => {
                      this.message.success(this.l('Successfully Approved'));
                      _.remove(this.listCutOff, id);
                      this.getScoreDetail();
                  });
          }
      }
  );
}

decline(id: number){
  this.message.confirm(
      '',
      this.l('Are you sure to Decline?'),
      (isConfirmed) => {
          if (isConfirmed) {
            var param = 'Declined';
              this._service.updateStatus(id,param)
              .subscribe(() => {
                      this.message.success(this.l('Successfully Declined'));
                      _.remove(this.listCutOff, id);
                      this.getScoreDetail();
                  });
          }
      }
  );
}
}
