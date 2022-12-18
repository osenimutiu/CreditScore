import { Attribute, Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CreateInputDataInput, InputDataListDto, InputDataServiceProxy, InputDataValueCollectorServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Paginator } from 'primeng/paginator';
import { Table } from 'primeng/table';
import { finalize } from 'rxjs/operators';
import { LazyLoadEvent } from 'primeng/public_api';

@Component({
  selector: 'createInputDataModal',
  templateUrl: './create-input-data-modal.component.html',
  animations: [appModuleAnimation()],
  styleUrls: [ './create-input-data-modal.component.scss']
})
export class CreateInputDataModalComponent extends AppComponentBase {

  data: InputDataListDto[] = [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  
  @ViewChild('createInputDataModal') modal: ModalDirective;
  @ViewChild('unique_IDInput') unique_IDInput: ElementRef;
  @ViewChild('dataTable', { static: true }) dataTable: Table;
@ViewChild('paginator', { static: true }) paginator: Paginator;
  inputData: CreateInputDataInput = new CreateInputDataInput();  
  active: boolean = false;
  saving: boolean = false;
  filter: string = ''; 


  resultText:any=[];  
  values:string;  
 count:number=0;  
 errorMsg:string;
 param2: number;
 multipleCheckCount:any=[];

 //for selectAll
 isMasterSel:boolean;
 checkedCategoryList:any;
 isSelected:false;

  constructor(
    injector: Injector,
    private service:InputDataServiceProxy,
    private inputCollectorService: InputDataValueCollectorServiceProxy
  ) {
    super(injector);
    this.isMasterSel = false;
    this.getCheckedItemList();
   }

  ngOnInit(): void {
    this.getInputData();
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

  show(): void {
    this.active = true;
    this.inputData = new CreateInputDataInput();
    this.modal.show();
}

close(): void {
  this.modal.hide();
  this.active = false;
}

save(): void {
  this.saving = true;
  this.service.createInputData(this.inputData)
      .pipe(finalize(() => this.saving = false))
      .subscribe(() => {
          this.notify.success(this.l('Saved Successfully'));
          this.close();
          this.modalSave.emit(this.inputData); 
      });
}

onChange(attributes:string,event) {  
  this.errorMsg="";  
   const checked = event.target.checked;  
  
    if (checked) { 
      this.resultText.push(attributes);  
      // for(var i = 0; i<= this.resultText.length; i++){
      //   this.InputData.branchName = this.resultText[i];
      //   this.InputData.branchName = checked;
      // }
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
    this.close();
});

   } 


}
