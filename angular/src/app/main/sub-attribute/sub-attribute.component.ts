import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailAttrItemDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
  selector: 'app-sub-attribute',
  templateUrl: './sub-attribute.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./sub-attribute.component.css']

})
export class SubAttributeComponent extends AppComponentBase implements OnInit {
  subRetailDemoList: any[]= [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
p:number=1
constructor(private inj: Injector,
  private _service: DemoRetailServiceProxy,
  private route: ActivatedRoute,
  private router: Router,) { super(inj)}

  ngOnInit(): void {
    this.getSubDemoRetail();
  }
  getSubDemoRetail(){
    this._service.getSubRetailAttrItem().subscribe(res=>{
      this.subRetailDemoList = res;
    });
  }
  
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
  reverse(id: number){
    this.message.confirm(
        '',
        this.l('Are you sure to Reverse?'),
        (isConfirmed) => {
            if (isConfirmed) {
                this._service.reverseAttribute(id)
                .subscribe(() => {
                        this.message.success(this.l('Successfully Reversed'));
                        _.remove(this.subRetailDemoList, id);
                        this.getSubDemoRetail();
                    });
            }
        }
    );
  }

  // approveDetail(id: number){
  //   this._service.approveAttribute(id).subscribe(()=>{
  //     this.getSubDemoRetail();
  //   });
  // }
  // declineDetail(id: number){
  //   this._service.declineAttribute(id).subscribe(()=>{
  //     this.getSubDemoRetail();
  //   });
  // }

  // approveDetail(id: number){
  //   this.message.confirm(
  //     '',
  //     this.l('Are you sure to Approve?'),
  //     (isConfirmed) => {
  //         if (isConfirmed) {
  //             this._service.approveAttribute(id)
  //             .subscribe(() => {
  //                     this.message.success(this.l('Successfully Approved'));
  //                     _.remove(this.subRetailDemoList, id);
  //                     this.getSubDemoRetail();
  //                 });
  //         }
  //     }
  // );
  // }

  // declineDetail(id: number){
  //   this.message.confirm(
  //     '',
  //     this.l('Are you sure to Decline?'),
  //     (isConfirmed) => {
  //         if (isConfirmed) {
  //             this._service.declineAttribute(id)
  //             .subscribe(() => {
  //                     this.notify.success(this.l('Successfully Declined'));
  //                     _.remove(this.subRetailDemoList, id);
  //                     this.getSubDemoRetail();
  //                 });
  //         }
  //     }
  // );
  // }
}
