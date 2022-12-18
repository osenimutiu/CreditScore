import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'smelendingModal',
  templateUrl: './sme-lending-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SmeLendingModalComponent extends AppComponentBase {
  @ViewChild('modal') modal: ModalDirective;
  active: boolean = false;
  constructor(
    private inj: Injector
  ) { 
    super(inj)
  }

  ngOnInit(): void {
  }

  show(): void {
    this.active = true;
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

}
