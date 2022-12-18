import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateCooperateScoreDto, SetupQualitativesServiceProxy } from '@shared/service-proxies/service-proxies';
import Stepper from 'bs-stepper';

@Component({
  selector: 'app-cooperate-rating',
  templateUrl: './cooperate-rating.component.html',
  animations: [appModuleAnimation()],
  // styleUrls: ['./cooperate-rating.component.css']
  // styleUrls: ['./cooperate-rating.component.css']
  styles: [
  ]
})
export class CooperateRatingComponent extends AppComponentBase implements OnInit {
  cashflowList: any[] = [];
  ManagementList: any[] = [];
  TrendList: any[] = [];
  LiquidityList: any[] = [];
  LeverageList: any[] = [];
  TargetList: any[] = [];
  legalList: any[] = [];
  IndustrialList: any[] = [];
  YearsList: any[] = [];
  SeasoningList: any[] = [];
  CharacterList: any[] = [];

  custList:any=[];
  cooperate: CreateCooperateScoreDto = new CreateCooperateScoreDto();
  existResponse:string;
  successResponse:string;
  
  
  
  private stepper: Stepper;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  p:number=1;

  cashflowSelected:number;
  ManagementSelected:number;
  TrendSelected:number;
  LiquiditySelected:number;
  LeverageSelected:number;
  TargetSelected:number;
  legalSelected:number;
  IndustrialSelected:number;
  YearsSelected:number;
  SeasoningSelected:number;
  CharacterSelected:number;

cashflowSel:any;
ManagementSel:any;
TrendSel:any;
LiquiditySel:any;
LeverageSel:any;
TargetSel:any;
legalSel:any;
IndustrialSel:any;
YearsSel:any;
SeasoningSel:any;
CharacterSel:any;

cashflowValue:number;
ManagementValue:number;
TrendValue:number;
LiquidityValue:number;
LeverageValue:number;
TargetValue:number;
legalValue:number;
IndustrialValue:number;
YearsValue:number;
SeasoningValue:number;
CharacterValue:number;


cashflowSelectedString:any;
ManagementSelectedString:any;
TrendSelectedString:any;
LiquiditySelectedString:any;
LeverageSelectedString:any;
TargetSelectedString:any;
legalSelectedString:any;
IndustrialSelectedString:any;
YearsSelectedString:any;
SeasoningSelectedString:any;
CharacterSelectedString:any;

constructor(private inj: Injector,
  private _service: SetupQualitativesServiceProxy,
  private route: ActivatedRoute,
  private router: Router,) { super(inj)}

  ngOnInit(): void {
    this.bsInitialization();
    this.getcashflow();
    this.getManagement();	
    this.getTrend();
    this.getLiquidity();
    this.getLeverage();
    this.getTarget();
    this.getlegal();
    this.getIndustrial();
    this.getYears();
    this.getSeasoning();
    this.getCharacter();
    this.getCooperate();
  }

  getcashflow(){
    var attributeParam = 1;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.cashflowList = res;
    });
  }
  getManagement(){
    var attributeParam = 2;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.ManagementList = res;
    });
  }
  getTrend(){
    var attributeParam = 3;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.TrendList = res;
    });
  }
  getLiquidity(){
    var attributeParam = 4;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.LiquidityList = res;
    });
  }
  getLeverage(){
    var attributeParam = 5;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.LeverageList = res;
    });
  }
  getTarget(){
    var attributeParam = 6;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.TargetList = res;
    });
  }
  getlegal(){
    var attributeParam = 9;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.legalList = res;
    });
  }
  getIndustrial(){
    var attributeParam = 8;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.IndustrialList = res;
    });
  }
  getYears(){
    var attributeParam = 10;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.YearsList = res;
    });
  }
  getSeasoning(){
    debugger
    var attributeParam = 11;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.SeasoningList = res;
    });
  }
  getCharacter(){
    var attributeParam = 7;
    this._service.getApprovedQualitative(attributeParam).subscribe(res=>{
      this.CharacterList = res;
    });
  }

    reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  oncashflowChange(item:any){
    this.getSelitemcashflow();
  }
  
  getSelitemcashflow(){
    this.cashflowSel = this.cashflowList.find(Item => Item.value === this.cashflowSelected);
    this.cashflowSelectedString = JSON.stringify(this.cashflowSel);
    this.cashflowValue = this.cashflowSelected;
    //alert(this.cashflowValue);
  }
  onManagementChange(item:any){
    this.getSelitemManagement();
  }
  
  getSelitemManagement(){
    this.ManagementSel = this.ManagementList.find(Item => Item.value === this.ManagementSelected);
    this.ManagementSelectedString = JSON.stringify(this.ManagementSel);
    this.ManagementValue = this.ManagementSelected;
    //alert(this.ManagementValue);
  }
  onTrendChange(item:any){
    this.getSelitemTrend();
  }
  
  getSelitemTrend(){
    this.TrendSel = this.TrendList.find(Item => Item.value === this.TrendSelected);
    this.TrendSelectedString = JSON.stringify(this.TrendSel);
    this.TrendValue = this.TrendSelected;
    //alert(this.TrendValue);
  }
  onLiquidityChange(item:any){
    this.getSelitemLiquidity();
  }
  
  getSelitemLiquidity(){
    this.LiquiditySel = this.LiquidityList.find(Item => Item.value === this.LiquiditySelected);
    this.LiquiditySelectedString = JSON.stringify(this.LiquiditySel);
    this.LiquidityValue = this.LiquiditySelected;
    //alert(this.LiquidityValue);
  }

  
  onLeverageChange(item:any){
    this.getSelitemLeverage();
  }
  
  getSelitemLeverage(){
    this.LeverageSel = this.LeverageList.find(Item => Item.value === this.LeverageSelected);
    this.LeverageSelectedString = JSON.stringify(this.LeverageSel);
    this.LeverageValue = this.LeverageSelected;
    //alert(this.LeverageValue);
  }
  onTargetChange(item:any){
    this.getSelitemTarget();
  }
  
  getSelitemTarget(){
    this.TargetSel = this.TargetList.find(Item => Item.value === this.TargetSelected);
    this.TargetSelectedString = JSON.stringify(this.TargetSel);
    this.TargetValue = this.TargetSelected;
    //alert(this.TargetValue);
  }


  onlegalChange(item:any){
    this.getSelitemlegal();
  }
  
  getSelitemlegal(){
    this.legalSel = this.legalList.find(Item => Item.value === this.legalSelected);
    this.legalSelectedString = JSON.stringify(this.legalSel);
    this.legalValue = this.legalSelected;
    //alert(this.legalValue);
  }
  onIndustrialChange(item:any){
    this.getSelitemindustrial();
  }
  
  getSelitemindustrial(){
    this.IndustrialSel = this.IndustrialList.find(Item => Item.value === this.IndustrialSelected);
    this.IndustrialSelectedString = JSON.stringify(this.IndustrialSel);
    this.IndustrialValue = this.IndustrialSelected;
    //alert(this.IndustrialValue);
  }
  onYearsChange(item:any){
    this.getSelitemYears();
  }
  
  getSelitemYears(){
    this.YearsSel = this.YearsList.find(Item => Item.value === this.YearsSelected);
    this.YearsSelectedString = JSON.stringify(this.YearsSel);
    this.YearsValue = this.YearsSelected;
    //alert(this.YearsValue);
  }
  onSeasoningChange(item:any){
    this.getSelitemSeasoning();
  }
  
  getSelitemSeasoning(){
    this.SeasoningSel = this.SeasoningList.find(Item => Item.value === this.SeasoningSelected);
    this.SeasoningSelectedString = JSON.stringify(this.SeasoningSel);
    this.SeasoningValue = this.SeasoningSelected;
    //alert(this.SeasoningValue);
  }
  onCharacterChange(item:any){
    this.getSelitemCharacter();
  }
  
  getSelitemCharacter(){
    this.CharacterSel = this.CharacterList.find(Item => Item.value === this.CharacterSelected);
    this.CharacterSelectedString = JSON.stringify(this.CharacterSel);
    this.CharacterValue = this.CharacterSelected;
    //alert(this.CharacterValue);

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

  getCooperate(){
    this._service.getExistingCooperate().subscribe(res=>{
      this.custList = res;
    });
  }

  save(){
    debugger
    this.cooperate.score = this.cashflowValue + this.ManagementValue + this.TrendValue +
     this.LiquidityValue + this.LeverageValue + this.TargetValue + this.legalValue + this.IndustrialValue
     + this.YearsValue + this.SeasoningValue + this.CharacterValue;
     this._service.addExistingCooperateScore(this.cooperate).subscribe(res=>{
      if(res.status === 203){
        this.existResponse = res.message;
      }
      this.successResponse = res.message;
      this.notify.success(this.l(this.successResponse));
      // document.getElementById("openModalButton").click();
     });
  }
}
