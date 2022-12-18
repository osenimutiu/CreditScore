import { Component, ViewChild, Injector, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { GetLogisticRegressionInputForViewDto, LogisticRegressionInputDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';

@Component({
    selector: 'viewLogisticRegressionInputModal',
    templateUrl: './view-logisticRegressionInput-modal.component.html'
})
export class ViewLogisticRegressionInputModalComponent extends AppComponentBase {

    @ViewChild('createOrEditModal', { static: true }) modal: ModalDirective;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active = false;
    saving = false;

    item: GetLogisticRegressionInputForViewDto;


    constructor(
        injector: Injector
    ) {
        super(injector);
        this.item = new GetLogisticRegressionInputForViewDto();
        this.item.logisticRegressionInput = new LogisticRegressionInputDto();
    }

    show(item: GetLogisticRegressionInputForViewDto): void {
        this.item = item;
        this.active = true;
        this.modal.show();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
