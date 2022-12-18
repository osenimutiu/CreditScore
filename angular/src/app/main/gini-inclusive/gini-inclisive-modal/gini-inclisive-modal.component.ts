import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { GiniInclusiveDto, GiniInclusiveServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'giniInclusiveModal',
  templateUrl: './gini-inclisive-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class GiniInclisiveModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  auc:number;
  aul:number;
  area:number;
  giniCoef:number;
  concavity:number;
  giniInclusive: GiniInclusiveDto[] = [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('cuttOffInput') cuttOffInput: ElementRef;
  constructor(private _service: GiniInclusiveServiceProxy, private inj: Injector) { super(inj)}

  ngOnInit(): void {
  }

  show(): void { 
    // this.active = true;
    this.getginiInclusive();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  // this.active = false;
}
getginiInclusive(){
  this._service.getGiniInclusives().subscribe(res => {
     this.giniInclusive = res;
     this.compute();
  });
}

compute() {
  let total = 0;
  for (var i = 0; i < this.giniInclusive.length; i++) {
      if (this.giniInclusive[i].areaUnderCAP) {
          total += this.giniInclusive[i].areaUnderCAP;
          this.auc = total;
          this.aul = 0.5;
          this.area = this.auc - this.aul;
          this.giniCoef = this.auc / this.area;
          this.concavity = 1.009352;
      }
  }
  return total;
}
}
