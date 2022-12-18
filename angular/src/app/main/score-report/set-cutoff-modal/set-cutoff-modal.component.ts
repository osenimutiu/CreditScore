import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateTblCutOffDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'setCutoffModal',
  templateUrl: './set-cutoff-modal.component.html',
  styles: [
  ]
})
export class SetCutoffModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  range:number;
  cutOff: CreateTblCutOffDto = new CreateTblCutOffDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('cuttOffInput') cuttOffInput: ElementRef;
  constructor(injector: Injector,
    private _service: ScoreCardServiceProxy, ) { super(injector)}

  ngOnInit(): void {
  }

  onShown(): void {
    this.cuttOffInput.nativeElement.focus();
   }

   show(): void { 
    this.active = true;
    this.cutOff = new CreateTblCutOffDto();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void{
  this.saving = true;
     this._service.createCutOff(this.cutOff)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('SavedSuccessfully'));     
     });
     this.close();
     this.modalSave.emit(this.cutOff);
}

valueChanged(e) {
  e.target.value = this.range;
}

updateRange(){
  this.cutOff.cutOff = this.range;
}
}
