import { Component, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { EditQARatingInput, QualitativeAnalysisServiceProxy, RatingAttributeDto, Tbl_RatingDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'editRatingModal',
  templateUrl: './edit-qa-rating-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class EditQaRatingModalComponent extends AppComponentBase implements OnInit {
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  qarating: EditQARatingInput = new EditQARatingInput();
  ratAtts: RatingAttributeDto[]= [];
  prevDup: Tbl_RatingDto[]= [];
  active: boolean = false;
  saving: boolean = false;
  constructor(
    injector: Injector,
    private _service: QualitativeAnalysisServiceProxy
  ) { 
    super(injector);
  }

  ngOnInit(): void {
  }

  edit(id): void {
    this.active = true;
    this._service.getQARatingEdit(id).subscribe((result)=> {
      this.qarating = result;
      // this.getRatingAttributes();
      this.avoidDupRating();
      this.modal.show();
    });
  }
    save(): void {
      this.saving = true;
      this._service.editQARating(this.qarating)
        .subscribe(() => {
          this.notify.success(this.l('Edited Successfully'));
          this.close();
          this.modalSave.emit(this.qarating);
        });
      this.saving = false;
    }
  
    close(): void {
      this.modal.hide();
      this.active = false;
    }

    // getRatingAttributes(){
    //   this._service.getRatingAttribute().subscribe(res =>{
    //     this.ratAtts = res;
    //   });
    // }
    getRating(){
      this._service.getRating().subscribe(res=>{
       this.prevDup = res;
      });
    }
    avoidDupRating(){
     this._service.preventDuplicateRating().subscribe(()=>{
      this.getRating();
     });
    }
  }


