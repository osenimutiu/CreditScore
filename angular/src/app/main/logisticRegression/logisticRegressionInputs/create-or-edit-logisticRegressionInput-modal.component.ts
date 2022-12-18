import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { LogisticRegressionInputsServiceProxy, CreateOrEditLogisticRegressionInputDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';


@Component({
    selector: 'createOrEditLogisticRegressionInputModal',
    templateUrl: './create-or-edit-logisticRegressionInput-modal.component.html'
})
export class CreateOrEditLogisticRegressionInputModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    logisticRegressionInput: CreateOrEditLogisticRegressionInputDto = new CreateOrEditLogisticRegressionInputDto();



    constructor(
        injector: Injector,
        private _logisticRegressionInputsServiceProxy: LogisticRegressionInputsServiceProxy
    ) {
        super(injector);
    }
    
    show(logisticRegressionInputId?: number): void {
    

        if (!logisticRegressionInputId) {
            this.logisticRegressionInput = new CreateOrEditLogisticRegressionInputDto();
            this.logisticRegressionInput.id = logisticRegressionInputId;

            this.active = true;
            this.modal.show();
        } else {
            this._logisticRegressionInputsServiceProxy.getLogisticRegressionInputForEdit(logisticRegressionInputId).subscribe(result => {
                this.logisticRegressionInput = result.logisticRegressionInput;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._logisticRegressionInputsServiceProxy.createOrEdit(this.logisticRegressionInput)
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
