import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetRegressionOutputForViewDto, RegressionOutputDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewRegressionOutputModal',
    templateUrl: './view-regressionOutput-modal.component.html'
})
export class ViewRegressionOutputModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetRegressionOutputForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetRegressionOutputForViewDto();
        this.item.regressionOutput = new RegressionOutputDto();
    }

    show(item: GetRegressionOutputForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
