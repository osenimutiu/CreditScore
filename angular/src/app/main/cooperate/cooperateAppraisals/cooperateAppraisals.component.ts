import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { CooperateAppraisalsServiceProxy, CooperateAppraisalDto  } from '@shared/service-proxies/service-proxies';
import { NotifyService } from 'abp-ng2-module';
import { AppComponentBase } from '@shared/common/app-component-base';
import { TokenAuthServiceProxy } from '@shared/service-proxies/service-proxies';


import { appModuleAnimation } from '@shared/animations/routerTransition';
import { Table } from 'primeng/table';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { FileDownloadService } from '@shared/utils/file-download.service';
import * as _ from 'lodash';
import * as moment from 'moment';


@Component({
    templateUrl: './cooperateAppraisals.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class CooperateAppraisalsComponent extends AppComponentBase {
    
    
       
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    companyNameFilter = '';
    rcNumberFilter = '';
    accountNumberFilter = '';
    maxScoreFilter : number;
		maxScoreFilterEmpty : number;
		minScoreFilter : number;
		minScoreFilterEmpty : number;
        setupQualitativeQualitativeFilter = '';






    constructor(
        injector: Injector,
        private _cooperateAppraisalsServiceProxy: CooperateAppraisalsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
			private _router: Router
    ) {
        super(injector);
    }

    getCooperateAppraisals(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._cooperateAppraisalsServiceProxy.getAll(
            this.filterText,
            this.companyNameFilter,
            this.rcNumberFilter,
            this.accountNumberFilter,
            this.maxScoreFilter == null ? this.maxScoreFilterEmpty: this.maxScoreFilter,
            this.minScoreFilter == null ? this.minScoreFilterEmpty: this.minScoreFilter,
            this.setupQualitativeQualitativeFilter,
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

    createCooperateAppraisal(): void {
        this._router.navigate(['/app/main/cooperate/cooperateAppraisals/createOrEdit']);        
    }


    deleteCooperateAppraisal(cooperateAppraisal: CooperateAppraisalDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._cooperateAppraisalsServiceProxy.delete(cooperateAppraisal.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._cooperateAppraisalsServiceProxy.getCooperateAppraisalsToExcel(
        this.filterText,
            this.companyNameFilter,
            this.rcNumberFilter,
            this.accountNumberFilter,
            this.maxScoreFilter == null ? this.maxScoreFilterEmpty: this.maxScoreFilter,
            this.minScoreFilter == null ? this.minScoreFilterEmpty: this.minScoreFilter,
            this.setupQualitativeQualitativeFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
    
}
