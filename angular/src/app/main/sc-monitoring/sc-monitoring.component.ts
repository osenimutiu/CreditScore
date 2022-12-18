import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { QualitativeAnalysisServiceProxy, SCMonitoringDto } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
  selector: 'app-sc-monitoring',
  templateUrl: './sc-monitoring.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScMonitoringComponent extends AppComponentBase implements OnInit {
  monitorings: SCMonitoringDto[] = [];
  p:number = 1;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  constructor(
    private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(inj);
  }

  ngOnInit(): void {
    this.getSCMonitoring();
  }
  getSCMonitoring(){
    this._service.getSCMonitoring().subscribe(res=>{
      this.monitorings = res;
    });
  }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  delete(del: SCMonitoringDto){
    this.message.confirm( 
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._service.deleteSCMonitoring(del.id)
              .subscribe(() => {
                      this.notify.success(this.l('Successfully Deleted'));
                      _.remove(this.monitorings, del);
                      this.getSCMonitoring();
                  });
          }
      });
  }
  
}
