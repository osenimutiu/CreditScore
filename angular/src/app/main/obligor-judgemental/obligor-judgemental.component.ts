import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { Createtbl_scoreDto, LegalDto, OwnershipDto, PositionInIdustryDto, ProductContDto, QualitativeAnalysisServiceProxy, RiskRatingItemDto } from '@shared/service-proxies/service-proxies';
// import { QualitativeAnalysisServiceProxy, RiskRatingDto } from '@shared/service-proxies/service-proxies';
import Stepper from 'bs-stepper';
// import { RiskRatingDto, RiskRatingServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
  selector: 'app-obligor-judgemental',
  templateUrl: './obligor-judgemental.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ],
  // styleUrls: ['/style.css']
})
export class ObligorJudgementalComponent extends AppComponentBase implements OnInit {
  // riskRatings: RiskRatingDto[] = [];
  positions: RiskRatingItemDto[] = [];
  ownership: RiskRatingItemDto[] = [];
  prodConc: RiskRatingItemDto[] = [];
  legal: RiskRatingItemDto[] = [];
  // positions: PositionInIdustryDto[] = [];
  // ownership: OwnershipDto[] = [];
  // prodConc: ProductContDto[] = [];
  // legal: LegalDto[] = [];
  industrial: RiskRatingItemDto[] = [];
  management: RiskRatingItemDto[] = [];
  yearBus: RiskRatingItemDto[] = [];
  clientConc: RiskRatingItemDto[] = [];
  totScore: Createtbl_scoreDto = new Createtbl_scoreDto();
  radioSelected:number;
  radioSel:any;
  posValue:number;
  radioSelectedString:any; 

  radioOwnSelected:number;
  radioOwnSel:any;
  ownValue:number;
  radioOwnSelectedString:any;
  
  radioProSelected:number;
  radioProSel:any;
  proValue:number;
  radioProSelectedString:any; 


  radioLegalSelected:number;
  radioLegalSel:any;
  legalValue:number;
  radioLegalSelectedString:any; 


  radioIndustrialSelected:number;
  radioIndustrialSel:any;
  industrialValue:number;
  radioIndustrialSelectedString:any; 


  radioManagementSelected:number;
  radioManagementSel:any;
  managementValue:number;
  radioManagementSelectedString:any; 


  radioYearBusSelected:number;
  radioYearBusSel:any;
  yearBusValue:number;
  radioYearBusSelectedString:any; 


  radioClientConcSelected:number;
  radioClientConcSel:any;
  clientConcValue:number;
  radioClientConcSelectedString:any; 
  radioTotalSelected:number


  p:number = 1;
  totalScore: number;
  private stepper: Stepper;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  constructor(
    private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(inj);
  }
  ngOnInit(): void {
    // this.getRiskRating();
    this.bsInitialization();
    // this.getScore();
    this.getPosRiskRatItem();
    this.getOwnershipRiskRatItem();
    this.getProdConcRiskRatItem();
    this.getLegalItem();
    this.getIndustrialItem();
    this.getManagementItem();
    this.getYearInBusItem();
    this.getClientConcItem();
  }
 
// getScore(){
//   this._service.obtainOption().subscribe(()=>{
//   });
//   this.getProdIndustry();
//   this.getOwnership();
//   this.getProdCon();
//   this.getLegal();
// }

// getProdIndustry(){
// this._service.getPositionInIdustry().subscribe(res=>{
//   this.positions = res;
// });
// }
// getOwnership(){
// this._service.getOwnership().subscribe(res=>{
//   this.ownership = res;
// });
// }
// getProdCon(){
// this._service.getProductCont().subscribe(res=>{
//   this.prodConc = res;
// });
// }
// getLegal(){
// this._service.getLegal().subscribe(res=>{
//   this.legal = res;
// });
// }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  
  next() {
    this.stepper.next();
  }
  previous() {
    this.stepper.previous();
  }
  bsInitialization() {
    this.stepper = new Stepper(document.querySelector('.bs-stepper'), {
      linear: true,
      animation: true
    })
  }

 
  getPosRiskRatItem(){
    this._service.getRiskRatingItem('Position in industry/Market share').subscribe(res=>{
          this.positions = res;
        });
  }
  getOwnershipRiskRatItem(){
    this._service.getRiskRatingItem('Ownership').subscribe(res=>{
          this.ownership = res;
        });
  }
  getProdConcRiskRatItem(){
    this._service.getRiskRatingItem('Product Concentration').subscribe(res=>{
          this.prodConc = res;
        });
  }
  getLegalItem(){
    this._service.getRiskRatingItem('Legal and regulatory environment').subscribe(res=>{
          this.legal = res;
        });
  }
  getIndustrialItem(){
    this._service.getRiskRatingItem('Industrial Cyclicality').subscribe(res=>{
          this.industrial = res;
        });
  }
  getManagementItem(){
    this._service.getRiskRatingItem('Management').subscribe(res=>{
          this.management = res;
        });
  }
  getYearInBusItem(){
    this._service.getRiskRatingItem('Years in business').subscribe(res=>{
          this.yearBus = res;
        });
  }
  getClientConcItem(){
    this._service.getRiskRatingItem('Client concentration').subscribe(res=>{
          this.clientConc = res;
        });
  }

  onPosChange(item:any){
    this.getSelecteditem();
  }
  
  getSelecteditem(){
    this.radioSel = this.positions.find(Item => Item.score === this.radioSelected);
    this.radioSelectedString = JSON.stringify(this.radioSel);
    this.posValue = this.radioSelected;
  }
  onOwnChange(own:any){
    this.getOwnSelecteditem();
  }
  
  getOwnSelecteditem(){
    this.radioOwnSel = this.ownership.find(Item => Item.score === this.radioOwnSelected);
    this.radioOwnSelectedString = JSON.stringify(this.radioOwnSel);
    this.ownValue = this.radioOwnSelected;
  }
  onProdConcChange(item){
    this.getProSelecteditem();
  }
  
  getProSelecteditem(){
    this.radioProSel = this.prodConc.find(Item => Item.score === this.radioProSelected);
    this.radioProSelectedString = JSON.stringify(this.radioProSel);
    this.proValue = this.radioProSelected;
  }
  onLegalChange(leg){
    this.getLegalSelecteditem();
  }
  
  getLegalSelecteditem(){
    this.radioLegalSel = this.legal.find(Item => Item.score === this.radioLegalSelected);
    this.radioLegalSelectedString = JSON.stringify(this.radioLegalSel);
    this.legalValue = this.radioLegalSelected;
  }
  onIndustrialChange(ind){
    this.getIndustrialSelecteditem();
  }

  
  getIndustrialSelecteditem(){
    this.radioIndustrialSel = this.industrial.find(Item => Item.score === this.radioIndustrialSelected);
    this.radioIndustrialSelectedString = JSON.stringify(this.radioIndustrialSel);
    this.industrialValue = this.radioIndustrialSelected;
  }
  onManagementChange(item){
    this.getManagementSelecteditem();
  }
  
  getManagementSelecteditem(){
    this.radioManagementSel = this.management.find(Item => Item.score === this.radioManagementSelected);
    this.radioManagementSelectedString = JSON.stringify(this.radioManagementSel);
    this.managementValue = this.radioManagementSelected;
  }
  onYearBusChange(item){
    this.getYearBusSelecteditem();
  }
  
  getYearBusSelecteditem(){
    this.radioYearBusSel = this.yearBus.find(Item => Item.score === this.radioYearBusSelected);
    this.radioYearBusSelectedString = JSON.stringify(this.radioYearBusSel);
    this.yearBusValue = this.radioYearBusSelected;
  }
  onClientConcChange(item){
    this.getClientConcSelecteditem();
  }
  
  getClientConcSelecteditem(){
    this.radioClientConcSel = this.clientConc.find(Item => Item.score === this.radioClientConcSelected);
    this.radioClientConcSelectedString = JSON.stringify(this.radioClientConcSel);
    this.clientConcValue = this.radioClientConcSelected;
  }
  maintainSingle(){
    this._service.truncateScoresForPost().subscribe(()=>{
    });
  }
  save(){
    this.maintainSingle();
    this.getTotalScore();
    this.totScore.score = this.radioTotalSelected;
    this._service.postTotalScore(this.totScore).subscribe(()=>{
      this.notify.success(this.l('SaveSuccessfully'));
      this.reset();
    });
  }
  getTotalScore(){
    // if(this.posValue == undefined || this.posValue == null){
    //   this.posValue == 0;
    // }
    // if(this.ownValue == undefined || this.ownValue == null){
    //   this.ownValue == 0;
    // }
    // if(this.proValue == undefined || this.proValue == null){
    //   this.proValue == 0;
    // }
    // if(this.legalValue == undefined || this.legalValue == null){
    //   this.legalValue == 0;
    // }
    // if(this.industrialValue == undefined || this.industrialValue == null){
    //   this.industrialValue == 0;
    // }
    // if(this.managementValue == undefined || this.managementValue == null){
    //   this.managementValue == 0;
    // }
    // if(this.yearBusValue == undefined || this.yearBusValue == null){
    //   this.yearBusValue == 0;
    // }
    // if(this.clientConcValue == undefined || this.clientConcValue == null){
    //   this.clientConcValue == 0;
    // }
    this.radioTotalSelected = this.posValue + this.ownValue + this.proValue + 
    this.legalValue + this.industrialValue + this.managementValue + this.yearBusValue +
    this.clientConcValue;
  }

  reset(){
    this.radioSelected = null;
    this.radioOwnSelected = null;
    this.radioProSelected = null;
    this.radioLegalSelected = null;
    this.radioIndustrialSelected = null;
    this.radioManagementSelected = null;
    this.radioYearBusSelected = null;
    this.radioClientConcSelected = null;
  }
}
