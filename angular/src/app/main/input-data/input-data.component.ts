import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CollectAttributeDto, CreateInputDataInput,CreateInputDataValueCollectorInput, CurveServiceProxy, InputDataListDto, InputDataServiceProxy, InputDataValueCollectorListDto, InputDataValueCollectorServiceProxy } from '@shared/service-proxies/service-proxies';
import { forEach } from 'lodash';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { SelectItem } from 'primeng/api';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';
import { LazyLoadEvent } from 'primeng/public_api';
import * as _ from 'lodash';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

//import { SelectItem } from '@bit/primefaces.primeng.multiselect/common/selectitem';

@Component({
  selector: 'app-input-data',
  templateUrl: './input-data.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class InputDataComponent extends AppComponentBase {

inputData: CreateInputDataInput = new CreateInputDataInput();  
taxtransactForm : NgForm;
inp2utData: InputDataListDto[] = [];
inputDataValue: InputDataValueCollectorListDto[] = [];
data: InputDataListDto[] = [];
columnHeaders:any=[];
insertedHeadersList: CollectAttributeDto[] = [];


active: boolean = false;
saving: boolean = false;
filter: string = '';


resultText: any = [];  
values:any;  
count:number=0;  
errorMsg:string; 


results = [];
checked = false;
masterSelected:boolean;
//results: boolean[] = [];
param: string = '';
param2: number;


 x: CreateInputDataValueCollectorInput = new CreateInputDataValueCollectorInput();
 @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
 @ViewChild('modal') modal: ModalDirective;
 @ViewChild('inputValuesInput') inputValuesInput: ElementRef;
 @ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;

isMasterSel:boolean;
checkedCategoryList:any;
isSelected:false;

  constructor(
    injector: Injector,
    private service:InputDataServiceProxy,
    private _inputDataService: InputDataServiceProxy,
    private _curveService: CurveServiceProxy,
    private _inputDataValueService: InputDataValueCollectorServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
    private inputCollectorService: InputDataValueCollectorServiceProxy

  ) { 
    super(injector);
    this.isMasterSel = false;

   
  }

  ngOnInit(): void {
    this.getInputData(); 
    this.getHeaders(); 
    this.extractHeader(); 
  }

  checks = false;
 bulk(e){
   
   if(e.target.checked==true){
     this.checks = true;
     //this.multipleCheckCount.push(this.checks);
    // this.resultText.push(data);  
     //this.onChange(this.values.toString(),this.param2);
   }
   else{
     this.checks=false;
    //  const index = this.resultText.indexOf(data);  
    //  this.resultText.splice(index, 1);
   } 
  //  this.values=this.resultText.toString();  
  //    const count=this.resultText.length;  
  //    this.count=count;  
  }

  reload() {
    this.inputData = new CreateInputDataInput();
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  } 

  getSelectedAttributes(event?: LazyLoadEvent): void{
    if (this.primengTableHelper.shouldResetPaging(event)) {
      this.paginator.changePage(0);
      return;
  }

  this.primengTableHelper.showLoadingIndicator();
    this._inputDataValueService.getInputDataValueCollectorInput(
      this.filter,
      this.primengTableHelper.getSorting(this.dataTable),
       this.primengTableHelper.getSkipCount(this.paginator, event),
       this.primengTableHelper.getMaxResultCount(this.paginator, event)
      ).subscribe((result) => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
      this.primengTableHelper.records = result.items;
      this.primengTableHelper.hideLoadingIndicator();
      
    });
  }
  
  deleteSelectedAttributes(res: InputDataValueCollectorListDto): void{
    this.message.confirm(
      '',
      this.l('Are you sure?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._inputDataValueService.deleteSelectedAttributes(res.id)
                  .subscribe(() => {
                      this.notify.success(this.l('Successfully Deleted'));
                      _.remove(this.inputDataValue, res);
                      this.fillExclusion();
                      this.getSelectedAttributes();
                  });
          }
      }
  );
  }

  getColumsList(): void{
    this._inputDataService.getInputDataList().subscribe((result) => {
        //result;
        console.log(result);
       this.results = result;
    });
  }

  // CheckAllOptions() {
  //   //this.results
  //   if (this.checkboxes.every(val => val.checked == true))
  //     this.checkboxes.forEach(val => { val.checked = false });
  //   else
  //     this.checkboxes.forEach(val => { val.checked = true });
  //     this.outcodeChange(); 
  // }
  
  CheckAllDropdowns() {
     //this.results = ;
    if (this.results.every(val => val.checked == true))
      this.results.forEach(val => { val.checked = false });
    else 
      this.results.forEach(val => { val.checked = true }); 
      
  }

  checkUncheckAll1() {
    for (var i = 0; i < this.results.length; i++) {
      this.results[i].isSelected = this.masterSelected;
    }
    // this.getCheckedItemList();
  }

  // outcodeChange(){
  //   console.log(this.checkboxes);
  // }
  
   checkUncheckAll() {
    for (var i = 0; i < this.resultText.length; i++) {
      this.resultText[i].isSelected = this.isMasterSel;
    }
    this.getCheckedItemList();
  }

  isAllSelected() {
    this.isMasterSel = this.resultText.every(function(item:any) {
        return item.isSelected == true;
      })
   this.getCheckedItemList();
  }
  
  getCheckedItemList(){
    this.checkedCategoryList = [];
    for (var i = 0; i < this.resultText.length; i++) {
      if(this.resultText[i].isSelected)
      this.checkedCategoryList.push(this.resultText[i]);
    }
    this.checkedCategoryList = JSON.stringify(this.checkedCategoryList);
  }

  getInputData(): void{
    this.service.getInputData(this.filter).subscribe(res => {  
      this.data = res.items; 
      console.log(this.inputData); 
    }); 
  }
  getHeaders(): void{
    this._curveService.getHeaders().subscribe(res => {  
      this.columnHeaders = res; 
    }); 
  }

save(): void {
  this.saving = true;
  this.service.createInputData(this.inputData)
      .pipe(finalize(() => this.saving = false))
      .subscribe(() => {
          this.notify.success(this.l('Saved Successfully'));
          this.modalSave.emit(this.inputData); 
      });
      this.reload()
}

onChange(attributes:string,event) {  
  this.errorMsg="";  
   const checked = event.target.checked;  
  
    if (checked) { 
      this.resultText.push(attributes);  

       } else {  
         const index = this.resultText.indexOf(attributes);  
         this.resultText.splice(index, 1);  
     }  
     this.values=this.resultText.toString();  
     const count=this.resultText.length;  
     this.count=count;
     console.log(this.values);  

  } 

  onChangeb(attributes:string,event) {  
    this.errorMsg="";  
     const checked = event.target.checked;  
    
      if (checked) { 
        
        for(var i = 22; i>= this.resultText.length; i--){
          this.resultText[i].push(attributes);  
        }
         } else {  
           const index = this.resultText.indexOf(attributes);  
           this.resultText.splice(index, 1);  
       }  
       this.values=this.resultText.toString();  
       const count=this.resultText.length;  
       this.count=count;
       console.log(this.values);  
  
    } 
     
  checkUncheckAllb(event) {
    const checked = event.target.checked;
    if (checked){
      this.resultText.push(event);  
    for (var i = 0; i < this.resultText.length; i++) {
      this.resultText[i].checked = this.isMasterSel;
    }
  }
    this.getCheckedItemList();
  }

  saveAttributes() {  
  
    const count=this.resultText.length;  
    
    if(count == 0)  
    {  
      this.errorMsg="Select at least one attribute";  
    }  
    else  
    {  
      this.count=count;  
    }  
    for (var i = 0; i < this.resultText.length; i++) 
     this.inputCollectorService.createSelectedAttributes(this.resultText[i].toString(), this.param2)
   
  .subscribe(() => {
    this.notify.success(this.l('Attributes Saved Successfully'));
    this.fillExclusion();
});

this.reload()

   } 

   HeaderList(){
    this._inputDataValueService.getCollectAttribute().subscribe(res =>{
      this.insertedHeadersList = res;
    });
   }
   extractHeader(){
    this._curveService.insertHeaders().subscribe(() =>{
      this.HeaderList();
    });
   }

   fillExclusion(){
     this._inputDataValueService.fillCreditExclusion().subscribe(()=>{
     })
   }
  
}