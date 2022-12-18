import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailAttrItemDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-demo-retail',
  templateUrl: './demo-retail.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./demo-retail.component.css']
})
export class DemoRetailComponent extends AppComponentBase implements OnInit {
  retailDemoList: DemoRetailAttrItemDto[]= [];
  isEditable:boolean;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
p:number=1
  constructor(private inj: Injector,
              private _service: DemoRetailServiceProxy,
              private route: ActivatedRoute,
              private router: Router,) { super(inj)}

  ngOnInit(): void {
    this.getDemoRetail();
  }
getDemoRetail(){
  this._service.getDemoRetailAttrItem().subscribe(res=>{
    this.retailDemoList = res;
// 
    // this.retailDemoList.forEach(x => {
    //   if(x.position < 40){
    //     this.isEditable = true;
    //   }
    // });
    // 
  });
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
