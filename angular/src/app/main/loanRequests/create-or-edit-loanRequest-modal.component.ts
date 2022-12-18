import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { LoanRequestsServiceProxy, CreateOrEditLoanRequestDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';


@Component({
    selector: 'createOrEditLoanRequestModal',
    templateUrl: './create-or-edit-loanRequest-modal.component.html'
})
export class CreateOrEditLoanRequestModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    loanRequest: CreateOrEditLoanRequestDto = new CreateOrEditLoanRequestDto();



    constructor(
        injector: Injector,
        private _loanRequestsServiceProxy: LoanRequestsServiceProxy
    ) {
        super(injector);
    }
    
    show(loanRequestId?: number): void {
    

        if (!loanRequestId) {
            this.loanRequest = new CreateOrEditLoanRequestDto();
            this.loanRequest.id = loanRequestId;

            this.active = true;
            this.modal.show();
        } else {
            this._loanRequestsServiceProxy.getLoanRequestForEdit(loanRequestId).subscribe(result => {
                this.loanRequest = result.loanRequest;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._loanRequestsServiceProxy.createOrEdit(this.loanRequest)
             .pipe(finalize(() => { this.saving = false;}))
             .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
             });
    }







    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
