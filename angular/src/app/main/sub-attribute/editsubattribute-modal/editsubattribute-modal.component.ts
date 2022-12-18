import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailServiceProxy, EditSubRetailAttrItemInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'editsubattributeModal',
  templateUrl: './editsubattribute-modal.component.html',
  styles: [
  ]
})
export class EditsubattributeModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  distList:any=[];
  @ViewChild('modal') modal: ModalDirective;
  retail: EditSubRetailAttrItemInput = new EditSubRetailAttrItemInput();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  constructor(private inj: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router,) { super(inj)}

  ngOnInit(): void {
  }

  show(id): void {
    this.active = true;
    this._service.getSubRetailAttrItemEdit(id).subscribe((result)=> {
      this.retail = result;
      this.getDistinctAttr();
      this.modal.show();
    });
  }
  getDistinctAttr(){
    this._service.distinctAttribute().subscribe(x=>{
      this.distList = x;
    });
  }
  save(): void {
    this.saving = true;
    this._service.editSubRetailAttrItem(this.retail)
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
    this.reload();
  }
}

