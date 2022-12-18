import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { GiniInclusiveServiceProxy, QualitativeAnalysisServiceProxy, ScoreCardServiceProxy, ScoreReportDto, SetuPPageDto, Tbl_QualitativeAnalysisDto } from '@shared/service-proxies/service-proxies';
import { timeStamp } from 'console';

@Component({
  selector: 'app-setup-summary',
  templateUrl: './setup-summary.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
  styleUrls: ['setup-summary.component.scss'],
  // styles: [
  // ]
})
export class SetupSummaryComponent extends AppComponentBase implements OnInit {
  totalamount: number;
  overallWeight: number;
  creditScoreCount: number;
  qualitativeWeight: number;
  totalScore: number;
  search: string;
  distList:any=[];
  listScoreReport: ScoreReportDto[] = [];
  qualitatives: Tbl_QualitativeAnalysisDto[] = [];
  setUpPage: SetuPPageDto[] = [];
  modifiedText: string;
  constructor(private injector: Injector,
    private _service: ScoreCardServiceProxy,
    private _giniInclusiveService: GiniInclusiveServiceProxy,
    private route: ActivatedRoute, private _qAnalysis: QualitativeAnalysisServiceProxy,
   private router: Router) { super(injector) }

  ngOnInit(): void {
    // this.getScoreReport();
    // this.getTotalWeight();
    // this.getSetUpWeight();
    // this.getAnalysis();
    this.getDistName();
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getTotal() {
    let total = 0;
    for (var i = 0; i < this.listScoreReport.length; i++) {
        if (this.listScoreReport[i].score) {
            total += this.listScoreReport[i].score;
            this.totalamount = total;
        }
    }
    return total;
}

getTotalWeight() {
  let total = 0;
  for (var i = 0; i < this.qualitatives.length; i++) {
      if (this.qualitatives[i].weight) {
          total += this.qualitatives[i].weight;
          this.overallWeight = total;
      }
  }
  return total;
}
getScoreWeight() {
  let total = 0;
  for (var i = 0; i < this.setUpPage.length; i++) {
      if (this.setUpPage[i].creditScoreWeight) {
          total += this.setUpPage[i].creditScoreWeight;
          this.creditScoreCount = total;
      }
  }
  return total;
}
getQualitativeWeight() {
  let quatotal = 0;
  for (var i = 0; i < this.setUpPage.length; i++) {
      if (this.setUpPage[i].qualitativeAnalysisWeight) {
        quatotal += this.setUpPage[i].qualitativeAnalysisWeight;
          this.qualitativeWeight = quatotal;
      }
  }
  return quatotal;
}

getAnalysis(){
  this._qAnalysis.getQualitativeAnalysis().subscribe(res=>{
    this.qualitatives = res;
    this.getTotalWeight();
    this.getSetUpWeight();
  });
}  

getScoreReport(){
  this._service.getScoreReport(this.search).subscribe(res => {
    this.listScoreReport = res;
    this.getTotal();
    this.getAnalysis();
  });
}

getSetUpWeight(){
  this._giniInclusiveService.getSetUp().subscribe(res => {
    this.setUpPage = res;
    this.getScoreWeight();
    this.getQualitativeWeight();
    this.totalScore = this.totalamount + this.overallWeight;
  });
}
getDistName(){
  this._service.getDistinctNames().subscribe(res => {
    this.distList = res;
  });
}

getSelectedItem(val:any){
  this.customFunction(val);
}
 customFunction(val:any){
  this.modifiedText = val + " selected";
  this.getScoreReport();
}

}
