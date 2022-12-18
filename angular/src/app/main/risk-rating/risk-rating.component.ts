import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BankAccountDto, CreateIndAppDto, CreditLineConditionDto, IndividualServiceProxy, RecommendationDto, RiskAssessmentDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-risk-rating',
  templateUrl: './risk-rating.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./risk-rating.component.css']
  // styles: [
  // ]
})
export class RiskRatingComponent extends AppComponentBase implements OnInit {
  recommendations: RecommendationDto[] = [];
  riskAss: RiskAssessmentDto[] = [];
  bAccs: BankAccountDto[] = [];
  crdLines: CreditLineConditionDto[] = [];
  totalScore: number;
  red: number;
  yellow: number;
  performance: number;
  qualitative: number;
  Approved: string;
  Rejected: string;
  saving: boolean = false;
  active: boolean = false;
  ind: CreateIndAppDto = new CreateIndAppDto();
  dob: string;
  mydob: Date;
  applicationDate: Date;
  myDate: string;
  annualInflow: number;
constructor(
  injector: Injector,
  private _service: IndividualServiceProxy,
  private route: ActivatedRoute,
  private router: Router,public datepipe: DatePipe
) {
  super(injector)
 }

  ngOnInit(): void {
    this.getLendingOutput();
    this.getRiskAssessment();
    this.getBankAccount();
    this.getCreditLineCondition();
    this.setValues();
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getLendingOutput(){
    this._service.getRecommendation().subscribe((result) => {
      this.recommendations = result;
      this.getTotalScore();
      this.getApproved();
    });
  }
  getRiskAssessment(){
    this._service.getRiskAssessment().subscribe(result => {
      this.riskAss = result;
      this.getRedSignals();
      this.getYellowSignals();
      this.getPerformanceSignals();
      this.getQualitySignals();
    });
  }
  getBankAccount(){
    this._service.getBankAccounts().subscribe(result => {
      this.bAccs = result;
    });
  }
  getCreditLineCondition(){
    this._service.getCreditLineConditions().subscribe(result => {
      this.crdLines = result;
    });
  }

  getTotalScore() {
    let total = 0;
    for (var i = 0; i < this.recommendations.length; i++) {
        if (this.recommendations[i].score) {
            total += this.recommendations[i].score;
            this.totalScore = total;
        }
    }
    return total;
  }
  getApproved() {
    let res = '';
    for (var i = 0; i < this.recommendations.length; i++) {
        if (this.recommendations[i].recommendation) {
            res = this.recommendations[i].recommendation;
            if(res== "Approved"){
              this.Approved = res;
            }
            if(res== "Rejected"){
              this.Rejected = res;
            }
        }
    }
    return res;
  }
  // getRejected() {
  //   let rres = '';
  //   for (var i = 0; i < this.recommendations.length; i++) {
  //       if (this.recommendations[i].recommendation) {
  //           rres = this.recommendations[i].recommendation;
  //           this.Rejected = rres;
  //       }
  //   }
  //   return rres;
  // }
  getYellowSignals() {
    let totalw = 0;
    for (var i = 0; i < this.riskAss.length; i++) {
        if (this.riskAss[i].yellowWarnSignals) {
          totalw += this.riskAss[i].yellowWarnSignals;
          this.yellow = totalw;
          if(totalw == 2){
            this.yellow = totalw;
          }
        }
    }
    return totalw;
  }
  getRedSignals() {
    debugger;
    let totalr = 0;
    for (var i = 0; i < this.riskAss.length; i++) {
        if (this.riskAss[i].redWarnSignals) {
          totalr += this.riskAss[i].redWarnSignals;
          if(totalr == 1){
            this.red = totalr;
          }
        }
    }
    return totalr;
  }
  getPerformanceSignals() {
    let total = 0;
    for (var i = 0; i < this.riskAss.length; i++) {
        if (this.riskAss[i].performanceModel) {
          total += this.riskAss[i].performanceModel;
          if(total == 2.61){
            this.performance = total;
          }
        }
    }
    return total;
  }
  getQualitySignals() {
    let totalqty = 0;
    for (var i = 0; i < this.riskAss.length; i++) {
        if (this.riskAss[i].qualitativeWarnSignals) {
          totalqty += this.riskAss[i].qualitativeWarnSignals;
          if(totalqty == 2.10){
            this.qualitative = totalqty;
          }
        }
    }
    return totalqty;
  }
  getColorDecision(recommend){ (1)
    switch (recommend){
      case 'Approved' :
        return '#128a38';
      case 'Rejected' :
        return 'red';
    }
  }
  getColorRed(recommend){ (1)
    switch (recommend){
      case 1 :
        return '#fc030b';
    }
  }
  getColorYellow(recommend){ (1)
    switch (recommend){
      case 2 :
        return '#d2de2a';
    }
  }
  getColorQuality(recommend){ (1)
    switch (recommend){
      case 2.10 :
        return '#0237f5';
    }
  }
  getColorPerformance(recommend){ (1)
    switch (recommend){
      case 2.61 :
        return '#128a38';
    }
  }
  save(): void{
    this.saving = true;
       this._service.creatIndividualApp(this.ind)
       .pipe(finalize(() => this.saving = false))
       .subscribe(() =>{
        this.notify.success(this.l('Save Successfully'));
        this.ind.uniqueId = (Math.floor(10000000 + Math.random() * 900000)).toString();     
       });
  }
  setValues(){
    this.ind.uniqueId = (Math.floor(10000000 + Math.random() * 900000)).toString();
    this.ind.srcIncome = 'Self Employed';
    this.mydob = new Date(1996, 6, 3);
    let birth_date =this.datepipe.transform(this.mydob, 'yyyy-MM-dd');
    this.dob = birth_date;
    this.ind.application = 'New';
    this.ind.requestedAmount = 150000;
    this.ind.loanPurpose = 'Investment';
    this.applicationDate = new Date();
    let latest_date =this.datepipe.transform(this.applicationDate, 'yyyy-MM-dd');
    this.myDate = latest_date;
    this.ind.duration = 12;
    this.annualInflow = 750000
  }
}
