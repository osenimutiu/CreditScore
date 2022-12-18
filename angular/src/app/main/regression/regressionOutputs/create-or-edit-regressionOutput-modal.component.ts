import { Component, ViewChild, Injector, Output, EventEmitter} from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import { RegressionOutputsServiceProxy, CreateOrEditRegressionOutputDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as moment from 'moment';


@Component({
    selector: 'createOrEditRegressionOutputModal',
    templateUrl: './create-or-edit-regressionOutput-modal.component.html'
})
export class CreateOrEditRegressionOutputModalComponent extends AppComponentBase {
   
    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    regressionOutput: CreateOrEditRegressionOutputDto = new CreateOrEditRegressionOutputDto();



    constructor(
        injector: Injector,
        private _regressionOutputsServiceProxy: RegressionOutputsServiceProxy
    ) {
        super(injector);
    }
    
    show(regressionOutputId?: number): void {
    

        if (!regressionOutputId) {
            this.regressionOutput = new CreateOrEditRegressionOutputDto();
            this.regressionOutput.id = regressionOutputId;

            this.active = true;
            this.modal.show();
        } else {
            this._regressionOutputsServiceProxy.getRegressionOutputForEdit(regressionOutputId).subscribe(result => {
                this.regressionOutput = result.regressionOutput;


                this.active = true;
                this.modal.show();
            });
        }
        
    }

    save(): void {
            this.saving = true;

			
			
            this._regressionOutputsServiceProxy.createOrEdit(this.regressionOutput)
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
