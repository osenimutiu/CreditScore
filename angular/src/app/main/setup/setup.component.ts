import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateSetUpItemDto, MethodListDto, SetUpItemServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';
import { LazyLoadEvent } from 'primeng/public_api';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-setup',
  templateUrl: './setup.component.html', 
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SetupComponent extends AppComponentBase implements OnInit {
result:any=[];
@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
setUp: CreateSetUpItemDto = new CreateSetUpItemDto();
@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
  constructor(
    injector: Injector,
    private _service: SetUpItemServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    super(injector)
   }

  ngOnInit(): void {
    
  }

  getSetUpList(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getSetUpList(
       
       ) .subscribe((result) => {
        this.primengTableHelper.records = result.items;
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
