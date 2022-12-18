import { Component, Injector, ViewEncapsulation, ViewChild } from '@angular/core';
import { ActivatedRoute , Router} from '@angular/router';
import { QualitativeSetupsServiceProxy, QualitativeSetupDto  } from '@shared/service-proxies/service-proxies';
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
    templateUrl: './qualitativeSetups.component.html',
    encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()]
})
export class QualitativeSetupsComponent extends AppComponentBase {
    
    
       
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

    advancedFiltersAreShown = false;
    filterText = '';
    sectionFilter = '';
    subHeadingFilter = '';
    qualitativeFilter = '';
    maxValueFilter : number;
		maxValueFilterEmpty : number;
		minValueFilter : number;
		minValueFilterEmpty : number;
    statusFilter = -1;






    constructor(
        injector: Injector,
        private _qualitativeSetupsServiceProxy: QualitativeSetupsServiceProxy,
        private _notifyService: NotifyService,
        private _tokenAuth: TokenAuthServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _fileDownloadService: FileDownloadService,
			private _router: Router
    ) {
        super(injector);
    }

    getQualitativeSetups(event?: LazyLoadEvent) {
        if (this.primengTableHelper.shouldResetPaging(event)) {
            this.paginator.changePage(0);
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this._qualitativeSetupsServiceProxy.getAll(
            this.filterText,
            this.sectionFilter,
            this.subHeadingFilter,
            this.qualitativeFilter,
            this.maxValueFilter == null ? this.maxValueFilterEmpty: this.maxValueFilter,
            this.minValueFilter == null ? this.minValueFilterEmpty: this.minValueFilter,
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

    createQualitativeSetup(): void {
        this._router.navigate(['/app/main/cooperate/qualitativeSetups/createOrEdit']);        
    }


    deleteQualitativeSetup(qualitativeSetup: QualitativeSetupDto): void {
        this.message.confirm(
            '',
            this.l('AreYouSure'),
            (isConfirmed) => {
                if (isConfirmed) {
                    this._qualitativeSetupsServiceProxy.delete(qualitativeSetup.id)
                        .subscribe(() => {
                            this.reloadPage();
                            this.notify.success(this.l('SuccessfullyDeleted'));
                        });
                }
            }
        );
    }

    exportToExcel(): void {
        this._qualitativeSetupsServiceProxy.getQualitativeSetupsToExcel(
        this.filterText,
            this.sectionFilter,
            this.subHeadingFilter,
            this.qualitativeFilter,
            this.maxValueFilter == null ? this.maxValueFilterEmpty: this.maxValueFilter,
            this.minValueFilter == null ? this.minValueFilterEmpty: this.minValueFilter,
            this.statusFilter,
        )
        .subscribe(result => {
            this._fileDownloadService.downloadTempFile(result);
         });
    }
    
    
    
    
}
