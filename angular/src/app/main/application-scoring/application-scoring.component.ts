import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountBalDataListDto, AccountBalDataServiceProxy, AgeAttributeListDto, AgeAttributeServiceProxy, AllScoreListDto, AllScoreServiceProxy, AppAttributeListDto, AppAttributeServiceProxy, ApplicantAttributeListDto, ApplicantAttributeServiceProxy, ApplicationScoringListDto, ApplicationScoringServiceProxy, CreateApplicationScoringInput, IncomeAttributeListDto, IncomeAttributeServiceProxy, LocationAttributeListDto, LocationAttributeServiceProxy, ProductTypeAttributeListDto, ProductTypeAttributeServiceProxy, RatingPredictionOutputListDto, RatingPredictionOutputServiceProxy, RentAttributeListDto, RentAttributeServiceProxy, RenttoIncomeAttributeListDto, RenttoIncomeAttributeServiceProxy, ReturnonAssetsAttributeListDto, ReturnonAssetsAttributeServiceProxy, SubSectorAttributeListDto, SubSectorAttributeServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-application-scoring',
  templateUrl: './application-scoring.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ApplicationScoringComponent  extends AppComponentBase {
   
  productTypes: ProductTypeAttributeListDto[] = [];
  scorings: ApplicationScoringListDto[] = [];
  ratingPredictions: RatingPredictionOutputListDto[] = [];
  scores: AllScoreListDto[] = [];
  rPOutputs: RatingPredictionOutputListDto[] = [];
  accountBalData : AccountBalDataListDto[] = [];
  appTypes: AppAttributeListDto[] = [];
  applicants: ApplicantAttributeListDto[] = [];

  //From create-application-modal
 selectedType: any;
  //productTypes: ProductTypeAttributeListDto[] = [];
  ages: AgeAttributeListDto[] = [];
  incomes: IncomeAttributeListDto[] = [];
  rents: RentAttributeListDto[] = [];
  renttoIncomes: RenttoIncomeAttributeListDto[] = [];
  returnonAssets: ReturnonAssetsAttributeListDto[] = [];
  subSectors: SubSectorAttributeListDto[] = [];
  locations: LocationAttributeListDto[] = [];
  //appTypes: AppAttributeListDto[] = [];
  

  //filter: string = '';
  param1: number;
  param2: number
  param3: number
  param4: number;
  param5: number;
  param6: number;
  param7: number;
  //param8: string;
  //param9: string;
 // param10: number;



  advancedFiltersAreShown = false;
  filter: string = '';
//
applicantFilter = '';
loanRequestFilter = '';
amountFilter = '';
tenorMonthFilter = '';
ageAttributeFilter = '';
productTypeAttributeFilter = '';
incomeAttributeFilter = '';
locationAttributeFilter = '';
rentAttributeFilter = '';
renttoIncomeAttributeFilter = '';
returnonAssetsAttributeFilter = '';
subSectorAttributeFilter = '';
extraParam1Filter = '';
extraParam2Filter = '';
applicanFilter = '';
applicant_With_AccnoFilter = '';

param8: string;
param9: string;
custid: string;
param10: number;
param11: string;
// selectedType: any;

getColor(recommend){ (2)
  switch (recommend){
    case 'Approve' :
      return '#89eb34';
    case 'Review' :
      return 'yellow';
    case 'Reject' :
      return '#fc030b';
  }
}



  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('applicantInput') applicantInput: ElementRef;
  @ViewChild('param9Input') param9Input: ElementRef;


applicationScoring: CreateApplicationScoringInput = new CreateApplicationScoringInput();
active: boolean = false;
saving: boolean = false;



@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;

  constructor(
    injector: Injector,
    private _scoringService:ApplicationScoringServiceProxy,
    private _productTypeService:ProductTypeAttributeServiceProxy,
    private _predictionService:RatingPredictionOutputServiceProxy,
    private _scoreService:AllScoreServiceProxy,
    private _appTypeService:AppAttributeServiceProxy,
    private _applicantService:ApplicantAttributeServiceProxy,
    private _rPOutputService:RatingPredictionOutputServiceProxy,
    private _accBalDataService:AccountBalDataServiceProxy,

    private _ageService:AgeAttributeServiceProxy,
    private _incomeService:IncomeAttributeServiceProxy,
    private _renttoIncomeService:RenttoIncomeAttributeServiceProxy,
    private _returnonAssetsService:ReturnonAssetsAttributeServiceProxy,
    private _rentService:RentAttributeServiceProxy,
    private _subSectorService:SubSectorAttributeServiceProxy,
    private _locationService:LocationAttributeServiceProxy,
    private _modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router
    
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    //this.resetForm();
    this.getProductTypes();
    this.getApplicationScoringDetail();
    this.getRatingPredictionOutputs();
    this.getAppTypes();
    this.getApplicantWithAccountNo();
    this.getRatingPredictionOutput();
    this.getAccountBalDataDetails();
    this.getAges(); 
    this.getIncomes(); 
    this.getRents(); 
    this.getRenttoIncomes(); 
    this.getReturnonAssets(); 
    this.getSubSectors(); 
    this.getLocations();
    this.param11 = "Existing Customer";
    this.param8 = "New Customer"
  }

  getProductTypes(): void{
    this._productTypeService.getProductTypeAttribute(this.filter).subscribe((result) => {
      this.productTypes = result.items;
    });
  }
  getApplicationScoringDetail(): void{
    this._scoringService.getApplicationScoring(
      this.filter,
      this.applicantFilter,
      this.loanRequestFilter,
      this.amountFilter,
      this.tenorMonthFilter,
      this.ageAttributeFilter,
      this.productTypeAttributeFilter,
      this.incomeAttributeFilter,
      this.locationAttributeFilter,
      this.rentAttributeFilter,
      this.renttoIncomeAttributeFilter,
      this.returnonAssetsAttributeFilter, 
      this.subSectorAttributeFilter,
      this.extraParam1Filter,
      this.extraParam2Filter,
      this.applicanFilter,
      this.applicantFilter,
      ).subscribe((result) => {
      this.scorings = result.items;
    });
  }

  onChangeProductType(type){
    // console.log('check');
    // console.log(type);
    this.selectedType = type;
  }

  getRatingPredictionOutputs(): void{
    this._predictionService.getRatingPredictionOutput(this.filter).subscribe((result) => {
      this.ratingPredictions = result.items;
    });
  }
  getAllScores(): void{
    this._scoreService.getAllScore(this.filter).subscribe((result) => {
      this.scores = result.items;
    });
  }

  save(): void {
    let input = new CreateApplicationScoringInput();
    this.saving = true;
    this._scoringService.createApplicationScoring(input)
        .pipe(finalize(() => { this.saving = false; }))
        .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
             //this.close();
            this.modalSave.emit(null);
        });
 }
getAppTypes(): void{
  this._appTypeService.getAppAttribute(this.filter).subscribe((result) => {
    this.appTypes = result.items;
  });
}
getApplicantWithAccountNo(): void{
  this._applicantService.getApplicantAttribute(this.filter).subscribe((result) => {
    this.applicants = result.items;
  });
}

getRatingPredictionOutput(): void{
  this._rPOutputService.getRatingPredictionOutput(this.filter).subscribe((result) => {
    this.rPOutputs = result.items;
  });
}
getAccountBalDataDetails(): void{
  this._accBalDataService.getAccountBalData(this.filter).subscribe((result) => {
    this.accountBalData = result.items;
  });
}

computeSecondScore(): void{
  this.saving = true;
  
     this._scoringService.computeSecondApplicationScore(
       this.param11,
       this.param9,
       this.custid,
       this.param10

     )
     .pipe(finalize(() => this.saving = false))
     .subscribe(() =>{
      this.notify.success(this.l('Scores Computed Successfully'));
      this.getRatingPredictionOutput();
     })
}


reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
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
      this.getRatingPredictionOutput();
     //this.close();
     })
}

}
