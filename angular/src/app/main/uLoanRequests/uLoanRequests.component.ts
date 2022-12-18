import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { ULoanRequestsServiceProxy, ULoanRequestDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditULoanRequestModalComponent } from './create-or-edit-uLoanRequest-modal.component';

import { ViewULoanRequestModalComponent } from './view-uLoanRequest-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';


@Component({
    templateUrl: './uLoanRequests.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class ULoanRequestsComponent extends AppComponentBase {
    
    
    @ViewChild('createOrEditULoanRequestModal', { static: true }) createOrEditULoanRequestModal: CreateOrEditULoanRequestModalComponent;
    @ViewChild('viewULoanRequestModalComponent', { static: true }) viewULoanRequestModal: ViewULoanRequestModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    loanTypeFilter = '';
    maxAmountFilter : number;
		maxAmountFilterEmpty : number;
		minAmountFilter : number;
		minAmountFilterEmpty : number;
    maxTenorFilter : number;
		maxTenorFilterEmpty : number;
		minTenorFilter : number;
		minTenorFilterEmpty : number;
    statusFilter = '';

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
        injector: Injector,
        private _uLoanRequestsServiceProxy: ULoanRequestsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }

    getULoanRequests(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._uLoanRequestsServiceProxy.getAll(
            this.filterText,
            this.loanTypeFilter,
            this.maxAmountFilter == null ? this.maxAmountFilterEmpty: this.maxAmountFilter,
            this.minAmountFilter == null ? this.minAmountFilterEmpty: this.minAmountFilter,
            this.maxTenorFilter == null ? this.maxTenorFilterEmpty: this.maxTenorFilter,
            this.minTenorFilter == null ? this.minTenorFilterEmpty: this.minTenorFilter,
            this.statusFilter,
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

    createULoanRequest(): void {
        this.createOrEditULoanRequestModal.show();        
    }


    deleteULoanRequest(uLoanRequest: ULoanRequestDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._uLoanRequestsServiceProxy.delete(uLoanRequest.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }
    
    
    
    
}
