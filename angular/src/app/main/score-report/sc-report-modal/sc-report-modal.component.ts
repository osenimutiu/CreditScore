import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { GetTblScoreReportForEditOutput, ScoreCardServiceProxy, ScoreReportDto, TblCutOffDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'screportModal',
  templateUrl: './sc-report-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScReportModalComponent implements OnInit {
  id:number;
  cuttoffActive: boolean;
  item: GetTblScoreReportForEditOutput;
  listScoreReport: ScoreReportDto[] = [];
  decide:string;
  cutOff:number= 600;
  saving: boolean = false;
  active: boolean = false;
  totalamount: number;
  totalAmountb: number;
  decision:string;
  reports: GetTblScoreReportForEditOutput[] = [];
  totalCutOff: number;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  listCutOff: TblCutOffDto[] = []; 
  rating:string;
  constructor( private _service: ScoreCardServiceProxy,) {
    this.item = new GetTblScoreReportForEditOutput()
  
   }

  ngOnInit(): void {
  }
  getReportForView(){
    this.getCuOff();
    this.cuttoffActive = true;
   this._service.getTblScoreReportForEdit(this.id).subscribe(res =>{
     this.item = res;
     this.totalAmountb = this.item.totalScore;
     this.getTotalCutOff();
    //  this.decisionMaking();
   });
  }

  decisionMaking(){
    if(this.item.totalScore == this.cutOff || this.item.totalScore > this.cutOff){
      this.decide = 'Approved';
    }
    if(this.item.totalScore < this.cutOff){
      this.decide = 'Reject';
    }
    else{
      // this.decide = 'Reject';
    }
  }

  getReport(){
    this._service.getTblScoreReport().subscribe(res=>{
      this.reports = res;
    });
  }

  show(): void { 
    this.active = true;
    this.getReport();
    // this.getCuOff();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}
clearReject(){
  if(this.id == undefined)
  this.decision = '';
}
getTotalCutOff() {
  let total = 0;
  for (var i = 0; i < this.listCutOff.length; i++) {
      if (this.listCutOff[i].cutOff) {
          total += this.listCutOff[i].cutOff;
          this.totalCutOff = total;
          if(this.totalCutOff == this.totalAmountb || this.totalCutOff < this.totalAmountb){
            this.decision = 'Approved';
          } 
          // if( this.totalCutOff > this.totalamount){
          //   this.decision = 'Reject';
          // } 
          else{
            this.decision = 'Reject';
          }
      }
  }
  // console.log(this.totalCutOff);
  // console.log(this.decision);
  return total;
}

getCuOff(){
  this._service.getTblCutOff().subscribe(res => {
    this.listCutOff = res;
    this.getTotalCutOff();
  });
}

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


getColorDecision(recommend){ (1)
  switch (recommend){
    case 'Approved' :
      return '#128a38';
    case 'Reject' :
      return '#fc030b';
  }
}
}
