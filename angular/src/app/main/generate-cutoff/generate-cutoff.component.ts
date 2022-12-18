import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoRetailCutOffDto, DemoRetailServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-generate-cutoff',
  templateUrl: './generate-cutoff.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./generate-cutoff.component.css']
  // styles: [
  // ]
})
export class GenerateCutoffComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  cutOff: DemoRetailCutOffDto = new DemoRetailCutOffDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('cuttOfInput') cuttOfInput: ElementRef;
  range:number;
  buttonSubmit:string;
  constructor(injector: Injector,
    private _service: DemoRetailServiceProxy,
    private route: ActivatedRoute,
    private router: Router) {
    super(injector);
  }

  ngOnInit(): void {
    this.onShown();
    this.buttonSubmit = 'Save CutOff'
  }
  onShown(): void {
    this.cuttOfInput.nativeElement.focus();
   }
  valueChanged(e) {
    e.target.value = this.range;
  }
  
  updateRange(){
    this.cutOff.cuttOff = this.range;
  }
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  save(): void{
    this.saving = true;
       this._service.addCutOff(this.cutOff)
       .pipe(finalize(() => this.saving = false))
       .subscribe(s =>{
         if(s){
          this.notify.success(this.l('SavedSuccessfully')); 
         }
         this.reset();
       });
       this.modalSave.emit(this.cutOff);
  }

  reset(){
    this.cutOff.cuttOff = null;
  }
}
