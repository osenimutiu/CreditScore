import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, DescriptiveStatisticsDto } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-distriptive-statistics',
  templateUrl: './distriptive-statistics.component.html', 
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class DistriptiveStatisticsComponent extends AppComponentBase implements OnInit {
list: DescriptiveStatisticsDto[] = [];
result:any=[];
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
  constructor(
    injector: Injector,
    private _service: CurveServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector)
  }

  ngOnInit(): void {
  }
// getAllDescriptiveStat(){
//   this._service.getDescriptiveStatistics().subscribe(res =>{
//     this.list = res;
//   })
// }

getAllDescriptiveStat(event?: LazyLoadEvent): void{
  if (this.primengTableHelper.shouldResetPaging(event)) {
    this.paginator.changePage(0);
    return;
}

this.primengTableHelper.showLoadingIndicator();
  this._service.getDescriptiveStatistics(
     
     ) .subscribe((result) => {
      this.primengTableHelper.records = result;
      this.result.push(this.primengTableHelper.records);
      this.primengTableHelper.hideLoadingIndicator();
    });
}
reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
