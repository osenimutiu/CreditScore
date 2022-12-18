import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { BinRangeDto, CreateSCMonitoringDto, QualitativeAnalysisServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'scMonitoringModal',
  templateUrl: './sc-monitoring-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScMonitoringModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  monitoring: CreateSCMonitoringDto = new CreateSCMonitoringDto();
  binRanges: BinRangeDto[]= [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('scoreInput') scoreInput: ElementRef;
  constructor(private inj: Injector,
    private _service: QualitativeAnalysisServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {  super(inj);}

  ngOnInit(): void {
  }
  show(): void { 
    this.active = true;
    this.monitoring = new CreateSCMonitoringDto();
    this.getBinRanges();
    this.modal.show();
}
close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void{
  this.saving = true;
     this._service.createSCMonitoring(this.monitoring)
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Save Successfully'));     
     });
     this.close();
     this.modalSave.emit(this.monitoring);
     this.reload();
}

getBinRanges(){
  this._service.getBinRange().subscribe(res =>{
    this.binRanges = res;
  });
}
onShown(): void {
  this.scoreInput.nativeElement.focus();
 }

 reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
}
