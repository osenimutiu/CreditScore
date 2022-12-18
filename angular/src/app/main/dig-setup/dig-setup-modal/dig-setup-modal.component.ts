import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DigSetUpServiceProxy, EditDigSetUpInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'digSetupModal',
  templateUrl: './dig-setup-modal.component.html',
  styles: [
  ]
})
export class DigSetupModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  setUp: EditDigSetUpInput = new EditDigSetUpInput();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('eventBadCollPaymentInput') eventBadCollPaymentInput: ElementRef;
  constructor(
    injector: Injector,
    private _service: DigSetUpServiceProxy, 
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector)
  }

  ngOnInit(): void {
  }
  edit(id): void {
    debugger
    this.active = true;
    this._service.getDigSetUpEdit(id).subscribe((result)=> {
      this.setUp = result;
      this.modal.show();
    });
  }
  save(): void {
    this.saving = true;
    this._service.editDigSetUp(this.setUp)
      .subscribe(() => {
        this.notify.success(this.l('Saved Successfully'));
        this.close();
        this.modalSave.emit(this.setUp);
        this.reload();
      });
    this.saving = false;
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
