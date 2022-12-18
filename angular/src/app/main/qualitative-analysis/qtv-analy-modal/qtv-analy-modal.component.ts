import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AttributeItemDto, CreateQualitativeAnalysisDto, QualitativeAnalysisServiceProxy } from '@shared/service-proxies/service-proxies';
// import { AccAccRecordDto, AccShenaniggansDto, AttributeItemDto, CreateQualitativeAnalysisDto, CriminalPenaltyDto, EvdCrtAccountingDto, EvdExpenditureDto, IntContRegulationDto, LevelCmpIndustryDto, LevelOrgCorperationDto, ManagementQualityDto, NoAccountDto, OtherUnthicalConductDto, QualitativeAnalysisServiceProxy, RecordViolationDto, RegEthicsDto, RoleAssignmentDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'analyModal',
  templateUrl: './qtv-analy-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class QtvAnalyModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  qAnaLysis: CreateQualitativeAnalysisDto = new CreateQualitativeAnalysisDto();
  attributeItems: AttributeItemDto[]= [];
  distAtt:any=[];
  disableScore: boolean = false;
  // crimPenaltyList:CriminalPenaltyDto[] = [];
  // crimPenActive:boolean = false;
 
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  // accAccuracyActive: boolean = false;
  // internalContRegActive: boolean = false;
  // roleAssActive: boolean = false;
  // numAccActive: boolean = false;
  // regEthicsActive: boolean = false;
  // unEthicalActive: boolean = false;
  // eviExpActive: boolean = false;
  // levelOrgCoopActive: boolean = false;
  // mgmQualityActive: boolean = false;
  // recViolActive: boolean = false;
  // evdCretAccActive: boolean = false;
  // levCompIndActive: boolean = false;
  // accShenActive: boolean = false;
  // tryActive: boolean = false;


//   accAccuracyList:AccAccRecordDto[] = [];
//   intContRegList:IntContRegulationDto[] = [];
//   roleAssList:RoleAssignmentDto[] = [];
//   numAccountList:NoAccountDto[] = [];
//   regEthicsList:RegEthicsDto[] = [];
//   unEthicalList:OtherUnthicalConductDto[] = [];
//   eviExpList:EvdExpenditureDto[] = [];
//   levelOrgCoopList:LevelOrgCorperationDto[] = [];
//   mgmQualityList:ManagementQualityDto[] = [];
//   recViolList:RecordViolationDto[]=[];
//   evdCretAccList:EvdCrtAccountingDto[]=[];
//   levCompIndList:LevelCmpIndustryDto[]=[];
//   accShenList:AccShenaniggansDto[] = [];
//   preventDuplicate: boolean;
// try:EvdCrtAccountingDto [] = [];

  constructor(
    private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(inj);
  }

  ngOnInit(): void {
  }

  show(): void { 
    this.active = true;
    this.qAnaLysis = new CreateQualitativeAnalysisDto();
    // this.getAttributeItems();
    this.distAttribute();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void{
  this.saving = true;
     this._service.postQualitativeAnalysis(this.qAnaLysis)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Save Successfully'));     
     });
     this.close();
     this.reload();
     this.modalSave.emit(this.qAnaLysis);
}
// getAttributeItems(){
//   this._service.getAttributeItem().subscribe(res =>{
//     this.attributeItems = res;
//   });
// }
distAttribute(){
  this._service.getDistictAttributeItems().subscribe(res=> {
    this.distAtt = res;
  });
}
getValue(){
  this._service.getAttOption(this.qAnaLysis.attribute).subscribe(res=>{
    this.attributeItems = res;
    this.getMax();
  });
}
getUpdateScoreValue(ctr){
    this.qAnaLysis.value = this.attributeItems[ctr.selectedIndex].value;
    this.qAnaLysis.attributeScore = this.attributeItems[ctr.selectedIndex].score;
    this.disableScore = true;
    this.updateAttributeScore();
    this.updateDDWeight();
}
updateWeight(){
  var x = this.qAnaLysis.attributeScore;
  var y = this.qAnaLysis.weight;
  if(x == 0 || x == null){
    this.qAnaLysis.weightedAttribute = y * 1;
  }else{ 
    this.qAnaLysis.weightedAttribute = x * y;
  }
}
getMax(){
  const max2 = this.attributeItems.reduce((op, item) => op = op > item.score ? op : item.score, 0);
  this.qAnaLysis.maxScore = max2;
}
updateDDWeight(){
  var x = this.qAnaLysis.attributeScore;
  var y = this.qAnaLysis.weight;
  if(y == 0 || y == null){
    this.qAnaLysis.weightedAttribute = x * 1;
  }else{
    this.qAnaLysis.weightedAttribute = x * y;
  }
}
updateAttributeScore(){
  this.qAnaLysis.weightedAttribute = this.qAnaLysis.attributeScore * this.qAnaLysis.weight;
}
reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

// getCorrespondingValue(){
//   if(this.qAnaLysis.attribute == 1){
//     this.getCriminalPenalty();
//   }
//   if(this.qAnaLysis.attribute == 2){
//     this.getAccuracyAccountRecords();
//   }
//   if(this.qAnaLysis.attribute == 3){
//     this.getIntContRegScore();
//   }
//   if(this.qAnaLysis.attribute == 4){
//     this.getRoleAssignmentScore();
//   }
//   if(this.qAnaLysis.attribute == 5){
//     this.getNumAccScore();
//   }
//   if(this.qAnaLysis.attribute == 6){
//     this.getRegEthicsScore();
//   }
//   if(this.qAnaLysis.attribute == 7){
//     this.getUnEthicalScore();
//   }
//   if(this.qAnaLysis.attribute == 8){
//     this.getEviExpScore();
//   }
//   if(this.qAnaLysis.attribute == 9){
//     this.getLevOrgCooptnScore();
//   }
//   if(this.qAnaLysis.attribute == 10){
//     this.getMgtQtyScore();
//   }
//   if(this.qAnaLysis.attribute == 11){
//     this.getRecViolScore();
//   }
//   if(this.qAnaLysis.attribute == 12){
//     this.getEvdCretAccScore();
//   }
//   if(this.qAnaLysis.attribute == 13){
//     this.getLevCmpIndScore();
//   }
//   if(this.qAnaLysis.attribute == 14){
//     this.getAccShenScore();
//   }
//   this.preventDuplicate = true;

// }

// getCriminalPenalty(){
//   this.crimPenActive = true;
//   this._service.getCriminalPenalty(this.qAnaLysis.attribute).subscribe(res =>{
//     this.crimPenaltyList = res;
//   });
// }
// getAccuracyAccountRecords(){
//   this.accAccuracyActive = true;
//   this._service.getAccAccRecord(this.qAnaLysis.attribute).subscribe(res =>{
//     this.accAccuracyList = res;
//   });
// }
// getIntContRegScore(){
//   this.internalContRegActive = true;
//   this._service.getIntContRegulation(this.qAnaLysis.attribute).subscribe(res =>{
//     this.intContRegList = res;
//   });
// }
// getRoleAssignmentScore(){
//   this.roleAssActive = true;
//   this._service.getRoleAssignment(this.qAnaLysis.attribute).subscribe(res =>{
//     this.roleAssList = res;
//   });
// }
// getNumAccScore(){
//   this.numAccActive = true;
//   this._service.getNoAccount(this.qAnaLysis.attribute).subscribe(res =>{
//     this.numAccountList = res;
//   });
// }
// getRegEthicsScore(){
//   this.regEthicsActive = true;
//   this._service.getRegEthics(this.qAnaLysis.attribute).subscribe(res =>{
//     this.regEthicsList = res;
//   });
// }
// getUnEthicalScore(){
//   this.unEthicalActive = true;
//   this._service.getOtherUnthicalConduct(this.qAnaLysis.attribute).subscribe(res =>{
//     this.unEthicalList = res;
//   });
// }
// getEviExpScore(){
//   this.eviExpActive = true;
//   this._service.getEvdExpenditure(this.qAnaLysis.attribute).subscribe(res =>{
//     this.eviExpList = res;
//   });
// }
// getLevOrgCooptnScore(){
//   this.levelOrgCoopActive = true;
//   this._service.getLevelOrgCorperation(this.qAnaLysis.attribute).subscribe(res =>{
//     this.levelOrgCoopList = res;
//   });
// }
// getMgtQtyScore(){
//   this.mgmQualityActive = true;
//   this._service.getManagementQuality(this.qAnaLysis.attribute).subscribe(res =>{
//     this.mgmQualityList = res;
//   });
// }
// getRecViolScore(){
//   this.recViolActive = true;
//   this._service.getRecordViolation(this.qAnaLysis.attribute).subscribe(res =>{
//     this.recViolList = res;
//   });
// }
// getEvdCretAccScore(){
//   debugger;
//   this.tryActive = true;
//   this._service.getEvdCrtAccounting(this.qAnaLysis.attribute).subscribe(res =>{
//     this.try = res;
//     // console.log(this.evdCretAccList);
//     console.log(this.try);
//   });
// }
// getLevCmpIndScore(){
//   this.levCompIndActive = true;
//   this._service.getLevelCmpIndustry(this.qAnaLysis.attribute).subscribe(res =>{
//     this.levCompIndList = res;
//   });
// }
// getAccShenScore(){
//   this.accShenActive = true;
//   this._service.getAccShenaniggans(this.qAnaLysis.attribute).subscribe(res =>{
//     this.accShenList = res;
//   });
// }







// UpdateScore(ctr){
//     this.qAnaLysis.value = this.crimPenaltyList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.crimPenaltyList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateAccAccuracyScore(ctr){
//     this.qAnaLysis.value = this.accAccuracyList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.accAccuracyList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateIntContRegScore(ctr){
//     this.qAnaLysis.value = this.intContRegList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.intContRegList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateRoleAss(ctr){
//     this.qAnaLysis.value = this.roleAssList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.roleAssList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateNumAccount(ctr){
//     this.qAnaLysis.value = this.numAccountList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.numAccountList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateregEthics(ctr){
//     this.qAnaLysis.value = this.regEthicsList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.regEthicsList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateUnEthical(ctr){
//     this.qAnaLysis.value = this.unEthicalList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.unEthicalList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateUnEvidExp(ctr){
//     this.qAnaLysis.value = this.eviExpList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.eviExpList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateLevelOrgCorperation(ctr){
//     this.qAnaLysis.value = this.levelOrgCoopList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.levelOrgCoopList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateMgtQuality(ctr){
//     this.qAnaLysis.value = this.mgmQualityList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.mgmQualityList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateRecViol(ctr){
//     this.qAnaLysis.value = this.recViolList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.recViolList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateEvidCreative(ctr){
//     this.qAnaLysis.value = this.try[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.try[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateLevCmpInd(ctr){
//     this.qAnaLysis.value = this.levCompIndList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.levCompIndList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }
// UpdateaccShen(ctr){
//     this.qAnaLysis.value = this.accShenList[ctr.selectedIndex].value;
//     this.qAnaLysis.attributeScore = this.accShenList[ctr.selectedIndex].score;
//     this.disableScore = true;
//     this.updateAttributeScore();
// }


// reset(){
//   let x = this.qAnaLysis.attribute;
//   if(x == 1){
//     this.preventDuplicate = false;
//     this.crimPenActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 2){
//     this.preventDuplicate = false;
//     this.accAccuracyActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 3){
//     this.preventDuplicate = false;
//     this.internalContRegActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 4){
//     this.preventDuplicate = false;
//     this.roleAssActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 5){
//     this.preventDuplicate = false;
//     this.numAccActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 6){
//     this.preventDuplicate = false;
//     this.regEthicsActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 7){
//     this.preventDuplicate = false;
//     this.unEthicalActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 8){
//     this.preventDuplicate = false;
//     this.eviExpActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 9){
//     this.preventDuplicate = false;
//     this.levelOrgCoopActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 10){
//     this.preventDuplicate = false;
//     this.mgmQualityActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 11){
//     this.preventDuplicate = false;
//     this.recViolActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 12){
//     this.preventDuplicate = false;
//     this.tryActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 13){
//     this.preventDuplicate = false;
//     this.levCompIndActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
//   if(x == 14){
//     this.preventDuplicate = false;
//     this.accShenActive = false;
//     this.qAnaLysis.attribute = null;
//     this.qAnaLysis.weight = null;
//     this.qAnaLysis.percentage = null;
//     this.qAnaLysis.maxScore = null;
//     this.qAnaLysis.value = null;
//     this.qAnaLysis.weightedAttribute = null;
//     this.qAnaLysis.weightedAttribute = null;
//   }
// }
}
