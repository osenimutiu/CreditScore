import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import {  CreateScoringInputDataDto, HistogramServiceProxy, PostResultDto, ScoringInputDataListDto, ScoringInputDataServiceProxy, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';
import * as moment from 'moment';
import { BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';
import * as XLSX from 'xlsx';
import { PrimengTableHelper } from 'shared/helpers/PrimengTableHelper';


@Component({
  selector: 'app-scoring-input-data',
  templateUrl: './scoring-input-data.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScoringInputDataComponent extends AppComponentBase {
  p: number = 1;
  scoringInputData: ScoringInputDataListDto[] = [];
  filter: string = '';
  trainingSampleFilter: '';
  uniqueIDFilter: '';
  ageFilter: '';
  returnonAssetsFilter: '';
  locationFilter: '';
  residentstatusFilter: '';
  timeatJobFilter: '';
  timeatresidenceFilter: '';
  productFilter: '';
  sectorFilter: '';
  subsectorFilter: '';
  currentAccountStatusFilter: '';
  totalassetsFilter: '';
  rentFilter: '';
  renttoIncomeFilter: '';
  timeatBankFilter: '';
  numberofproductsFilter: '';
  paymentperformanceFilter: '';
  previousclaimsFilter: '';
  goodBadFilter: '';
  dateopenedFilter: '';
  incomeFilter: '';
  



@Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
@ViewChild('modal') modal: ModalDirective;
@ViewChild('uniqueIDInput') uniqueIDInput: ElementRef;

active: boolean = false;
saving: boolean = false;
closeResult = ''; 
uniqueID: string;
editingScoringInputData: ScoringInputDataListDto = null;


storeData: any;
fileUploaded: File;
worksheet: any;
scoringresult: any;
scoring: Tbl_ScoringData[] = [];
templateUrl: string;
isLoading = false;
periodDatePicker: any;
dateopened: moment.Moment;


@ViewChild('uploadItemSI', { static: true }) uploadItemSI: any;

@ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
primengTableHelperAuditLogs = new PrimengTableHelper();
primengTableHelperEntityChanges = new PrimengTableHelper();
advancedFiltersAreShown = false;

  constructor(
    injector: Injector,
    private _scoringInputDataService: ScoringInputDataServiceProxy,
    private _inputData: Tbl_ScoringDataAppSeriviceServiceProxy,
    private _hist: HistogramServiceProxy,
    private _modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector);
  }

  ngOnInit(): void {
    
  }

  xlSerialToJsDate(xlSerial) {
    return new Date(-2209075200000 + (xlSerial - (xlSerial < 61 ? 0 : 1)) * 86400000);
  }


  linkMigrate(){
    this.router.navigate(['/scoring-output']);
  }
  
  // getScoringInputData(): void{
  //   this._scoringInputDataService.getScoringInputData(this.filter).subscribe((result) => {
  //     this.scoringInputData = result.items;
  //   });
  // }
  getInputData(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._inputData.getInputData(
      this.filter,
      this.uniqueIDFilter,
       this.primengTableHelper.getSorting(this.dataTable),
       this.primengTableHelper.getMaxResultCount(this.paginator, event),
       this.primengTableHelper.getSkipCount(this.paginator, event)
       
       ) .subscribe((result) => {
          this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
      });
    
  }

  reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
  }

  Search(){
    if(this.uniqueID != ""){
      this.scoringInputData = this.scoringInputData.filter(res=>{ 
        return res.uniqueID.toLocaleLowerCase().match(this.uniqueID.toLocaleLowerCase());
      });
    }else if(this.uniqueID == ""){
      this.ngOnInit();
    }
    
  }

  close(): void{
    this.modal.hide();
    this.active = false;
  }

//   save(): void {
//     let input = new CreateScoringInputDataInput();
//     this.saving = true;
//     this._scoringInputDataService.createScoringInputData(input)
//         .pipe(finalize(() => { this.saving = false; }))
//         .subscribe(() => {
//             this.notify.info(this.l('SavedSuccessfully'));
//             this.close();
//             this.modalSave.emit(null);
//         });
//  }

 deleteScoringInputData(scoringInputDatum: ScoringInputDataListDto): void {
  this.message.confirm(
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._scoringInputDataService.deleteScoringInputData(scoringInputDatum.id)
              .subscribe(() => {
                   // this.reloadPage();
                      this.notify.success(this.l('Successfully Deleted'));
                      _.remove(this.scoringInputData, scoringInputDatum);
                  });
          }
      }
  );
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}


uploadedFile(event) {
  this.fileUploaded = event.target.files[0];
this.showMainSpinner();
 // this.saving = false;
  this.readExcelScoringInputData();
  //this.uploadUnreconciledBalance();
 // this.saving = true;
 //this.selectAccountBankMapping(this.accountp);
 this.hideMainSpinner();

}

UploadInputData() {
  this.saving = false;
  this.showMainSpinner();
      this.fileUploaded = this.uploadItemSI.nativeElement.files[0];
      
   this.readExcelScoringInputData();
      this.saving = true;   
      this.hideMainSpinner();
    }


    readExcelScoringInputData() {
       let inputValueDateopened= this.dateopened;
      let fileReader = new FileReader();
  
      fileReader.onload = (e) => {
        this.storeData = fileReader.result;
        let data = new Uint8Array(this.storeData);
        let arr = new Array();
        for (let i = 0; i !== data.length; ++i) { arr[i] = String.fromCharCode(data[i]); }
        let bstr = arr.join('');
        let workbook = XLSX.read(bstr, { type: 'binary', cellDates: true, dateNF:'mm.dd.yyyy' });
        let first_sheet_name = workbook.SheetNames[0];
        let worksheet = workbook.Sheets[first_sheet_name];
        this.scoringresult = XLSX.utils.sheet_to_json(worksheet, { raw: true });
        this.scoring = [];
        this.scoringresult.forEach(a => {
          let post: Tbl_ScoringData = new Tbl_ScoringData();
          post.unique_ID = a['UniqueID'];
          post.trainingSample = a['TrainingSample'];
          post.date_opened = a['Dateopened'];
          post.age = a['Age'];
          post.income = a['Income'];
          post.location = a['Location'];
          post.resident_status = a['Residentstatus'];
          post.time_at_Job = a['TimeatJob'];
          post.time_at_residence = a['Timeatresidence'];
          post.product = a['Product'];
          post.current_Account_Status = a['CurrentAccountStatus'];
          post.total_assets = a['TotalAssets'];
          post.rent = a['Rent'];
          post.rent_to_Income = a['RenttoIncome'];
          post.return_on_Assets = a['ReturnonAssets'];
          post.time_at_Bank = a['TimeatBank'];
          post.number_of_products = a['Numberofproducts'];
          post.payment_performance = a['Paymentperformance'];
          post.previous_claims = a['Previousclaims'];
          post.good_Bad = a['GoodBad'];
         
          this.scoring.push(post);
  
        });
          debugger;
        //  console.log(this.account);
  
        this._inputData.insertScoring(this.scoring).pipe(finalize(() => { this.saving = false; }))
          .subscribe(() => {
              this.notify.info(this.l('SavedSuccessfully'));
              this.message.info(this.l('SavedSuccessfully'));
              this.getInputData();
            });
       
     
      };
      fileReader.readAsArrayBuffer(this.fileUploaded);
      this.uploadItemSI.nativeElement.value = null;
  
  
    }

    // computeScore(): void{
    //   this.saving = true;
      
    //      this._scoringService.computeFirstApplicationScore(
    //        this.param1,
    //        this.param2,
    //        this.param3,
    //        this.param4,
    //        this.param5,
    //        this.param6,
    //        this.param7,
    //        this.param8,
    //        this.param9
    
    //      )
    //      .pipe(finalize(() => this.saving = false))
    //      .subscribe(() =>{
    //       this.notify.success(this.l('Scores Computed Successfully'));
         
    //      })
    // }
    

    computeBulkScore(): void{
      this.saving = true;
      this._scoringInputDataService.computeWholeScore()
      .pipe(finalize(() => this.saving = false))
      .subscribe(() =>{
        this.notify.success(this.l('Scores Computed Successfully'));
      })
    }
  runDistStat(){
    this._hist.runDistStat().subscribe(()=>{
      this.notify.success(this.l('Data Cleansed Successfully'));
    });
  }

}
