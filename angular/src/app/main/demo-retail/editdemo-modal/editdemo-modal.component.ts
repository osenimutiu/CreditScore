import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailServiceProxy, EditDemoRetailAttrInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'editdemoModal',
  templateUrl: './editdemo-modal.component.html',
  styles: [
  ]
})
export class EditdemoModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  @ViewChild('modal') modal: ModalDirective;
  retail: EditDemoRetailAttrInput = new EditDemoRetailAttrInput();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  constructor(private inj: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router,) { super(inj)}

  ngOnInit(): void {
  }
  show(id): void {
    this.active = true;
    this._service.getDemoRetailAttrEdit(id).subscribe((result)=> {
      this.retail = result;
      this.modal.show();
    });
  }
  save(): void {
    this.saving = true;
    this._service.editDemoRetailAttr(this.retail)
      .subscribe(() => {
        this.notify.success(this.l('Edited Successfully'));
        this.close();
        this.reload();
        this.modalSave.emit(this.retail);
      });
    this.saving = false;
  }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
  close(): void {
    this.modal.hide();
    this.active = false;
  }
}
