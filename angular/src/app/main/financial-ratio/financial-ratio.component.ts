import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { FinancialRatioListDto, FinancialRatioServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';
import { CreateFinancialRatioModalComponent } from './create-financial-ratio-modal/create-financial-ratio-modal.component';

@Component({
  selector: 'app-financial-ratio',
  templateUrl: './financial-ratio.component.html',
  animations: [appModuleAnimation()], 
  styles: [ 
  ]
})
export class FinancialRatioComponent extends AppComponentBase {
  filterText = '';
  ratioNameFilter = '';
  advancedFiltersAreShown = false;

  financialRatios: FinancialRatioListDto[] = [];
    
  @ViewChild('createFinancialRatioModal', { static: true }) createOrEditFinancialModal: CreateFinancialRatioModalComponent;
 
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;



  constructor(
    injector: Injector,
    private route: ActivatedRoute,
        private router: Router,
    private _financialRatioService: FinancialRatioServiceProxy
  ) {
    super(injector);
   }

  ngOnInit(): void {
  }

  getFinancialRatios(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
        this.paginator.changePage(0);
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._financialRatioService.getFinancialRatio(
        this.filterText,
        this.ratioNameFilter,
        // this.primengTableHelper.getSorting(this.dataTable),
        // this.primengTableHelper.getSkipCount(this.paginator, event),
        // this.primengTableHelper.getMaxResultCount(this.paginator, event)
    ).subscribe(result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}


}
