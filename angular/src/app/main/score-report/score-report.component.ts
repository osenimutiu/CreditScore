import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { GetTblScoreReportForEditOutput, ScoreCardServiceProxy, ScoreReportDto, TblCutOffDto } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-score-report',
  templateUrl: './score-report.component.html',
  animations: [appModuleAnimation()],
  // styleUrls: ['./score-report.component.css']
  styles: [
  ]
})
export class ScoreReportComponent extends AppComponentBase implements OnInit {
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
listScoreReport: ScoreReportDto[] = [];
p:number = 1;
totalamount: number;
totalCutOff: number;
cutOff:number= 600;
rating:string;
eqttota:number;
search: string;
distList:any=[];
  modifiedText: string;
constructor(private injector: Injector,
  private _service: ScoreCardServiceProxy,
  private route: ActivatedRoute,
 private router: Router) {
  super(injector)
}

  ngOnInit(): void {
    // this.getScoreReport();
    // this.getCuOff();
    // this.getReport();
    this.getDistName();
  }

  getScoreReport(){
    this._service.getScoreReport(this.search).subscribe(res => {
      this.listScoreReport = res;
      this.getTotal();
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

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

//   getTotal() {
//     let total = 0;
//     for (var i = 0; i < this.listScoreReport.length; i++) {
//         if (this.listScoreReport[i].score) {
//             total += this.listScoreReport[i].score;
//             this.totalamount = total;
//             if(this.totalamount == this.cutOff || this.totalamount > this.cutOff){
//               this.grade = 'Excellent';
//               this.decision = 'Accept';
//             } else{
//               this.grade = 'Poor';
//               this.decision = 'Reject';
//             }
//         }
//     }
//     return total;
// }


  getTotal() {
    let total = 0;
    for (var i = 0; i < this.listScoreReport.length; i++) {
        if (this.listScoreReport[i].score) {
            total += this.listScoreReport[i].score;
            this.totalamount = total;
            if(this.totalamount < 500 ){
              this.rating = 'CCC/C';
            }
            if(this.totalamount > 499 && this.totalamount < 520 ){
              this.rating = 'B-';
            }
            if(this.totalamount > 519 && this.totalamount < 540  ){
              this.rating = 'B';
            }
            if(this.totalamount > 539 && this.totalamount < 560 ){
              this.rating = 'B+';
            }
            if(this.totalamount > 559 && this.totalamount < 580  ){
              this.rating = 'BB-';
            }
            if(this.totalamount > 579 && this.totalamount < 600  ){
              this.rating = 'BB-';
            }
            if(this.totalamount > 599 && this.totalamount < 620  ){
              this.rating = 'BB+';
            }
            if(this.totalamount > 619 && this.totalamount < 640  ){
              this.rating = 'BBB-';
            }
            if(this.totalamount > 639 && this.totalamount < 660){
              this.rating = 'BBB';
            }
            if(this.totalamount > 659 && this.totalamount < 680){
              this.rating = 'BBB+';
            }
            if(this.totalamount > 679 && this.totalamount < 700){
              this.rating = 'A-';
            }
            if(this.totalamount > 699 && this.totalamount < 720){
              this.rating = 'A';
            }
            if(this.totalamount > 719 && this.totalamount < 740){
              this.rating = 'A+';
            }
            if(this.totalamount > 739 && this.totalamount < 760){
              this.rating = 'AA-';
            }
            if(this.totalamount > 759 && this.totalamount < 780){
              this.rating = 'AA-';
            }
            if(this.totalamount > 779 && this.totalamount < 800){
              this.rating = 'AA+';
            }
            if(this.totalamount > 799 ){
              this.rating = 'AAA';
            }
          
        }
    }
    // console.log(this.totalamount)
    return total;
}


  

getColor(recommend){ (1)
  switch (recommend){
    case 'Excellent' :
      return '#128a38';
    case 'Poor' :
      return '#fc030b';
  }
}
getColorDecision(recommend){ (1)
  switch (recommend){
    case 'Approved' :
      return '#128a38';
    case 'Reject' :
      return '#fc030b';
  }
}

}
