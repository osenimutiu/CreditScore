import { Component, Injector, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, RegOutputRunDataDto, RegOutputServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { LazyLoadEvent } from 'primeng/public_api';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-reg-output',
  templateUrl: './reg-output.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class RegOutputComponent extends AppComponentBase {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  
  advancedFiltersAreShown = false;
  filterText = '';
  paramNameFilter = '';
  coeff_EstimateFilter = '';
  std_ErrorFilter = '';
  t_valueFilter = '';
  p_valueFilter = '';
  lastRunDate: RegOutputRunDataDto[] = [];
  
  constructor( injector: Injector,
    private _service: RegOutputServiceProxy,
    private _curveSrvice: CurveServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
    ) {
      super(injector);
     }

  ngOnInit(): void {
    this.getLastRunDate();
  }

  getRegOutputs(event?: LazyLoadEvent) {
    if (this.primengTableHelper.shouldResetPaging(event)) {
        this.paginator.changePage(0);
        return;
    }

    this.primengTableHelper.showLoadingIndicator();

    this._service.getAll(
        this.filterText,
        this.paramNameFilter,
        this.coeff_EstimateFilter,
        this.std_ErrorFilter,
        this.t_valueFilter,
        this.p_valueFilter,
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

runDate(){
  this._service.inserRunDate().subscribe(()=> {
    this.getLastRunDate();
  });
}
 getLastRunDate(){
   this._service.getLastRunDate().subscribe(res => {
     this.lastRunDate = res;
   })
 }

 runProcess(){
   this._curveSrvice.runProcess().subscribe(()=>{
    this.notify.success(this.l('Process run Successfully'));
    this.runDate();
    
   });
 }
}
