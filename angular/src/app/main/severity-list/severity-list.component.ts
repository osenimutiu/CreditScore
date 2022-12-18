import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { SeverityServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-severity-list',
  templateUrl: './severity-list.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class SeverityListComponent extends AppComponentBase implements OnInit {
p:number = 1;
severityList:any=[];
  constructor(private inj: Injector,
    private _service: SeverityServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { 
      super(inj);
    }
  ngOnInit(): void {
    this.getSeverity();
  }

  getSeverity(){
    this._service.getSeverity().subscribe(res=>{
      this.severityList = res;
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
}
