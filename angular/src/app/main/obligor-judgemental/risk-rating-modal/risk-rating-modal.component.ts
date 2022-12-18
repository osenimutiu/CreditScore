import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { 
  // CreateRiskRatingDto,
   QualitativeAnalysisServiceProxy, Tbl_scoreDto,
    // RiskRatingDto 
  } from '@shared/service-proxies/service-proxies';
// import { CreateRiskRatingDto, RiskRatingDto, RiskRatingServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'riskRatingModal',
  templateUrl: './risk-rating-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class RiskRatingModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  scores: Tbl_scoreDto[] = [];
  // riskRating: CreateRiskRatingDto = new CreateRiskRatingDto();
  // riskRatings: RiskRatingDto[]= [];
  distCat:any = [];
  cat:string;
  checks = false;


  radioSel:any;
  // radioSelected:string;
  radioSelected:number;
  realValue:number;
  // radioSelectedString:string;
  radioSelectedString:any; 
  finalArray: any[] = [];

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;

  constructor(private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {  super(inj);}

  ngOnInit(): void {
  }
  show(): void { 
    this.active = true;
    this.getScore();
    this.modal.show();
}
close(): void {
  this.modal.hide();
  this.active = false;
}

getScore(){
  this._service.getSelectedScores().subscribe(res =>{
    this.scores = res;
  });
}

// save(): void{
//   debugger;
//   this.saving = true;
//   this.riskRating.category = this.cat;
//   this.riskRating.score = this.realValue;
//      this._service.createRiskRating(this.riskRating)
//      .pipe(finalize(() => this.saving = false))
//      .subscribe(() =>{
//       this.notify.success(this.l('Save Successfully'));     
//      });
//      this.close();
//      this.modalSave.emit(this.riskRating);
//      this.reload();

// }

// getRatings(){
//   this._service.getRiskRatingItem(this.cat).subscribe(res =>{
//     this.riskRatings = res;
//     console.log(this.riskRatings);
//   });
// }
// getDistCat(){
//   this._service.getDistictCat().subscribe(res=>{
//     this.distCat = res;
//   });
// }

// getScore(){
//   this.updateScore();
// }
// updateScore(ctr:any){
//   debugger;
//   this.riskRating.option = this.riskRatings[ctr.selectedIndex].option;
//   this.riskRating.score = this.riskRatings[ctr.selectedIndex].score;
// }
// updateScore(ctr:any){
//   debugger;
//   this.riskRating.score = this.riskRatings[ctr.selectedIndex].score;
//   this.riskRating.option = this.riskRatings[ctr.selectedIndex].option;
// }

// reload() {
//   this.router.routeReuseStrategy.shouldReuseRoute = () => false;
//   this.router.onSameUrlNavigation = 'reload';
//   this.router.navigate(['./'], { relativeTo: this.route });
// }

// onItemChange(item){
//   this.getSelecteditem();
// }

// getSelecteditem(){
//   this.radioSel = this.riskRatings.find(Item => Item.score === this.radioSelected);
//   this.radioSelectedString = JSON.stringify(this.radioSel);
//   this.realValue = this.radioSelected;
// }
// radioChange(event, data) {
//   // var obj = this.riskRatings.filter(x => x.id == data.id)[0];
//   var obj = this.riskRatings.filter(x => x.id == data.id)[1];
//   obj.option = event.value;
//   if (!this.finalArray.some(x => x.id == data.id)) {
//     this.finalArray.push(obj);
//   }
// }
}
