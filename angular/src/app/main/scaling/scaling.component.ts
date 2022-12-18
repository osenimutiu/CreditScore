import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-scaling',
  templateUrl: './scaling.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScalingComponent extends AppComponentBase implements OnInit {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  result:any=[];
  constructor(private injector: Injector,
    private _service: ScoreCardServiceProxy,
    private route: ActivatedRoute,
   private router: Router) {  super(injector)}

  ngOnInit(): void {
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getScaling(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getScaling(
       
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  
}
