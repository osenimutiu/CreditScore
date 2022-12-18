import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SeverityServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-severity',
  templateUrl: './severity.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SeverityComponent extends AppComponentBase implements OnInit {
param1: number;
param2: number;
param3: number;
param4: number;
param5: number;
param6: number;
param8: number;
param9: number;
param10: number;
param11: number;
param12: number;
param13: number;
param14: number;
param15: number;
param16: number;
param17: number;
param18: number;
param19: number;
param20: number;
param21: number;
param22: number;
param23: number;
param24: number;
param25: number;
param26: number;
param27: number;
param28: number;
param29: number;
param30: number;
param31: number;
param32: number;
param33: number;
param34: number;
param35: number;
param36: number;
// param37: number;
param38: number;
param39: number;
param40: number;
param41: number;
param42: number;

saving:boolean;


  constructor(private inj: Injector,
    private _service: SeverityServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { 
      super(inj);
    }

  ngOnInit(): void {
    this.getUpdatedSeverity();
  }

getUpdatedSeverity(){
this._service.getUpdatedSeverity().subscribe(res=> {
this.param1 = res.param1;
this.param2 = res.param2;
this.param3 = res.param3;
this.param4 = res.param4;
this.param5 = res.param5;
this.param6 = res.param6;
this.param8 = res.param8;
this.param9 = res.param9;
this.param10 = res.param10;
this.param11 = res.param11;
this.param12 = res.param12;
this.param13 = res.param13;
this.param14 = res.param14;
this.param15 = res.param15;
this.param16 = res.param16;
this.param17 = res.param17;
this.param18 = res.param18;
this.param19 = res.param19;
this.param20 = res.param20;
this.param21 = res.param21;
this.param22 = res.param22;
this.param23 = res.param23;
this.param24 = res.param24;
this.param25 = res.param25;
this.param26 = res.param26;
this.param27 = res.param27;
this.param28 = res.param28;
this.param29 = res.param29;
this.param30 = res.param30;
this.param31 = res.param31;
this.param32 = res.param32;
this.param33 = res.param33;
this.param34 = res.param34;
this.param35 = res.param35;
this.param36 = res.param36;
// this.param37 = res.param37;
this.param38 = res.param38;
this.param39 = res.param39;
this.param40 = res.param40;
this.param41 = res.param41;
this.param42 = res.param42;
});
}

postBanAcc(){
  this.saving = true;
  this._service.postBDS(this.param1,this.param2,this.param3,this.param4,this.param5,this.param6).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}

postCreditLine(){
  this.saving = true;
  this._service.postCLEDS(this.param8,this.param9,this.param10,this.param11,this.param12,this.param13).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}

postFinancials(){
  this.saving = true;
  this._service.postFDS(this.param14,this.param15,this.param16).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}

postFraudCheck(){
  this.saving = true;
  this._service.postFCDS(this.param17,this.param18,this.param19,this.param20,this.param21).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}

postNonFinancialRisk(){
  this.saving = true;
  this._service.postNFRDS(this.param22,this.param23).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}

postCreditBureau(){
  this.saving = true;
  this._service.cBDS(this.param24,this.param25,this.param26,this.param27,this.param28,this.param29,this.param30,
    this.param31,this.param32,this.param33,this.param34,this.param35,this.param36,
    // this.param37,
    this.param38,this.param39,
    this.param40,this.param41,this.param42).subscribe(()=>{
    this.notify.success(this.l('Saved Successfully'));
    this.saving = false;
    
  });
}



reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
