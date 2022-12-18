import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateSetUpItemDto, MethodListDto, SetUpItemServiceProxy, SplittingMethodListDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'createSetupModal',
  templateUrl: './create-setup-modal.component.html',
  styles: [
  ]
})
export class CreateSetupModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  methods: MethodListDto[] = [];
  splittings: SplittingMethodListDto[] = [];
  setUp: CreateSetUpItemDto = new CreateSetUpItemDto();
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('emailInput') emailInput: ElementRef;
  constructor(
    injector: Injector,
    private _service: SetUpItemServiceProxy, 
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this.getMethodList();
    this.getSplittingList();
    this.setUp.training = 80;
    this.setUp.test = 20;
  }

  getMethodList(): void{
    this._service.getSetUp().subscribe((result) => {
      this.methods = result.items;
    });
  }
  getSplittingList(): void{
    this._service.getSplittingMethod().subscribe((result) => {
      this.splittings = result.items;
    });
  }

  save(): void{
    this.saving = true;
       this._service.createSetUp(this.setUp)
       .pipe(finalize(() => this.saving = false))
       .subscribe(() =>{
        this.notify.success(this.l('Save Successfully'));     
       });
       this.close();
       this.modalSave.emit(this.setUp);
       this.reload();
  }

  UpdateTest(): void{
    this.setUp.test = 100 - this.setUp.training
   }
 
   UpdateTraining(): void{
     this.setUp.training = 100 - this.setUp.test
   }

   
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
 
   reset(): void{
     this.setUp.email= "";
     this.setUp.training= 80;
     this.setUp.test= 20;
     this.setUp.methodId= 1;
   }

   onShown(): void {
    this.emailInput.nativeElement.focus();
   }

   show(): void { 
    this.active = true;
    this.setUp = new CreateSetUpItemDto();
    this.setUp.training = 80;
    this.setUp.test = 20;
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

}
