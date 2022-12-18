import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild, ViewEncapsulation } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountAuthorizeListDto, AccountAuthorizeServiceProxy, BankListDto, BankServiceProxy, BusRegNigListDto, BusRegNigServiceProxy, CreateSMELendingApplyInput, GenderTypeListDto, GenderTypeServiceProxy, HaveBankAccountListDto, HaveBankAccountServiceProxy, HaveNINListDto, HaveNINServiceProxy, LoanTypeListDto, LoanTypeServiceProxy, OperationEligibilityListDto, OperationEligibilityServiceProxy, SMELendingApplyServiceProxy, SMETitleListDto, SMETitleServiceProxy, SubSectorAttributeListDto, SubSectorAttributeServiceProxy } from '@shared/service-proxies/service-proxies';
import Stepper from 'bs-stepper';
import { finalize } from 'rxjs/operators';
import Okra from 'okra-js';


@Component({
  selector: 'app-sme-lending',
  templateUrl: './sme-lending.component.html',
  encapsulation: ViewEncapsulation.None,
  animations: [appModuleAnimation()],
  styles: [ ]
})
export class SmeLendingComponent extends AppComponentBase implements OnInit {
  smelending: NgForm;
loanTypes: LoanTypeListDto[] = [];
banks: BankListDto[] = [];
genderTypes: GenderTypeListDto[] = [];
titles: SMETitleListDto[] = [];
MiddleName: string;
dob: Date;
gender:string;

//Eligibility
haveNINs: HaveNINListDto[] = [];
haveBankAccounts: HaveBankAccountListDto[] = [];
accountAuthorize: AccountAuthorizeListDto[] = [];
busRegs: BusRegNigListDto[] = [];
opElibilities: OperationEligibilityListDto[] = [];
sectors: SubSectorAttributeListDto[] = [];
smeLending: CreateSMELendingApplyInput = new CreateSMELendingApplyInput();

active: boolean = false;
saving: boolean = false;
filter: string = '';
firstName: string;
lastName: string;
range: number;
userName = '';
bvnCheck: number = null;
bvn: number = 2222222222;
otp: number = 2222;
otpCheck: number = null;
responseMessage: string;
otpResponseMessage: string;
financeVal: number;
financeVal2: number;
financeVal3: number;
financeVal4: number;
financeVal5: number;
financeVal6: number;
financeVal7: number;
financeVal8: number;

financiaPoslVal: number;
financiaPoslVal2: number;
financiaPoslVal3: number;
financiaPoslVal4: number;
financiaPoslVal5: number;
financiaPoslVal6: number;
financiaPoslVal7: number;
financiaPoslVal8: number;
financiaPoslVal9: number;

financiaCashVal: number;
financiaCashVal2: number;
financiaCashVal3: number;
financiaCashVal4: number;
financiaCashVal5: number;
financiaCashVal6: number;
financiaCashVal7: number;
financiaCashVal8: number;
financiaCashVal9: number;

officialWebsite: string;
faceBookPage: string;


@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
@ViewChild('loanTypeInput') loanTypeInput: ElementRef;
private stepper: Stepper;
hideData = false; 
isLoading = false;
//hideData = false;
eligibleTrue:boolean = false;
eligibilityCheck: string = '';
answer: string = 'Yes';


  constructor(
    injector: Injector,
    private _loanTypeService:LoanTypeServiceProxy,
    private _bankService: BankServiceProxy,
    private _genderTypeService: GenderTypeServiceProxy,
    private _titleService : SMETitleServiceProxy,
    private _sectorService:SubSectorAttributeServiceProxy,
    private _smeLendingService:SMELendingApplyServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
    //Eligibility
    private _haveNINService:HaveNINServiceProxy,
    private _haveBankAccountService: HaveBankAccountServiceProxy,
    private _accountAuthorizeService: AccountAuthorizeServiceProxy,
    private _busRegService : BusRegNigServiceProxy,
    private _opElibilityService : OperationEligibilityServiceProxy,
    private formBuilder: FormBuilder
  
  ) {
    super(injector);
   }

  ngOnInit(): void {
   
    this.bsInitialization(); 
    this.getBanks();
    this.getGenderTypes();
    this.getSectors();
    this.getLoanTypes();
    this.getTitleTypes();
    //Eligibility
    this.getBusRegisInfos();
    this.getHaveAccountInfos();
    this.getNINInfos();
    this.getOperationEligibilityInfos();
    this.getaccountAuthorizeinfos();
    this.firstName = "Godwin";
    this.lastName = "Emmanuel";
    this.officialWebsite = "www.xyz.com";
    this.faceBookPage = "facebook.com/xyz";
    this.MiddleName = "John";
    this.dob = new Date(1995, 11, 17);
    this.gender = 'Male';
    this.financeVal = 4100000;
    this.financeVal2 = 2500000;
    this.financeVal3 = 1200000;
    this.financeVal4 = 1400000;
    this.financeVal5 = 3200000;
    this.financeVal6 = 5500000;
    this.financeVal7 = 2700000;
    this.financeVal8 = 3100000;
    this.financiaPoslVal = 2404000;  
    this.financiaPoslVal2 = 4880000;  
    this.financiaPoslVal3 = 6120000;  
    this.financiaPoslVal4 = 4040000;  
    this.financiaPoslVal5 = 5420000;  
    this.financiaPoslVal6 = 3190000;  
    this.financiaPoslVal7 = 4080000;  
    this.financiaPoslVal8 = 8030000;  
    this.financiaPoslVal9 = 4650000; 

    this.financiaCashVal = 2120000;  
    this.financiaCashVal2 = 3620000;  
    this.financiaCashVal3 = 4220000;  
    this.financiaCashVal4 = 1150000;  
    this.financiaCashVal5 = 2200000;  
    this.financiaCashVal6 = 5200000;  
    this.financiaCashVal7 = 2000000;  
    this.financiaCashVal8 = 42000000;  
    this.financiaCashVal9 = 5200000; 
    this.smeLending.applicatioNo =  Math.floor(100000 + Math.random() * 900000);
  }
 
  validateBVN(){
    var inputData = this.bvnCheck;
    if(inputData == null){
      this.responseMessage = "Enter your BVN";
    }
   else if(inputData == this.bvn){
      this.responseMessage = "Your bvn is valid";
    }else{
      this.responseMessage = "Invalid bvn entered. Please try again"
    }
  }

  validateOTP(){
    var otpInput = this.otpCheck;
    if(otpInput == null){
      this.notify.warn(this.l('Enter One time pin'));
    }
    else if (otpInput == this.otp){
      this.notify.success(this.l('Valid One time pin entered!'));
    }
    else{
      this.notify.error(this.l('Invalid One time pin entered please try again!'));
    }
  }


  onSubmit() {
    let input = new CreateSMELendingApplyInput();
    this.saving = true;
    this._smeLendingService.createSMELendingApply(input)
        .pipe(finalize(() => { this.saving = false; }))
        .subscribe(() => {
            this.notify.success(this.l('Saved Successfully'));
            this.modalSave.emit(null);
            // this.reload();
        });
 }


 save(smelending: NgForm) {
    this.saving = true;
    this.smeLending.tenantId = abp.session.tenantId;
    this._smeLendingService
      .createSMELendingApply(this.smeLending)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('Request Sent Successfully'));
     }); 
  smelending.resetForm();
  this.smeLending.applicatioNo =  Math.floor(100000 + Math.random() * 900000);
}





  updateRange(){
    this.smeLending.loanAmount = this.range;
  }

  getSectors(): void{
    this._sectorService.getSubSectorAttribute(this.filter).subscribe((result) => {
      this.sectors = result.items;
    });
  }

  getNINInfos(): void{
    this._haveNINService.getHaveNIN(this.filter).subscribe((result) => {
      this.haveNINs = result.items;
    });
  }
  getHaveAccountInfos(): void{
    this._haveBankAccountService.getHaveBankAccount(this.filter).subscribe((result) => {
      this.haveBankAccounts = result.items;
    });
  }
  getaccountAuthorizeinfos(): void{
    this._accountAuthorizeService.getAccountAuthorize(this.filter).subscribe((result) => {
      this.accountAuthorize = result.items;
    });
  }
  getBusRegisInfos(): void{
    this._busRegService.getBusRegNig(this.filter).subscribe((result) => {
      this.busRegs = result.items;
    });
  }
  getOperationEligibilityInfos(): void{
    this._opElibilityService.getOperationEligibility(this.filter).subscribe((result) => {
      this.opElibilities = result.items;
    });
  }


  valueChanged(e) {
    e.target.value = this.range;
    console.log(e.target.value);
  }
  xlSerialToJsDate(xlSerial) {
    return new Date(-2209075200000 + (xlSerial - (xlSerial < 61 ? 0 : 1)) * 86400000);
  }
  getLoanTypes(): void{
    this._loanTypeService.getLoanType(this.filter).subscribe((result) => {
      this.loanTypes = result.items;
    });
  }
  getBanks(): void{
    this._bankService.getBank(this.filter).subscribe((result) => {
      this.banks = result.items;
    });
  }
  getGenderTypes(): void{
    this._genderTypeService.getGenderType(this.filter).subscribe((result) => {
      this.genderTypes = result.items;
    });
  }
  getTitleTypes(): void{
    this._titleService.getSMETitle(this.filter).subscribe((result) => {
      this.titles = result.items;
    });
  }
  next() {
    this.stepper.next();
  }

  previous() {
    this.stepper.previous();
  }
  
  btnClick = function() {
    this.router.navigateByUrl('/loanRequests');
};
  bsInitialization() {
    this.stepper = new Stepper(document.querySelector('.bs-stepper'), {
      linear: true,
      animation: true
    })
  }

  // hideDataToggle() {
  //   this.hideData = !this.hideData;
  // } 
  buttn(){
    Okra.buildWithOptions({
      name: 'FinTrak',
      env: 'production-sandbox',
      key: '7c73c766-9081-508c-901a-dc7d9712f93f', 
      token: '5f8718d47c26dc18952e2c3a', 
      callback_url: "",
      onSuccess: function(data){
          console.log('options success', data)
      },
      onClose: function(){
          console.log('options close')
      }
  })
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  enableEligibility(){
    var input = this.eligibilityCheck;
    if(input == this.answer){
      this.eligibleTrue == !this.eligibleTrue;
    }else{
      this.eligibleTrue == this.eligibleTrue;
    }
  }
  // enableEligibility(){
  //   //var input = this.eligibilityCheck;
  //   if(this.eligi == 'yes'){
  //     this.eligibleTrue = false;
  //   }else{
  //     this.eligibleTrue = true;
  //   }
  // }

  
 
testOkra(){
  Okra.buildWithOptions({
    name: 'Peter the Builder',
    env: 'production-sandbox',
    app_id: '',// app_id from your app builderbuttn,
    key: '', // Your key from the Okra dashboard
    token: '', // Your token from the okra dashboard
    products: ['auth','identity','balance','transactions', 'income'], //in lowercase
    onSuccess: function(data:any){
        console.log('options success', data)
    },
    onClose: function(){
        console.log('options close')
    }
})
}
}
