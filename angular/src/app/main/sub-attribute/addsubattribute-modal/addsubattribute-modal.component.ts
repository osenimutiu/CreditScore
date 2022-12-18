import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ApiResponseDto, CreateSubRetailAttrItemDto, DemoRetailAttrItemDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'addsubattributeModal',
  templateUrl: './addsubattribute-modal.component.html',
  styles: [
  ]
})
export class AddsubattributeModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  distList:any=[];
  existResponse: string;
  nonExistResponse: string;
  valueList:DemoRetailAttrItemDto[]=[];
  retail: CreateSubRetailAttrItemDto = new CreateSubRetailAttrItemDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('attributeInput') attributeInput: ElementRef;
  constructor(private inj: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { super(inj)}

  ngOnInit(): void {
  }
  show(): void { 
    this.active = true;
    this.retail = new CreateSubRetailAttrItemDto();
    this.getDistinctAttr();
    this.modal.show();
}

// save(): void{
//   this.saving = true;
//      this._service.createSubRetailAttrItem(this.retail)
//      .pipe(finalize(() => this.saving = false))
//      .subscribe(() =>{
//       this.notify.success(this.l('Save Successfully'));     
//      });
//     //  this.close();
//     this.reset();
//      this.modalSave.emit(this.retail);
// }

save(): void{
  debugger;
  this.saving = true;
     this._service.createSubRetailAttrItem(this.retail)
     .subscribe(res =>{
       if(res.status === 203)
       {
        this.existResponse = res.message;
        this.saving = false;
        // this.notify.error(this.l(this.existResponse));
       }
       else{
         this.nonExistResponse = res.message;
         this.saving = false;
         this.notify.success(this.l(this.nonExistResponse)); 
         this.reset();    
       }
     
     });
    //  this.close();
     this.modalSave.emit(this.retail);
}

close(): void {
  this.modal.hide();
  this.active = false;
  this.reload();
}
reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getDistinctAttr(){
    this._service.distinctAttribute().subscribe(x=>{
      this.distList = x;
    });
  }
  // getValue(){
  //   this._service.getDemoRetailAttrItemById(this.retail.attributeId).subscribe(y=>{
  //     this.valueList = y;
  //   })
  // }
  reset(){
    this.retail.attributeId = '';
    this.retail.subAttribute = '';
    this.retail.value = 0;
  }
}
