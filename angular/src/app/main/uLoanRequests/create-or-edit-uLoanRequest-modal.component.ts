import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { ULoanRequestsServiceProxy, CreateOrEditULoanRequestDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';


@Component({
    selector: 'createOrEditULoanRequestModal',
    templateUrl: './create-or-edit-uLoanRequest-modal.component.html'
})
export class CreateOrEditULoanRequestModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    uLoanRequest: CreateOrEditULoanRequestDto = new CreateOrEditULoanRequestDto();



    constructor(
        injector: Injector,
        private _uLoanRequestsServiceProxy: ULoanRequestsServiceProxy
    ) {
        super(injector);
    }
    
    show(uLoanRequestId?: number): void {
    

        if (!uLoanRequestId) {
            this.uLoanRequest = new CreateOrEditULoanRequestDto();
            this.uLoanRequest.id = uLoanRequestId;

            this.active = true;
            this.modal.show();
        } else {
            this._uLoanRequestsServiceProxy.getULoanRequestForEdit(uLoanRequestId).subscribe(result => {
                this.uLoanRequest = result.uLoanRequest;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._uLoanRequestsServiceProxy.createOrEdit(this.uLoanRequest)
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
