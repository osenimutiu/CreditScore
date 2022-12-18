import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { LoanRequestsServiceProxy, LoanRequestDto, SMELendingApplyListDto, SMELendingApplyServiceProxy  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditLoanRequestModalComponent } from './create-or-edit-loanRequest-modal.component';

import { ViewLoanRequestModalComponent } from './view-loanRequest-modal.component';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';


@Component({
    templateUrl: './loanRequests.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class LoanRequestsComponent extends AppComponentBase {
    smeLendings: SMELendingApplyListDto[] = [];
    
    @ViewChild('createOrEditLoanRequestModal', { static: true }) createOrEditLoanRequestModal: CreateOrEditLoanRequestModalComponent;
    @ViewChild('viewLoanRequestModalComponent', { static: true }) viewLoanRequestModal: ViewLoanRequestModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    businessNameFilter = '';
    customerFilter = '';
    loanTypeFilter = '';
    maxAmountFilter : number;
    maxAmountFilterEmpty : number;
	minAmountFilter : number;
	minAmountFilterEmpty : number;
    maxTenorFilter : number;
	maxTenorFilterEmpty : number;
	minTenorFilter : number;
	minTenorFilterEmpty : number;
    statuaFilter = '';



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
        private _loanRequestsServiceProxy: LoanRequestsServiceProxy,
        private _smeLendingService:SMELendingApplyServiceProxy,
        private _notifyService: NotifyService,
        private route: ActivatedRoute,
        private router: Router,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService
    ) {
        super(injector);
    }


    ngOnInit(): void {
        // console.log( this.getSMELendings());
       
    }
    getSMELendings(event?: LazyLoadEvent): void{
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._smeLendingService.getSMELendingApply(
            this.filterText,
            this.businessNameFilter,
            // this.primengTableHelper.getSorting(this.dataTable),
            // this.primengTableHelper.getSkipCount(this.paginator, event),
            // this.primengTableHelper.getMaxResultCount(this.paginator, event)
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    getLoanRequests(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._loanRequestsServiceProxy.getAll(
            this.filterText,
            this.customerFilter,
            this.loanTypeFilter,
            this.maxAmountFilter == null ? this.maxAmountFilterEmpty: this.maxAmountFilter,
            this.minAmountFilter == null ? this.minAmountFilterEmpty: this.minAmountFilter,
            this.maxTenorFilter == null ? this.maxTenorFilterEmpty: this.maxTenorFilter,
            this.minTenorFilter == null ? this.minTenorFilterEmpty: this.minTenorFilter,
            this.statuaFilter,
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

    reload() {
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
        this.router.onSameUrlNavigation = 'reload';
        this.router.navigate(['./'], { relativeTo: this.route });
      }
    createLoanRequest(): void {
        this.createOrEditLoanRequestModal.show();        
    }


    deleteLoanRequest(loanRequest: LoanRequestDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._loanRequestsServiceProxy.delete(loanRequest.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._loanRequestsServiceProxy.getLoanRequestsToExcel(
        this.filterText,
            this.customerFilter,
            this.loanTypeFilter,
            this.maxAmountFilter == null ? this.maxAmountFilterEmpty: this.maxAmountFilter,
            this.minAmountFilter == null ? this.minAmountFilterEmpty: this.minAmountFilter,
            this.maxTenorFilter == null ? this.maxTenorFilterEmpty: this.maxTenorFilter,
            this.minTenorFilter == null ? this.minTenorFilterEmpty: this.minTenorFilter,
            this.statuaFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
    
}
