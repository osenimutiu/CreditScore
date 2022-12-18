import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateRatingAttributeDto, QualitativeAnalysisServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'ratingModal',
  templateUrl: './add-rating-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class AddRatingModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  rating: CreateRatingAttributeDto = new CreateRatingAttributeDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('itemInput') itemInput: ElementRef;
  constructor(injector: Injector,
    private _service: QualitativeAnalysisServiceProxy) {
      super(injector);
    }

  ngOnInit(): void {
  }
  show(): void { 
    this.active = true;
    this.rating = new CreateRatingAttributeDto();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}
onShown(): void {
  this.itemInput.nativeElement.focus();
 }
save(): void{
  this.saving = true;
     this._service.createRatingAttribute(this.rating)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('SavedSuccessfully'));     
     });
     this.close();
     this.modalSave.emit(this.rating);
}
}
