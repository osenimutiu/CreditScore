import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SMELendingApplyListDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'viewRequestModal',
  templateUrl: './view-request-modal.component.html',
  styles: [
  ]
})
export class ViewRequestModalComponent  extends AppComponentBase {
  @ViewChild('viewRequestModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  active = false;
  saving = false;
  item: SMELendingApplyListDto;
  constructor(
    injector: Injector
  ) { 
    super(injector);
    this.item = new SMELendingApplyListDto();
  }

  show(item: SMELendingApplyListDto): void {
    this.item = item;
    this.active = true;
    this.modal.show();
}

close(): void {
  this.active = false;
  this.modal.hide();
}

}
