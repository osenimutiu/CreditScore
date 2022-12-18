import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { EditSetUpItemInput, MethodListDto, SetUpItemServiceProxy, SplittingMethodListDto } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'editSetupModal',
  templateUrl: './edit-setup-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class EditSetupModalComponent extends AppComponentBase implements OnInit {
  saving: boolean = false;
  active: boolean = false;
  methods: MethodListDto[] = [];
  splittings: SplittingMethodListDto[] = [];
  setUp: EditSetUpItemInput = new EditSetUpItemInput();
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
  }
  edit(id): void {
    this.active = true;
    this._service.getSetUpItemEdit(id).subscribe((result)=> {
      this.setUp = result;
      this.getMethodList();
      this.getSplittingList();
      this.modal.show();
    });
  }
  save(): void {
    this.saving = true;
    this._service.editSetUpItem(this.setUp)
      .subscribe(() => {
        this.notify.success(this.l('Edited Successfully'));
        this.close();
        this.modalSave.emit(this.setUp);
        this.reload();
      });
    this.saving = false;
  }

  close(): void {
    this.modal.hide();
    this.active = false;
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
}
