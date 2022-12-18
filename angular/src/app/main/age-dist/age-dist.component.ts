import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { AgeDistributionDto, CreditScore_PointAllocationDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';

@Component({
  selector: 'app-age-dist',
  templateUrl: './age-dist.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class AgeDistComponent extends AppComponentBase implements OnInit {
ageList: AgeDistributionDto[] = [];
@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
result:any=[];
age: string= 'agebin';
currAccStat: string= 'Current_Account_Status';
location: string= 'Location';
payPerf: string= 'Payment_performance';
product: string= 'Product';
resStauts: string= 'Resident_status';
timeAtJob: string= 'Time_at_Jobbin';
locationParam:string;
modifiedText:string;
p:number = 1;
ac:number = 1;
lo:number = 1;
pr:number = 1;
rs:number = 1;
tj:number = 1;
pp:number = 1;
ageLis:CreditScore_PointAllocationDto[] = []; 
currrAccStaLis:CreditScore_PointAllocationDto[] = []; 
locationLis:CreditScore_PointAllocationDto[] = []; 
// locationBinning:CreditScore_PointAllocationDto[] = []; 
residStatusLis:CreditScore_PointAllocationDto[] = []; 
payPerformanceLis:CreditScore_PointAllocationDto[] = []; 
productLis:CreditScore_PointAllocationDto[] = []; 
timeatJobLis:CreditScore_PointAllocationDto[] = []; 

  constructor(private injector: Injector,
     private _service: ScoreCardServiceProxy,
     private route: ActivatedRoute,
    private router: Router)
   {
     super(injector)
    }

  ngOnInit(): void {
    this.getAge();
    this.getAccuntStatus();
    this.getlocation();
    this.getResSt();
    this.getPayPerf();
    this.getProd();
    this.gettimeJob();
  }

  getAge(){
    this._service.getPointAllocation(this.age).subscribe(res=> {
      this.ageLis = res;
    });
  }
  getAccuntStatus(){
    this._service.getPointAllocation(this.currAccStat).subscribe(res=> {
      this.currrAccStaLis = res;
    });
  }
  getlocation(){
    this._service.getPointAllocation(this.location).subscribe(res=> {
      this.locationLis = res;
    });
  }
  getResSt(){
    this._service.getPointAllocation(this.resStauts).subscribe(res=> {
      this.residStatusLis = res;
    });
  }
  getPayPerf(){
    this._service.getPointAllocation(this.payPerf).subscribe(res=> {
      this.payPerformanceLis = res;
    });
  }
  getProd(){
    this._service.getPointAllocation(this.product).subscribe(res=> {
      this.productLis = res;
    });
  }
  gettimeJob(){
    this._service.getPointAllocation(this.timeAtJob).subscribe(res=> {
      this.timeatJobLis = res;
    });
  }

  // getLocationFiltered(){
  //   this._service.getPointAllocationForLocation(this.locationParam).subscribe(res=>{
  //     this.locationBinning = res;
  //   });
  // }
  // hh
  onLocationSelected(val:any){
    this.customFunction(val);
    this.Search();
   }

   customFunction(val:any){
    this.modifiedText = val + " selected";
  }

  Search(){
    if(this.locationParam != ""){
      this.locationLis = this.locationLis.filter(res=>{ 
        return res.binning.toLocaleLowerCase().match(this.locationParam.toLocaleLowerCase());
      });
    }else if(this.locationParam == ""){
      this.ngOnInit();
    } 
  }
  getAgeDistribution(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.age
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  getCurrAccStatus(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getCurrentAccDist(
       
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  getPaymentPerformanance(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.payPerf
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  getLocation(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.location
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }

  getProduct(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.product
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  getResidentStatus(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.resStauts
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
  getTimeatJobBin(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._service.getPointAllocation(
       this.timeAtJob
       ) .subscribe((result) => {
        this.primengTableHelper.records = result;
        this.result.push(this.primengTableHelper.records);
        this.primengTableHelper.hideLoadingIndicator();
      });
  }
}
