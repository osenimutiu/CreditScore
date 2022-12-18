import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { IndividualServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-bank-acc',
  templateUrl: './bank-acc.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class BankAccComponent extends AppComponentBase implements OnInit {
  result:any=[];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
 @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  constructor(
    injector: Injector,
    private _service: IndividualServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
  ) {   super(injector) }

  ngOnInit(): void {
  }
  getBankAccount(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getBankAccounts(
       
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
