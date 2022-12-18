import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AccountAuthorizeListDto, AccountAuthorizeServiceProxy, BusRegNigListDto, BusRegNigServiceProxy, HaveBankAccountListDto, HaveBankAccountServiceProxy, HaveNINListDto, HaveNINServiceProxy, OperationEligibilityListDto, OperationEligibilityServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-eligibility',
  templateUrl: './eligibility.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class EligibilityComponent extends AppComponentBase {
  haveNINs: HaveNINListDto[] = [];
  haveBankAccounts: HaveBankAccountListDto[] = [];
  accountAuthorize: AccountAuthorizeListDto[] = [];
  busRegs: BusRegNigListDto[] = [];
  opElibilities: OperationEligibilityListDto[] = [];
  active: boolean = false;
  saving: boolean = false;
  filter: string = '';
  userName = '';
  
  constructor(
    injector: Injector,
    private _haveNINService:HaveNINServiceProxy,
    private _haveBankAccountService: HaveBankAccountServiceProxy,
    private _accountAuthorizeService: AccountAuthorizeServiceProxy,
    private _busRegService : BusRegNigServiceProxy,
    private _opElibilityService : OperationEligibilityServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
  ) {
    super(injector);
   }

  ngOnInit(): void {
    this.getBusRegisInfos();
    this.getHaveAccountInfos();
    this.getNINInfos();
    this.getOperationEligibilityInfos();
    this.getaccountAuthorizeinfos();
    
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

}
