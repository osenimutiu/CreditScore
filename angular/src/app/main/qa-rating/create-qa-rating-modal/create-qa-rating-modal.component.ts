import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateQARatingDto, QualitativeAnalysisServiceProxy, RatingAttributeDto, Tbl_RatingDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'createRatingModal',
  templateUrl: './create-qa-rating-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CreateQaRatingModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  qarating: CreateQARatingDto = new CreateQARatingDto();
  ratAtts: RatingAttributeDto[]= [];
  prevDup: Tbl_RatingDto[]= [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  constructor(private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {  super(inj);}

  ngOnInit(): void {
  }
  show(): void { 
    this.active = true;
    this.qarating = new CreateQARatingDto();
    // this.getRatingAttributes();
    this.avoidDupRating();
    this.modal.show();
}
close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void{
  this.saving = true;
     this._service.createQARating(this.qarating)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Save Successfully'));     
     });
     this.close();
     this.modalSave.emit(this.qarating);
     this.reload();
}
// getRatingAttributes(){
//   this._service.getRatingAttribute().subscribe(res =>{
//     this.ratAtts = res;
//   });
// }
reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

getRating(){
  this._service.getRating().subscribe(res=>{
   this.prevDup = res;
  });
}
avoidDupRating(){
 this._service.preventDuplicateRating().subscribe(()=>{
  this.getRating();
 });
}
}
