import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SMELendingApplyListDto, SMELendingApplyServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';
import { ViewRequestModalComponent } from './view-request-modal/view-request-modal.component';

@Component({
  selector: 'app-submitted-loan-request',
  templateUrl: './submitted-loan-request.component.html',
  encapsulation: ViewEncapsulation.None,
    animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SubmittedLoanRequestComponent extends AppComponentBase {
  smeLendings: SMELendingApplyListDto[] = [];

  advancedFiltersAreShown = false;
  filterText = '';
  businessNameFilter = '';
   @ViewChild('viewRequestModalComponent', { static: true }) viewRequestModalComponent: ViewRequestModalComponent;   
    
    @ViewChild('dataTable', { static: true }) dataTable: Table;
    @ViewChild('paginator', { static: true }) paginator: Paginator;

  constructor(
    injector: Injector,
    private _smeLendingService: SMELendingApplyServiceProxy,
    private route: ActivatedRoute,
        private router: Router,
  ) {
    super(injector);
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

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

deleteRequest(request: SMELendingApplyListDto): void {
  this.message.confirm(
      '',
      this.l('Are You Sure to reject this request?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._smeLendingService.deleteSMELendingApply(request.id)
                  .subscribe(() => {
                     this.notify.success(this.l('Successfully Deleted'));
                     this.getSMELendings();
                  });
          }
      }
  );
}

}


