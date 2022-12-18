import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateRetailCutOff, RetailScoringServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'retailcutoffModal',
  templateUrl: './retail-cutoff-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class RetailCutoffModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  range:number;
  cutOff: CreateRetailCutOff = new CreateRetailCutOff();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('cuttOfInput') cuttOfInput: ElementRef;
  
  constructor(injector: Injector,
    private _service: RetailScoringServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {
    super(injector);
  }

  ngOnInit(): void {
  }
  onShown(): void {
    this.cuttOfInput.nativeElement.focus();
   }

   show(): void { 
    this.active = true;
    this.cutOff = new CreateRetailCutOff();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void{
  this.saving = true;
     this._service.postRetailCutoff(this.cutOff)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('SavedSuccessfully'));     
     });
     this.close();
     this.reload();
     this.modalSave.emit(this.cutOff);
}

valueChanged(e) {
  e.target.value = this.range;
}

updateRange(){
  this.cutOff.cutoffValue = this.range;
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
