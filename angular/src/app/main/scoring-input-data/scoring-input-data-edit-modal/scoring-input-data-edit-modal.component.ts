import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { EditScoringInputDataInput, ScoringInputDataServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'scoringInputDataEditModal',
  templateUrl: './scoring-input-data-edit-modal.component.html',
  styles: [
  ]
})
export class ScoringInputDataEditModalComponent extends AppComponentBase {
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('uniqueIDInput') uniqueIDInput: ElementRef;

  scoringInputData: EditScoringInputDataInput = new EditScoringInputDataInput();
  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _scoringService: ScoringInputDataServiceProxy
  ) { 
    super(injector);
  }

  // ngOnInit(): void {
  // }
  onShown(): void {
    // this.nameInput.nativeElement.focus();
   }
  show(scoringInputDataId): void {
    this.active = true;
    this._scoringService.getScoringInputDataForEdit(scoringInputDataId).subscribe((result)=> {
      this.scoringInputData = result;
      this.modal.show();
    });

  }

  save(): void {
    this.saving = true;
    this._scoringService.editScoringInputData(this.scoringInputData)
      .subscribe(() => {
        this.notify.success(this.l('Edited Successfully'));
        this.close();
        this.modalSave.emit(this.scoringInputData);
      });
    this.saving = false;
  }

  close(): void {
    this.modal.hide();
    this.active = false;
  }

}
