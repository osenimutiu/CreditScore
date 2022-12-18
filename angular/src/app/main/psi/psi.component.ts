import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, Tbl_PsiDto } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-psi',
  templateUrl: './psi.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class PsiComponent extends AppComponentBase implements OnInit {
psiList: Tbl_PsiDto[] = [];
@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
result:any=[];
totalamount: number;
decision: string;

  constructor(private route: ActivatedRoute,
    private router: Router,
     private _service: CurveServiceProxy, 
     private injector: Injector) 
     { 
       super(injector)
    }

  ngOnInit(): void {
    this.getPsi();
  }
   getPsi(): void{
       this._service.getPsi().subscribe(res => {
         this.psiList = res;
       })
   }

   reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getAllPsi(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPsi(
       
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
        this. getTotal();
      });
  }
  getTotal() {
    let total = 0;
    for (var i = 0; i < this.psiList.length; i++) {
        if (this.psiList[i].psi) {
            total += this.psiList[i].psi;
            this.totalamount = total;
            this.makeDecision();
        }
      }
    }
    makeDecision(){
      if(this.totalamount < 0.1){
        this.decision = 'No Changes';
      }
      if(this.totalamount > 0.09 && this.totalamount < 0.251){
        this.decision = 'Insignificant shift';
      }else{
        this.decision = 'Significant shift';
      }
    }

    getColorDecision(recommend){ (1)
      switch (recommend){
        case 'Significant shift' :
          return '#128a38';
        case 'Insignificant shift' :
          return '#fc030b';
        case 'No Changes' :
          return '#037bfc';
      }
    }
}
