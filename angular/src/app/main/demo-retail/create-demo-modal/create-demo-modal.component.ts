import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateDemoRetailAttrDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'createDemoModal',
  templateUrl: './create-demo-modal.component.html',
  styles: [
  ]
})
export class CreateDemoModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  retail: CreateDemoRetailAttrDto = new CreateDemoRetailAttrDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('attributeInput') attributeInput: ElementRef;
  constructor(private inj: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router,) { super(inj)}

  ngOnInit(): void {
  }

  show(): void { 
    this.active = true;
    this.retail = new CreateDemoRetailAttrDto();
    this.modal.show();
}
save(): void{
  this.saving = true;
     this._service.createDemoRetailAttrItem(this.retail)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Save Successfully'));     
     });
     this.close();
     this.reload();
     this.modalSave.emit(this.retail);
}


onShown(): void {
  this.attributeInput.nativeElement.focus();
 }

close(): void {
  this.modal.hide();
  this.active = false;
}
reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
}
