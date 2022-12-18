import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetLoanRequestForViewDto, LoanRequestDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewLoanRequestModal',
    templateUrl: './view-loanRequest-modal.component.html'
})
export class ViewLoanRequestModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetLoanRequestForViewDto;

    
getColor(recommend){ (2)
    switch (recommend){
      case 'Approve' :
        return '#89eb34';
      case 'Review' :
        return 'yellow';
      case 'Reject' :
        return '#fc030b';
    }
  }

    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetLoanRequestForViewDto();
        this.item.loanRequest = new LoanRequestDto();
    }

    show(item: GetLoanRequestForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
