import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateRetailScoreDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import Stepper from 'bs-stepper';
import * as _ from 'lodash';

@Component({
  selector: 'app-subatrribute-usepage',
  templateUrl: './subatrribute-usepage.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SubatrributeUsepageComponent extends AppComponentBase implements OnInit {
subRetailDemoList: any[]= [];
genderList: any[]= [];
ageList: any[]= [];
savingList: any[]= [];
depositList: any[]= [];
withdrawalList: any[]= [];
netChangeList: any[]= [];
currentSavingList: any[]= [];
numberCreditsList: any[]= [];
maxDaysList: any[]= [];
clientList: any[]= [];
transactionList: any[]= [];
subjectiveList: any[]= [];
expressLoanList: any[]= [];
daysArrearsList: any[]= [];
daysArrearsNeList: any[]= [];
daysArrearsSeList: any[]= [];
businessTypeList: any[]= [];
expBusinessList: any[]= [];
maritalStatusList: any[]= [];
valueAssetsList: any[]= [];

custList:any=[];
retail: CreateRetailScoreDto = new CreateRetailScoreDto();
existResponse:string;
successResponse:string;



private stepper: Stepper;
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
p:number=1;

genderSelected:number;
ageSelected:number;
savingSelected:number;
depositSelected:number;
withdrawalSelected:number;
netChangeSelected:number;
currentSavingSelected:number;
numberCreditsSelected:number;
maxDaysSelected:number;
clientSelected:number;
transactionSelected:number;
subjectiveSelected:number;
expressLoanSelected:number;
daysArrearsSelected:number;
daysArrearsNeSelected:number;
daysArrearsSeSelected:number;
businessTypeSelected:number;
expBusinessSelected:number;
maritalStatusSelected:number;
valueAssetsSelected:number;
clientName:string;



genderSel:any;
ageSel:any;
savingSel:any;
depositSel:any;
withdrawalSel:any;
netChangeSel:any;
currentSavingSel:any;
numberCreditsSel:any;
maxDaysSel:any;
clientSel:any;
transactionSel:any;
subjectiveSel:any;
expressLoanSel:any;
daysArrearsSel:any;
daysArrearsNeSel:any;
daysArrearsSeSel:any;
businessTypeSel:any;
expBusinessSel:any;
maritalStatusSel:any;
valueAssetsSel:any;



genderValue:number;
ageValue:number;
savingValue:number;
depositValue:number;
withdrawalValue:number;
netChangeValue:number;
currentSavingValue:number;
numberCreditsValue:number;
maxDaysValue:number;
clientValue:number;
transactionValue:number;
subjectiveValue:number;
expressLoanValue:number;
daysArrearsValue:number;
daysArrearsNeValue:number;
daysArrearsSeValue:number;
businessTypeValue:number;
expBusinessValue:number;
maritalStatusValue:number;
valueAssetsValue:number;




genderSelectedString:any;
ageSelectedString:any;
savingSelectedString:any;
depositSelectedString:any;
withdrawalSelectedString:any;
netChangeSelectedString:any;
currentSavingSelectedString:any;
numberCreditsSelectedString:any;
maxDaysSelectedString:any;
clientSelectedString:any;
transactionSelectedString:any;
subjectiveSelectedString:any;
expressLoanSelectedString:any;
daysArrearsSelectedString:any;
daysArrearsNeSelectedString:any;
daysArrearsSeSelectedString:any;
businessTypeSelectedString:any;
expBusinessSelectedString:any;
maritalStatusSelectedString:any;
valueAssetsSelectedString:any;



constructor(private inj: Injector,
  private _service: DemoRetailServiceProxy,
  private route: ActivatedRoute,
  private router: Router,) { super(inj)}


  ngOnInit(): void {
    this.bsInitialization();
    this.getGender();
    this.getAge();
    this.getSavingForYears();
    this.getDeposit();
    this.getWithdrawals();
    this.getNetchange();
    this.geCurrentSaving();
    this.getNumberCredit();
    this.getMaxDays();
    this.getClientMonth();
    this.getTransaction();
    this.getSubjective();
    this.getExpress();
    this.getDaysArrears();
    this.getDaysArrearsNext();
    this.getDaysArrearsSecond();
    this.getTBusinessType();
    this.getExpBusiness();
    this.getMaritalStatus();
    this.getValueAssets();
    this.getCustomer();
  }
  getGender(){
    var attributeParam = 'Gender';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.genderList = res;
    });
  }
  getAge(){
    var attributeParam = 'Age';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.ageList = res;
    });
  }
  getSavingForYears(){
    var attributeParam = 'Has been saving for (years)';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.savingList = res;
    });
  }
  getDeposit(){
    var attributeParam = 'Deposits per month';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.depositList = res;
    });
  }
  getWithdrawals(){
    var attributeParam = 'Withdrawals per month';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.withdrawalList = res;
    });
  }
  getNetchange(){
    var attributeParam = 'Net change - savings balance (past 6 months)';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.netChangeList = res;
    });
  }
  geCurrentSaving(){
    var attributeParam = 'Current savings balance';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.currentSavingList = res;
    });
  }
  getNumberCredit(){
    var attributeParam = 'Number of credit-bureau queries';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.numberCreditsList = res;
    });
  }
  getMaxDays(){
    var attributeParam = 'Max days in arrears';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.maxDaysList = res;
    });
  }
  getClientMonth(){
    var attributeParam = 'Client for (months)';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.clientList = res;
    });
  }
  getTransaction(){
    var attributeParam = 'Transactions per month (average)';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.transactionList = res;
    });
  }
  getSubjective(){
    var attributeParam = 'Subjective perception';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.subjectiveList = res;
    });
  }
  getExpress(){
    var attributeParam = 'Express loans taken';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.expressLoanList = res;
    });
  }
  getDaysArrears(){
    var attributeParam = 'Days in arrears previous Express loan';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.daysArrearsList = res;
    });
  }
  getDaysArrearsNext(){
    var attributeParam = 'Days in arrears next-to-last Express loan';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.daysArrearsNeList = res;
    });
  }
  getDaysArrearsSecond(){
    var attributeParam = 'Days in arrears second-to-last Express loan';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.daysArrearsSeList = res;
    });
  }
  getTBusinessType(){
    var attributeParam = 'Type of business';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.businessTypeList = res;
    });
  }
  getExpBusiness(){
    var attributeParam = 'Experience business (years)';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.expBusinessList = res;
    });
  }
  getMaritalStatus(){
    var attributeParam = 'Marital status';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.maritalStatusList = res;
    });
  }
  getValueAssets(){
    var attributeParam = 'Value of assets';
    this._service.getApprovedSubRetailAttr(attributeParam).subscribe(res=>{
      this.valueAssetsList = res;
    });
  }
  
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }



  onGenderChange(item:any){
    this.getSelitemGender();
  }
  
  getSelitemGender(){
    this.genderSel = this.genderList.find(Item => Item.value === this.genderSelected);
    this.genderSelectedString = JSON.stringify(this.genderSel);
    this.genderValue = this.genderSelected;
  }
  onAgeChange(item:any){
    this.getSelitemAge();
  }
  
  getSelitemAge(){
    this.ageSel = this.ageList.find(Item => Item.value === this.ageSelected);
    this.ageSelectedString = JSON.stringify(this.ageSel);
    this.ageValue = this.ageSelected;
  }
  onSavingChange(item:any){
    this.getSelitemSaving();
  }
  
  getSelitemSaving(){
    this.savingSel = this.savingList.find(Item => Item.value === this.savingSelected);
    this.savingSelectedString = JSON.stringify(this.savingSel);
    this.savingValue = this.savingSelected;
  }
  onDepositChange(item:any){
    this.getSelitemDeposit();
  }
  
  getSelitemDeposit(){
    this.depositSel = this.depositList.find(Item => Item.value === this.depositSelected);
    this.depositSelectedString = JSON.stringify(this.depositSel);
    this.depositValue = this.depositSelected;
  }

  
  onWithdrawalChange(item:any){
    this.getSelitemWithdrawal();
  }
  
  getSelitemWithdrawal(){
    this.withdrawalSel = this.withdrawalList.find(Item => Item.value === this.withdrawalSelected);
    this.withdrawalSelectedString = JSON.stringify(this.withdrawalSel);
    this.withdrawalValue = this.withdrawalSelected;
  }
  onNetChange(item:any){
    this.getSelitemNetChange();
  }
  
  getSelitemNetChange(){
    this.netChangeSel = this.netChangeList.find(Item => Item.value === this.netChangeSelected);
    this.netChangeSelectedString = JSON.stringify(this.netChangeSel);
    this.netChangeValue = this.netChangeSelected;
  }


  onCurrentSavingChange(item:any){
    this.getSelitemCurrentSaving();
  }
  
  getSelitemCurrentSaving(){
    this.currentSavingSel = this.currentSavingList.find(Item => Item.value === this.currentSavingSelected);
    this.currentSavingSelectedString = JSON.stringify(this.currentSavingSel);
    this.currentSavingValue = this.currentSavingSelected;
  }
  onNumberCreditChange(item:any){
    this.getSelitemNumberCredit();
  }
  
  getSelitemNumberCredit(){
    this.numberCreditsSel = this.numberCreditsList.find(Item => Item.value === this.numberCreditsSelected);
    this.numberCreditsSelectedString = JSON.stringify(this.numberCreditsSel);
    this.numberCreditsValue = this.numberCreditsSelected;
  }
  onMaxDaysChange(item:any){
    this.getSelitemMaxDays();
  }
  
  getSelitemMaxDays(){
    this.maxDaysSel = this.maxDaysList.find(Item => Item.value === this.maxDaysSelected);
    this.maxDaysSelectedString = JSON.stringify(this.maxDaysSel);
    this.maxDaysValue = this.maxDaysSelected;
  }
  onClientMonthChange(item:any){
    this.getSelitemClientMonth();
  }
  
  getSelitemClientMonth(){
    this.clientSel = this.clientList.find(Item => Item.value === this.clientSelected);
    this.clientSelectedString = JSON.stringify(this.clientSel);
    this.clientValue = this.clientSelected;
  }
  onTransactionChange(item:any){
    this.getSelitemTransaction();
  }
  
  getSelitemTransaction(){
    this.transactionSel = this.transactionList.find(Item => Item.value === this.transactionSelected);
    this.transactionSelectedString = JSON.stringify(this.transactionSel);
    this.transactionValue = this.transactionSelected;

  }
  onSubjectiveChange(item:any){
    this.getSelitemSubjective();
  }
  
  getSelitemSubjective(){
    this.subjectiveSel = this.subjectiveList.find(Item => Item.value === this.subjectiveSelected);
    this.subjectiveSelectedString = JSON.stringify(this.subjectiveSel);
    this.subjectiveValue = this.subjectiveSelected;
  }
  onExpressChange(item:any){
    this.getSelitemExpress();
  }
  
  getSelitemExpress(){
    this.expressLoanSel = this.expressLoanList.find(Item => Item.value === this.expressLoanSelected);
    this.expressLoanSelectedString = JSON.stringify(this.expressLoanSel);
    this.expressLoanValue = this.expressLoanSelected;

  }
  onDaysArrearsChange(item:any){
    this.getSelitemDaysArrears();
  }
  
  getSelitemDaysArrears(){
    this.daysArrearsSel = this.daysArrearsList.find(Item => Item.value === this.daysArrearsSelected);
    this.daysArrearsSelectedString = JSON.stringify(this.daysArrearsSel);
    this.daysArrearsValue = this.daysArrearsSelected;
  }
  onDaysArrearsNeChange(item:any){
    this.getSelitemDaysArrearsNe();
  }
  
  getSelitemDaysArrearsNe(){
    this.daysArrearsNeSel = this.daysArrearsNeList.find(Item => Item.value === this.daysArrearsNeSelected);
    this.daysArrearsNeSelectedString = JSON.stringify(this.daysArrearsNeSel);
    this.daysArrearsNeValue = this.daysArrearsNeSelected;
  }
  ondaysArrearsSecChange(item:any){
    this.getSelitemdaysArrearsSe();
  }
  
  getSelitemdaysArrearsSe(){
    this.daysArrearsSeSel = this.daysArrearsSeList.find(Item => Item.value === this.daysArrearsSeSelected);
    this.daysArrearsSeSelectedString = JSON.stringify(this.daysArrearsSeSel);
    this.daysArrearsSeValue = this.daysArrearsSeSelected;
  }
  onBusinessTypeChange(item:any){
    this.getSelitemBusinessType();
  }
  
  getSelitemBusinessType(){
    this.businessTypeSel = this.businessTypeList.find(Item => Item.value === this.businessTypeSelected);
    this.businessTypeSelectedString = JSON.stringify(this.businessTypeSel);
    this.businessTypeValue = this.businessTypeSelected;
  }
  onExpBusinessChange(item:any){
    this.getSelitemExpBusiness();
  }
  
  getSelitemExpBusiness(){
    this.expBusinessSel = this.expBusinessList.find(Item => Item.value === this.expBusinessSelected);
    this.expBusinessSelectedString = JSON.stringify(this.expBusinessSel);
    this.expBusinessValue = this.expBusinessSelected;
  }
  onMaritalStatusChange(item:any){
    this.getSelitemMaritalStatus();
  }
  
  getSelitemMaritalStatus(){
    this.maritalStatusSel = this.maritalStatusList.find(Item => Item.value === this.maritalStatusSelected);
    this.maritalStatusSelectedString = JSON.stringify(this.maritalStatusSel);
    this.maritalStatusValue = this.maritalStatusSelected;
    
  }
  onValueAssetsChange(item:any){
    this.getSelitemValueAssets();
  }
  
  getSelitemValueAssets(){
    this.valueAssetsSel = this.valueAssetsList.find(Item => Item.value === this.valueAssetsSelected);
    this.valueAssetsSelectedString = JSON.stringify(this.valueAssetsSel);
    this.valueAssetsValue = this.valueAssetsSelected;
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

  getCustomer(){
    this._service.getExistingCustomer().subscribe(res=>{
      this.custList = res;
    });
  }

  // save(){
  //   debugger
  //   this.retail.score = this.genderValue + this.ageValue + this.savingValue +
  //    this.depositValue + this.withdrawalValue + this.netChangeValue + this.currentSavingValue + this.numberCreditsValue +
  //    this.maxDaysValue + this.clientValue + this.transactionValue + this.subjectiveValue + this.expressLoanValue + 
  //    this.daysArrearsValue + this.daysArrearsNeValue + this.daysArrearsSeValue + this.businessTypeValue + this.expBusinessValue +
  //    this.maritalStatusValue + this.valueAssetsValue;
  //    this._service.addExistingCustomerScore(this.retail).subscribe(res=>{
  //     if(res.status === 203){
  //       this.existResponse = res.message;
  //     }
  //     this.successResponse = res.message;
  //     this.notify.success(this.l(this.successResponse));
  //    });
  // }

  getUser(ctrl:any) {
    if (ctrl.selectedIndex == 0) {
      this.clientName = '';
    }
    else {
      this.clientName = this.custList[ctrl.selectedIndex].firstName;
    }
  }

  save(){
    this.message.confirm(
      '',
      this.l('Are you sure to Submit?'),
      (isConfirmed) => {
          if (isConfirmed) {
            var id = 1;
    this.retail.score = this.genderValue + this.ageValue + this.savingValue +
     this.depositValue + this.withdrawalValue + this.netChangeValue + this.currentSavingValue + this.numberCreditsValue +
     this.maxDaysValue + this.clientValue + this.transactionValue + this.subjectiveValue + this.expressLoanValue + 
     this.daysArrearsValue + this.daysArrearsNeValue + this.daysArrearsSeValue + this.businessTypeValue + this.expBusinessValue +
     this.maritalStatusValue + this.valueAssetsValue;
     this._service.addExistingCustomerScore(this.retail).subscribe(res=>{
      if(res.status === 203){
        this.existResponse = res.message;
      }
      this.successResponse = res.message;
      this.notify.success(this.l(this.successResponse));
      this.message.success(this.l(this.clientName + ' has score of ' + this.retail.score + ' Pending for approval'));
      _.remove(this.subRetailDemoList, id);
    });
  }
}
);
}
 
}
