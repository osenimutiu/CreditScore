import { Component, Injector, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateSetUPDto, GiniInclusiveServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-setup-page',
  templateUrl: './setup-page.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
  styleUrls: ['setup-page.component.css'],
  // styles: [
  // ]
})
export class SetupPageComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  setUp: CreateSetUPDto = new CreateSetUPDto();
  constructor( injector: Injector,
    private _service: GiniInclusiveServiceProxy, 
    private route: ActivatedRoute,
    private router: Router) { super(injector)}

  ngOnInit(): void {
  }
  save(): void{
    this.saving = true;
       this._service.createSetUp(this.setUp)
       .pipe(finalize(() => this.saving = false))
       .subscribe(() =>{
        this.notify.success(this.l('SaveSuccessfully'));     
       });
       this.reset();
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
  reset(){
    this.setUp.creditScoreWeight = null;
    this.setUp.qualitativeAnalysisWeight = null;
  }

  updateQualAnalysis(){
    this.setUp.qualitativeAnalysisWeight = 100 - this.setUp.creditScoreWeight;
  }
  updatecreditScoreWeight(){
    this.setUp.creditScoreWeight = 100 -  this.setUp.qualitativeAnalysisWeight;
  }
}
