import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateProfit_AnalysisDto, QualitativeAnalysisServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'profitAnalysisModal',
  templateUrl: './post-profit-analysis.component.html', 
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class PostProfitAnalysisComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  profAnal: CreateProfit_AnalysisDto = new CreateProfit_AnalysisDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('emailInput') aveLoanInput: ElementRef;
  constructor(injector: Injector,
    private _service: QualitativeAnalysisServiceProxy) { super(injector)}

  ngOnInit(): void {
  }
  save(): void{
    this.saving = true;
       this._service.createProfitAnalysis(this.profAnal)
       .pipe(finalize(() => this.saving = false))
       .subscribe(() =>{
        this.notify.success(this.l('Save Successfully'));     
       });
       this.close();
       this.modalSave.emit(this.profAnal);
  }
  onShown(): void {
    this.aveLoanInput.nativeElement.focus();
   }
   close(): void {
    this.modal.hide();
    this.active = false;
  } 
  
  show(): void { 
    this.active = true;
    this.profAnal = new CreateProfit_AnalysisDto();
    this.modal.show();
}
}
