import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { QARatingDto, QualitativeAnalysisServiceProxy, SetupQualitativesServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'scorecardModal',
  templateUrl: './cooperate-scorecard.component.html',
  styles: [
  ]
})
export class CooperateScorecardComponent extends AppComponentBase implements OnInit {
  coopList:QARatingDto[]=[];
  returnNo: number;
  active = false;
  saving =false;

  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
@ViewChild('scorecardModal') modal: ModalDirective;
  constructor(private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private _service2: SetupQualitativesServiceProxy,
    private route: ActivatedRoute,
    private router: Router,) { super(inj)}

  ngOnInit(): void {
  }

  show(): void{
    this.getLatestCooperateScore();
    this.modal.show();
  }
  getLatestCooperateScore(){
  this._service2.getLatestCooperateScore().subscribe(res=>{
    this.returnNo = res;
    this.getCooperateRate();
    // console.log(this.returnNo);
  });}



  getCooperateRate(){
    if(this.returnNo<=0){
      this._service.rateCooperateUser(0).subscribe(res=>{
        this.coopList = res;
        // console.log(this.coopList);
                // console.log(this.coopList);
      });
    }else {
      this._service.rateCooperateUser(this.returnNo).subscribe(res=>{
        this.coopList = res;
        // console.log(this.coopList);
      });
    }
    
  }

  close(): void {
    this.modal.hide();
    this.active = false;
}
}
