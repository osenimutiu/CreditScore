import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { RegressionOutputsServiceProxy, RegressionOutputDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditRegressionOutputModalComponent } from './create-or-edit-regressionOutput-modal.component';

import { ViewRegressionOutputModalComponent } from './view-regressionOutput-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';


@Component({
    templateUrl: './regressionOutputs.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class RegressionOutputsComponent extends AppComponentBase {
    
    
    @ViewChild('createOrEditRegressionOutputModal', { static: true }) createOrEditRegressionOutputModal: CreateOrEditRegressionOutputModalComponent;
    @ViewChild('viewRegressionOutputModalComponent', { static: true }) viewRegressionOutputModal: ViewRegressionOutputModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    paramNameFilter = '';
    maxCoeff_EstimateFilter : number;
		maxCoeff_EstimateFilterEmpty : number;
		minCoeff_EstimateFilter : number;
		minCoeff_EstimateFilterEmpty : number;
    maxStd_ErrorFilter : number;
		maxStd_ErrorFilterEmpty : number;
		minStd_ErrorFilter : number;
		minStd_ErrorFilterEmpty : number;
    maxt_valueFilter : number;
		maxt_valueFilterEmpty : number;
		mint_valueFilter : number;
		mint_valueFilterEmpty : number;
    maxp_valueFilter : number;
		maxp_valueFilterEmpty : number;
		minp_valueFilter : number;
		minp_valueFilterEmpty : number;






    constructor(
        injector: Injector,
        private _regressionOutputsServiceProxy: RegressionOutputsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getRegressionOutputs(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._regressionOutputsServiceProxy.getAll(
            this.filterText,
            this.paramNameFilter,
            this.maxCoeff_EstimateFilter == null ? this.maxCoeff_EstimateFilterEmpty: this.maxCoeff_EstimateFilter,
            this.minCoeff_EstimateFilter == null ? this.minCoeff_EstimateFilterEmpty: this.minCoeff_EstimateFilter,
            this.maxStd_ErrorFilter == null ? this.maxStd_ErrorFilterEmpty: this.maxStd_ErrorFilter,
            this.minStd_ErrorFilter == null ? this.minStd_ErrorFilterEmpty: this.minStd_ErrorFilter,
            this.maxt_valueFilter == null ? this.maxt_valueFilterEmpty: this.maxt_valueFilter,
            this.mint_valueFilter == null ? this.mint_valueFilterEmpty: this.mint_valueFilter,
            this.maxp_valueFilter == null ? this.maxp_valueFilterEmpty: this.maxp_valueFilter,
            this.minp_valueFilter == null ? this.minp_valueFilterEmpty: this.minp_valueFilter,
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

    createRegressionOutput(): void {
        this.createOrEditRegressionOutputModal.show();        
    }


    deleteRegressionOutput(regressionOutput: RegressionOutputDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._regressionOutputsServiceProxy.delete(regressionOutput.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._regressionOutputsServiceProxy.getRegressionOutputsToExcel(
        this.filterText,
            this.paramNameFilter,
            this.maxCoeff_EstimateFilter == null ? this.maxCoeff_EstimateFilterEmpty: this.maxCoeff_EstimateFilter,
            this.minCoeff_EstimateFilter == null ? this.minCoeff_EstimateFilterEmpty: this.minCoeff_EstimateFilter,
            this.maxStd_ErrorFilter == null ? this.maxStd_ErrorFilterEmpty: this.maxStd_ErrorFilter,
            this.minStd_ErrorFilter == null ? this.minStd_ErrorFilterEmpty: this.minStd_ErrorFilter,
            this.maxt_valueFilter == null ? this.maxt_valueFilterEmpty: this.maxt_valueFilter,
            this.mint_valueFilter == null ? this.mint_valueFilterEmpty: this.mint_valueFilter,
            this.maxp_valueFilter == null ? this.maxp_valueFilterEmpty: this.maxp_valueFilter,
            this.minp_valueFilter == null ? this.minp_valueFilterEmpty: this.minp_valueFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
    
}
