import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { QARatingDto, QualitativeAnalysisServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
  selector: 'app-qa-rating',
  templateUrl: './qa-rating.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class QaRatingComponent extends AppComponentBase implements OnInit {
  qaRatings: QARatingDto[] = [];
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
    this.getQARating();
  }
  getQARating(){
    this._service.getQARating().subscribe(res=>{
      this.qaRatings = res;
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  
  delete(del: QARatingDto){
    this.message.confirm( 
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._service.deleteQARating(del.id)
              .subscribe(() => {
                      this.notify.success(this.l('Successfully Deleted'));
                      _.remove(this.qaRatings, del);
                      this.getQARating();
                  });
          }
      });
  }
  
}
