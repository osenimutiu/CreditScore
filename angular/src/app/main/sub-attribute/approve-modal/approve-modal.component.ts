import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailServiceProxy, GetSubRetailAttrItemForEditOutput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'approveModal',
  templateUrl: './approve-modal.component.html',
  styles: [
  ]
})
export class ApproveModalComponent extends AppComponentBase implements OnInit {
  @ViewChild('approveModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  active = false;
  saving = false;
  param1:number;
  param2:string;
  item: GetSubRetailAttrItemForEditOutput;
  constructor(
    private _service: DemoRetailServiceProxy,
    injector: Injector, private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector);
    this.item = new GetSubRetailAttrItemForEditOutput();
  }

  ngOnInit(): void {
  }
  show(item: GetSubRetailAttrItemForEditOutput): void {
    this.item = item;
    this.active = true;
    this.modal.show();
}
close(): void {
  this.active = false;
  this.modal.hide();
}
approve(){
this.param1 = this.item.id;
this.param2 = this.item.reason;
this._service.approveAttribute(this.param1,this.param2).subscribe(()=>{
  this.notify.success(this.l('Approved Successfully'));
  this.close();
  this.reload()
});
}
reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

}
