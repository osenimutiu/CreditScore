import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AgeAttributeListDto, AgeAttributeServiceProxy, AppAttributeListDto, AppAttributeServiceProxy, ApplicationScoringServiceProxy, CreateApplicationScoringInput, IncomeAttributeListDto, IncomeAttributeServiceProxy, LocationAttributeListDto, LocationAttributeServiceProxy, ProductTypeAttributeListDto, ProductTypeAttributeServiceProxy, RentAttributeListDto, RentAttributeServiceProxy, RenttoIncomeAttributeListDto, RenttoIncomeAttributeServiceProxy, ReturnonAssetsAttributeListDto, ReturnonAssetsAttributeServiceProxy, SubSectorAttributeListDto, SubSectorAttributeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'createApplicationScoringModal',
  templateUrl: './create-application-scoring-modal.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CreateApplicationScoringModalComponent extends AppComponentBase {
  selectedType: any;
  productTypes: ProductTypeAttributeListDto[] = [];
  ages: AgeAttributeListDto[] = [];
  incomes: IncomeAttributeListDto[] = [];
  rents: RentAttributeListDto[] = [];
  renttoIncomes: RenttoIncomeAttributeListDto[] = [];
  returnonAssets: ReturnonAssetsAttributeListDto[] = [];
  subSectors: SubSectorAttributeListDto[] = [];
  locations: LocationAttributeListDto[] = [];
  appTypes: AppAttributeListDto[] = [];
  appType = 'new Customer';

  filter: string = '';


  param1: number;
  param2: number
  param3: number
  param4: number;
  param5: number;
  param6: number;
  param7: number;
  param8: string;
  param9: string;
  param10: number;

  // let params = {
  //   param1: this.param1,
  //   param2: this.param2,
  //   param3: this.param3,
  //   param4: this.param4,
  //   param5: this.param5,
  //   param6: this.param6,
  //   param7: this.param7,
  //   param8: this.param8,
  //   param9: this.param9
  //    };



  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('applicantInput') applicantInput: ElementRef;
  @ViewChild('param9Input') param9Input: ElementRef;

  applicationScoring: CreateApplicationScoringInput = new CreateApplicationScoringInput();
  active: boolean = false;
  saving: boolean = false;

  constructor(
    injector: Injector,
    private _scoringService:ApplicationScoringServiceProxy,
    private _productTypeService:ProductTypeAttributeServiceProxy,
    private _ageService:AgeAttributeServiceProxy,
    private _incomeService:IncomeAttributeServiceProxy,
    private _renttoIncomeService:RenttoIncomeAttributeServiceProxy,
    private _returnonAssetsService:ReturnonAssetsAttributeServiceProxy,
    private _rentService:RentAttributeServiceProxy,
    private _subSectorService:SubSectorAttributeServiceProxy,
    private _locationService:LocationAttributeServiceProxy,
    private _appTypeService:AppAttributeServiceProxy,
    private _modalService: BsModalService,
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    this.getProductTypes(); 
    this.getAges(); 
    this.getIncomes(); 
    this.getRents(); 
    this.getRenttoIncomes(); 
    this.getReturnonAssets(); 
    this.getSubSectors(); 
    this.getLocations(); 
    this.getAppTypes();
    this.param8 = "New Customer"
   
  }

  
  onChangeProductType(type){
    // console.log('check');
    // console.log(type);
    this.selectedType = type;
  }

  getProductTypes(): void{
    this._productTypeService.getProductTypeAttribute(this.filter).subscribe((result) => {
      this.productTypes = result.items;
    });
  }
  getAges(): void{
    this._ageService.getAgeAttribute(this.filter).subscribe((result) => {
      this.ages = result.items;
    });
  }
  getIncomes(): void{
    this._incomeService.getIncomeAttribute(this.filter).subscribe((result) => {
      this.incomes = result.items;
    });
  }
  getRents(): void{
    this._rentService.getRentAttribute(this.filter).subscribe((result) => {
      this.rents = result.items;
    });
  }
  getRenttoIncomes(): void{
    this._renttoIncomeService.getRenttoIncomeAttribute(this.filter).subscribe((result) => {
      this.renttoIncomes = result.items;
    });
  }
  getReturnonAssets(): void{
    this._returnonAssetsService.getReturnonAssetsAttribute(this.filter).subscribe((result) => {
      this.returnonAssets = result.items;
    });
  }
  getSubSectors(): void{
    this._subSectorService.getSubSectorAttribute(this.filter).subscribe((result) => {
      this.subSectors = result.items;
    });
  }
  getLocations(): void{
    this._locationService.getLocationAttribute(this.filter).subscribe((result) => {
      this.locations = result.items;
    });
  }
 
  show(): void {
    this.active = true;
    this.applicationScoring = new CreateApplicationScoringInput();
    this.modal.show();
}

onShown(): void {
  this.applicantInput.nativeElement.focus();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void {
  this.saving = true;
  this._scoringService.createApplicationScoring(this.applicationScoring)
      .pipe(finalize(() => this.saving = false))
      .subscribe(() => {
          this.notify.success(this.l('Saved Successfully'));
          this.close();
          this.modalSave.emit(this.applicationScoring); 
      });
}
  
getAppTypes(): void{
  this._appTypeService.getAppAttribute(this.filter).subscribe((result) => {
    this.appTypes = result.items;
  });
}

computeScore(): void{
  this.saving = true;
  
     this._scoringService.computeFirstApplicationScore(
       this.param1,
       this.param2,
       this.param3,
       this.param4,
       this.param5,
       this.param6,
       this.param7,
       this.param8,
       this.param9,
       this.param10

     )
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Scores Computed Successfully'));
     this.close();
     })
}
}
