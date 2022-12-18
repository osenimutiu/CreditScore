import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { PointAllocationServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-gene-point-all',
  templateUrl: './gene-point-all.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class GenePointAllComponent extends AppComponentBase implements OnInit {
    scoreList: any[];
    detailList: any[];
    scoreRefNo: string;
    detailRefNo: string;
    p:number = 1;
    sc:number = 1;
  constructor(private injector: Injector,
    private _service: PointAllocationServiceProxy,
    private route: ActivatedRoute,
   private router: Router) {
      super(injector);
  }

  ngOnInit(): void {
      this.getScoreAllocationList();
      this.getDetailAllocationList();
  }

  SearchForScore(){
    if(this.scoreRefNo != ""){
      this.scoreList = this.scoreList.filter(res=>{
        return res.refNo.toLocaleLowerCase().match(this.scoreRefNo.toLocaleLowerCase());
      });
    }else if(this.scoreRefNo == ""){
      this.ngOnInit();
    }
  }
  SearchForDetail(){
    if(this.detailRefNo != ""){
      this.detailList = this.detailList.filter(res=>{
        return res.refNo.toLocaleLowerCase().match(this.detailRefNo.toLocaleLowerCase());
      });
    }else if(this.detailRefNo == ""){
      this.ngOnInit();
    }
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  generateScore(){
     this._service.generateScoreAllocation().subscribe(()=>{
         this.notify.success(this.l('Score Computed Successfully'))
         this.getScoreAllocationList();
         this.getDetailAllocationList();
     });
  }

  getScoreAllocationList(){
    this._service.getAllocationByScores().subscribe(res=>{
        this.scoreList = res;
    });
  }
  getDetailAllocationList(){
    this._service.getAllocationByDetails().subscribe(res=>{
        this.detailList = res;
    });
  }
}
