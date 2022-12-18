import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { LogisticRegEquationDto, LogisticRegressionOutputDto, LogRegressionServiceProxy, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  // selector: 'app-log-reg-output',
  selector: 'logRegOutput',
  templateUrl: './log-reg-output.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class LogRegOutputComponent  extends AppComponentBase implements OnInit {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  @ViewChild('modal') modal: ModalDirective;
  active: boolean = false;
  p:number = 1;
  result:any=[];
  saving: boolean = false;
  regOutputs: LogisticRegressionOutputDto[]= [];
  logRegEq: LogisticRegEquationDto[]= [];
    constructor(private injector: Injector,
       private _service: LogRegressionServiceProxy,
       private _scorecardService: ScoreCardServiceProxy,
       private route: ActivatedRoute,
      private router: Router)
     {
       super(injector)
      }
  
    ngOnInit(): void {
    }
    getLogisticRegressionOutput(event?: LazyLoadEvent): void{
      if (this.primengTableHelper.shouldResetPaging(event)) {
        this.paginator.changePage(0);
        return;
    }
  
    this.primengTableHelper.showLoadingIndicator();
      this._service.getAllLogisticRegressionOutput(
         
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

    show(): void {
      // this.getregOutput();
      this.getLogRegEquation()
      this.active = true;
      this.modal.show();
  }

  getregOutput(){
    this._service.getAllLogisticRegressionOutput().subscribe(re=>{
      this.regOutputs = re;
    });
  }
  close(): void {
    this.modal.hide();
    this.active = false;
  }

  getLogRegEquation(){
    this._scorecardService.getLogisticRegEquation().subscribe(result=>{
      this.logRegEq = result;
    })
  }
  }
  