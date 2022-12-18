import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateIndAppDto, IndividualServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'indModal',
  templateUrl: './in-d-app.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class InDAppComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  ind: CreateIndAppDto = new CreateIndAppDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('uniqueIdInput') uniqueIdInput: ElementRef;
  constructor(
    injector: Injector,
    private _service: IndividualServiceProxy, 
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(injector)
   }

  ngOnInit(): void {
  }
  save(): void{
    this.saving = true;
       this._service.creatIndividualApp(this.ind)
       .pipe(finalize(() => this.saving = false))
       .subscribe(() =>{
        this.notify.success(this.l('Save Successfully'));     
       });
       this.close();
       this.modalSave.emit(this.ind);
       this.reload();
  }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  show(): void { 
    this.active = true;
    this.ind = new CreateIndAppDto();
    // this.ind.uniqueId = (Math.floor(100000 + Math.random() * 900000)).toString();
    this.modal.show();
}
onShown(): void {
  this.uniqueIdInput.nativeElement.focus();
 }

close(): void {
  this.modal.hide();
  this.active = false;
}

 
}
