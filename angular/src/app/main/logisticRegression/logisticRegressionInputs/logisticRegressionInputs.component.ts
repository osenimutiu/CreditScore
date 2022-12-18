import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { LogisticRegressionInputsServiceProxy, LogisticRegressionInputDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLogisticRegressionInputModalComponent } from './create-or-edit-logisticRegressionInput-modal.component';

import { ViewLogisticRegressionInputModalComponent } from './view-logisticRegressionInput-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';


@Component({
    templateUrl: './logisticRegressionInputs.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class LogisticRegressionInputsComponent extends AppComponentBase {
    
    
    @ViewChild('createOrEditLogisticRegressionInputModal', { static: true }) createOrEditLogisticRegressionInputModal: CreateOrEditLogisticRegressionInputModalComponent;
    @ViewChild('viewLogisticRegressionInputModalComponent', { static: true }) viewLogisticRegressionInputModal: ViewLogisticRegressionInputModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    maxLocationFilter : number;
		maxLocationFilterEmpty : number;
		minLocationFilter : number;
		minLocationFilterEmpty : number;
    maxRent_binFilter : number;
		maxRent_binFilterEmpty : number;
		minRent_binFilter : number;
		minRent_binFilterEmpty : number;
    maxRent_to_Income_binFilter : number;
		maxRent_to_Income_binFilterEmpty : number;
		minRent_to_Income_binFilter : number;
		minRent_to_Income_binFilterEmpty : number;
    maxReturn_on_Assets_binFilter : number;
		maxReturn_on_Assets_binFilterEmpty : number;
		minReturn_on_Assets_binFilter : number;
		minReturn_on_Assets_binFilterEmpty : number;
    maxTotal_assets_binFilter : number;
		maxTotal_assets_binFilterEmpty : number;
		minTotal_assets_binFilter : number;
		minTotal_assets_binFilterEmpty : number;
    good_BadFilter = -1;
    training_TestFilter = -1;






    constructor(
        injector: Injector,
        private _logisticRegressionInputsServiceProxy: LogisticRegressionInputsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getLogisticRegressionInputs(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._logisticRegressionInputsServiceProxy.getAll(
            this.filterText,
            this.maxLocationFilter == null ? this.maxLocationFilterEmpty: this.maxLocationFilter,
            this.minLocationFilter == null ? this.minLocationFilterEmpty: this.minLocationFilter,
            this.maxRent_binFilter == null ? this.maxRent_binFilterEmpty: this.maxRent_binFilter,
            this.minRent_binFilter == null ? this.minRent_binFilterEmpty: this.minRent_binFilter,
            this.maxRent_to_Income_binFilter == null ? this.maxRent_to_Income_binFilterEmpty: this.maxRent_to_Income_binFilter,
            this.minRent_to_Income_binFilter == null ? this.minRent_to_Income_binFilterEmpty: this.minRent_to_Income_binFilter,
            this.maxReturn_on_Assets_binFilter == null ? this.maxReturn_on_Assets_binFilterEmpty: this.maxReturn_on_Assets_binFilter,
            this.minReturn_on_Assets_binFilter == null ? this.minReturn_on_Assets_binFilterEmpty: this.minReturn_on_Assets_binFilter,
            this.maxTotal_assets_binFilter == null ? this.maxTotal_assets_binFilterEmpty: this.maxTotal_assets_binFilter,
            this.minTotal_assets_binFilter == null ? this.minTotal_assets_binFilterEmpty: this.minTotal_assets_binFilter,
            this.good_BadFilter,
            this.training_TestFilter,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getSkipCount(this.paginator, event),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createLogisticRegressionInput(): void {
        this.createOrEditLogisticRegressionInputModal.show();        
    }


    deleteLogisticRegressionInput(logisticRegressionInput: LogisticRegressionInputDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._logisticRegressionInputsServiceProxy.delete(logisticRegressionInput.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._logisticRegressionInputsServiceProxy.getLogisticRegressionInputsToExcel(
        this.filterText,
            this.maxLocationFilter == null ? this.maxLocationFilterEmpty: this.maxLocationFilter,
            this.minLocationFilter == null ? this.minLocationFilterEmpty: this.minLocationFilter,
            this.maxRent_binFilter == null ? this.maxRent_binFilterEmpty: this.maxRent_binFilter,
            this.minRent_binFilter == null ? this.minRent_binFilterEmpty: this.minRent_binFilter,
            this.maxRent_to_Income_binFilter == null ? this.maxRent_to_Income_binFilterEmpty: this.maxRent_to_Income_binFilter,
            this.minRent_to_Income_binFilter == null ? this.minRent_to_Income_binFilterEmpty: this.minRent_to_Income_binFilter,
            this.maxReturn_on_Assets_binFilter == null ? this.maxReturn_on_Assets_binFilterEmpty: this.maxReturn_on_Assets_binFilter,
            this.minReturn_on_Assets_binFilter == null ? this.minReturn_on_Assets_binFilterEmpty: this.minReturn_on_Assets_binFilter,
            this.maxTotal_assets_binFilter == null ? this.maxTotal_assets_binFilterEmpty: this.maxTotal_assets_binFilter,
            this.minTotal_assets_binFilter == null ? this.minTotal_assets_binFilterEmpty: this.minTotal_assets_binFilter,
            this.good_BadFilter,
            this.training_TestFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
    
}
