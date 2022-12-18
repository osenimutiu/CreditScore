import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailServiceProxy, EditRetailScoreInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'eligibilityModal',
  templateUrl: './eligibility-modal.component.html',
  styles: [
  ]
})
export class EligibilityModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  custList:any=[];  
  @ViewChild('modal') modal: ModalDirective;
  retail: EditRetailScoreInput = new EditRetailScoreInput();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  listCutOff:any = [];
totaScore: number;
totalCutOff: number;
decision:string;
  constructor(private inj: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { super(inj)}

  ngOnInit(): void {
  }
  show(id){
    this.active = true;
    this._service.getRetailScoreItemEdit(id).subscribe((result)=> {
      this.retail = result;
      this.getCustomer();
      this.getCuOff();
      this.modal.show();
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
  close(): void {
    this.modal.hide();
    this.active = false;
    // this.reload();
  }

  getCuOff(){
    this._service.getCutOff().subscribe(res=> {
      this.listCutOff = res;
      this.getTotalCutOff();
    });
  }
    
  getTotalCutOff() {
    let total = 0;
    for (var i = 0; i < this.listCutOff.length; i++) {
        if (this.listCutOff[i].cutOff) {
            total += this.listCutOff[i].cutOff;
            this.totalCutOff = total;
            if(this.totalCutOff == this.retail.score || this.totalCutOff < this.retail.score ){
              this.decision = 'May be awarded loan';
            }else{
              this.decision = 'May not be awarded loan';
            }

        }
    }
    return total;
  }

  getCustomer(){
    this._service.getExistingCustomer().subscribe(res=>{
      this.custList = res;
    });
  }

  getColor(recommend){ (2)
    switch (recommend){
      case 'May be awarded loan' :
        return '#086e1f';
      case 'Review' :
        return 'yellow';
      case 'May not be awarded loan' :
        return '#fc030b';
    }
  }
}
