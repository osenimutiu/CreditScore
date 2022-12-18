import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { EditScalingInput, ScoreCardServiceProxy, Tbl_AttributeCountDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'editScalingModal',
  templateUrl: './edit-scaling-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class EditScalingModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  disNValue: boolean;
  scaling: EditScalingInput = new EditScalingInput();
  attCounts: Tbl_AttributeCountDto[] = [];
  count: number;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  constructor(
    injector: Injector,
    private _service: ScoreCardServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }
  getEditItem(id): void {
    this.active = true;
    this._service.getScalingForEdit(id).subscribe((result)=> {
      this.scaling = result;
      // this.disableValueN();
      this.runAttributeCount();
      this.modal.show();
    });
  }

  disableValueN(){
   let x = this.scaling.items;
   if(x == 'n'){
     this.scaling.values = this.count;
    this.disNValue = true;
   }
   else{
    this.getAttributeCount();
   }
  }

  save(): void {
    this.saving = true;
    this._service.editScaling(this.scaling)
      .subscribe(() => {
        this.notify.success(this.l('Edited Successfully'));
        this.close();
        this.modalSave.emit(this.scaling);
      });
    this.saving = false;
  }

  close(): void {
    this.modal.hide();
    this.active = false;
    this.reload()
  }
  runAttributeCount(){
    this._service.countAttributes().subscribe(()=>{
      this.getAttributeCount();
      // this.getTotal();
    });
  }

  getAttributeCount(){
    this._service.getAttributeCount().subscribe(res=>{
      this.attCounts = res;
      this.getTotal();
    });
  }
  
  getTotal() {
    let total = 0;
    for (var i = 0; i < this.attCounts.length; i++) {
        if (this.attCounts[i].attributeCount) {
            total += this.attCounts[i].attributeCount;
            this.count = total;
            this.disableValueN();
        }
      }
    }
    reload() {
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate(['./'], { relativeTo: this.route });
    }
}
