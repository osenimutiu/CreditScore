import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateRetailScoring, RetailItemDto, RetailScoringServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'appretailscoring',
  animations: [appModuleAnimation()],
  templateUrl: './retail-scoring-modal.component.html',
  styles: [
  ]
})
export class RetailScoringModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  retScg: CreateRetailScoring = new CreateRetailScoring();
  retailItems: RetailItemDto[] = [];
  distAtt:any=[];
  // highEduActive: boolean = false;
  // yearsSavingActive: boolean = false;
  // depPerMonthActive: boolean = false;
  // withPMonthActive: boolean = false;
  // clientMonthActive: boolean = false;
  // subPerceptionActive: boolean = false;
  // carOwnStaActive: boolean = false;
  // maritalStatActive: boolean = false;
  // evdTrustWorthActive: boolean = false;
  // stgthRefActive: boolean = false;
  // collateralActive: boolean = false;
  // netChangeActive: boolean = false;
  disableScore: boolean = false;
  // preventDuplicate: boolean;


  // highEduList: HighEduLevelDto[] = [];
  // yearsSavingList: YearsSavingDto[] = [];
  // depPerMonthList: DepPerMonthDto[] = [];
  // withPMonthList: WithPerMonthDto[] = [];
  // clientMonthList: ClientForMonthsDto[] = [];
  // subPerceptionList: SubPerceptionDto[] = [];
  // carOwnStaList: CarOwnStatDto[] = [];
  // maritalStatList: MaritalStatusDto[] = [];
  // evdTrustWorthList: EvdTrustWorthinessDto[] = [];
  // stgthRefList: StrengthRefreeDto[] = [];
  // collateralList: CollateralDto[] = [];
  // netChangeList: NetChangeDto[] = [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  constructor(
    private inj: Injector,
    private _service: RetailScoringServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(inj);
  }

  ngOnInit(): void {
  }


  show(): void {
    this.active = true;
    this.retScg = new CreateRetailScoring();
    // this.getRetailItems();
    this.getDistRetail();
    this.modal.show();
  }


  close(): void {
    this.modal.hide();
    this.active = false;
  }

  save(): void {
    this.saving = true;
    this._service.postRetailScoring(this.retScg)
      .pipe(finalize(() => this.saving = false))
      .subscribe(() => {
        this.notify.success(this.l('Save Successfully'));
      });
    this.close();
    this.reload();
    this.modalSave.emit(this.retScg);
  }

  getRetailItems() {
    this._service.getRetailItem().subscribe(res => {
      this.retailItems = res;
    });
  }

  getDistRetail(){
    this._service.getDistictAttributeItems().subscribe(res=>{
      this.distAtt = res;
    });
  }
  getValue(){
    this._service.getAttOption(this.retScg.attribute).subscribe(res => {
      this.retailItems = res;
      this.getMax();
    });
  }
  UpdateScore(ctr){
  this.retScg.value = this.retailItems[ctr.selectedIndex].value;
    this.retScg.attributeScore = this.retailItems[ctr.selectedIndex].score;
    this.disableScore = true;
    this.updateAttributeScore();
    this.updateDDWeight();
  }
  updateWeight(){
    var x = this.retScg.attributeScore;
    var y = this.retScg.weight;
    if(x == 0 || x == null){
      this.retScg.weightedAttribute = y * 1;
    }else{ 
      this.retScg.weightedAttribute = x * y;
    }
  }
  getMax(){
    const max2 = this.retailItems.reduce((op, item) => op = op > item.score ? op : item.score, 0);
    this.retScg.maxScore = max2;
  }
  updateDDWeight(){
    var x = this.retScg.attributeScore;
    var y = this.retScg.weight;
    if(y == 0 || y == null){
      this.retScg.weightedAttribute = x * 1;
    }else{
      this.retScg.weightedAttribute = x * y;
    }
  }
  updateAttributeScore(){
    this.retScg.weightedAttribute = this.retScg.attributeScore * this.retScg.weight;
  }
  // getCorrespondingValue() {
  //   if (this.retScg.attribute == 1) {
  //     this.getHighEduLevel();
  //   }
  //   if (this.retScg.attribute == 2) {
  //     this.getYearsSavings();
  //   }
  //   if (this.retScg.attribute == 3) {
  //     this.getDepPerMonthScores();
  //   }
  //   if (this.retScg.attribute == 4) {
  //     this.getwithPMonthScores();
  //   }
  //   if (this.retScg.attribute == 5) {
  //     this.getClientMonthScores();
  //   }
  //   if (this.retScg.attribute == 6) {
  //     this.getSubPerceptionScores();
  //   }
  //   if (this.retScg.attribute == 7) {
  //     this.getCarOwnStaScores();
  //   }
  //   if (this.retScg.attribute == 8) {
  //     this.getMaritalStatScores();
  //   }
  //   if (this.retScg.attribute == 9) {
  //     this.getEvdWorthScores();
  //   }
  //   if (this.retScg.attribute == 10) {
  //     this.getStgthRefScores();
  //   }
  //   if (this.retScg.attribute == 11) {
  //     this.getCollateralScores();
  //   }
  //   if (this.retScg.attribute == 12) {
  //     this.getNetChangeScores();
  //   }
  //   this.preventDuplicate = true;
  // }

  // getHighEduLevel() {
  //   this.highEduActive = true;
  //   this._service.getHighEduLevel(this.retScg.attribute).subscribe(res => {
  //     this.highEduList = res;
  //   });
  // }
  // getYearsSavings() {
  //   this.yearsSavingActive = true;
  //   this._service.getYearsSaving(this.retScg.attribute).subscribe(res => {
  //     this.yearsSavingList = res;
  //   });
  // }
  // getDepPerMonthScores() {
  //   this.depPerMonthActive = true;
  //   this._service.getDepPerMonth(this.retScg.attribute).subscribe(res => {
  //     this.depPerMonthList = res;
  //   });
  // }
  // getwithPMonthScores() {
  //   this.withPMonthActive = true;
  //   this._service.getWithPerMonth(this.retScg.attribute).subscribe(res => {
  //     this.withPMonthList = res;
  //   });
  // }
  // getClientMonthScores() {
  //   this.clientMonthActive = true;
  //   this._service.getClientForMonths(this.retScg.attribute).subscribe(res => {
  //     this.clientMonthList = res;
  //   });
  // }
  // getSubPerceptionScores() {
  //   this.subPerceptionActive = true;
  //   this._service.getSubPerception(this.retScg.attribute).subscribe(res => {
  //     this.subPerceptionList = res;
  //   });
  // }

  // getCarOwnStaScores() {
  //   this.carOwnStaActive = true;
  //   this._service.getCarOwnStat(this.retScg.attribute).subscribe(res => {
  //     this.carOwnStaList = res;
  //   });
  // }

  // getMaritalStatScores() {
  //   this.maritalStatActive = true;
  //   this._service.getMaritalStatus(this.retScg.attribute).subscribe(res => {
  //     this.maritalStatList = res;
  //   });
  // }
  // getEvdWorthScores() {
  //   this.evdTrustWorthActive = true;
  //   this._service.getEvdTrustWorthiness(this.retScg.attribute).subscribe(res => {
  //     this.evdTrustWorthList = res;
  //   });
  // }
  // getStgthRefScores() {
  //   this.stgthRefActive = true;
  //   this._service.getStrengthRefree(this.retScg.attribute).subscribe(res => {
  //     this.stgthRefList = res;
  //   });
  // }
  // getCollateralScores() {
  //   this.collateralActive = true;
  //   this._service.getCollateral(this.retScg.attribute).subscribe(res => {
  //     this.collateralList = res;
  //   });
  // }
  // getNetChangeScores() {
  //   this.netChangeActive = true;
  //   this._service.getNetChange(this.retScg.attribute).subscribe(res => {
  //     this.netChangeList = res;
  //   });
  // }



  // UpdateHighEduLevelScore(ctr) {
  //   this.retScg.value = this.highEduList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.highEduList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateYearsSavingScore(ctr) {
  //   this.retScg.value = this.yearsSavingList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.yearsSavingList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateDepPerMonthScore(ctr) {
  //   this.retScg.value = this.depPerMonthList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.depPerMonthList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateWithdrawalPerMonthScore(ctr) {
  //   this.retScg.value = this.withPMonthList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.withPMonthList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateClientForMonthsScore(ctr) {
  //   this.retScg.value = this.clientMonthList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.clientMonthList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateSubPerceptionScore(ctr) {
  //   this.retScg.value = this.subPerceptionList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.subPerceptionList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateCarOwnStaScore(ctr) {
  //   this.retScg.value = this.carOwnStaList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.carOwnStaList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateMaritalStatScore(ctr) {
  //   this.retScg.value = this.maritalStatList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.maritalStatList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateEvdTrustWorthinessScore(ctr) {
  //   this.retScg.value = this.evdTrustWorthList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.evdTrustWorthList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateStgthRefScore(ctr) {
  //   this.retScg.value = this.stgthRefList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.stgthRefList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateCollateralScore(ctr) {
  //   this.retScg.value = this.collateralList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.collateralList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }
  // UpdateNetChangeScore(ctr) {
  //   this.retScg.value = this.netChangeList[ctr.selectedIndex].value;
  //   this.retScg.attributeScore = this.netChangeList[ctr.selectedIndex].score;
  //   this.disableScore = true;
  //   this.updateRetailAttributeScore();
  // }


  // updateRetailAttributeScore() {
  //   this.retScg.weightedAttribute = this.retScg.attributeScore * this.retScg.weight;
  // }

 
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  // reset() {
  //   let x = this.retScg.attribute;
  //   if (x == 1) {
  //     this.preventDuplicate = false;
  //     this.highEduActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 2) {
  //     this.preventDuplicate = false;
  //     this.yearsSavingActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 3) {
  //     this.preventDuplicate = false;
  //     this.depPerMonthActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 4) {
  //     this.preventDuplicate = false;
  //     this.withPMonthActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 5) {
  //     this.preventDuplicate = false;
  //     this.clientMonthActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 6) {
  //     this.preventDuplicate = false;
  //     this.subPerceptionActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 7) {
  //     this.preventDuplicate = false;
  //     this.carOwnStaActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 8) {
  //     this.preventDuplicate = false;
  //     this.maritalStatActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 9) {
  //     this.preventDuplicate = false;
  //     this.evdTrustWorthActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 10) {
  //     this.preventDuplicate = false;
  //     this.stgthRefActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 11) {
  //     this.preventDuplicate = false;
  //     this.collateralActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  //   if (x == 12) {
  //     this.preventDuplicate = false;
  //     this.netChangeActive = false;
  //     this.retScg.attribute = null;
  //     this.retScg.weight = null;
  //     this.retScg.percentage = null;
  //     this.retScg.maxScore = null;
  //     this.retScg.value = null;
  //     this.retScg.weightedAttribute = null;
  //     this.retScg.weightedAttribute = null;
  //   }
  // }
}
