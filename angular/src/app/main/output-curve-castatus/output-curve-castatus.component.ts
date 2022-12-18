import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto, Tbl_GoodBadInputRawDto, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-output-curve-castatus',
  templateUrl: './output-curve-castatus.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class OutputCurveCastatusComponent extends AppComponentBase implements OnInit {
  current_Account_Status: string;
  saving: boolean = false;
  isActive: boolean = false;
  modifiedText: string;
  Linechart:any = [];
  barchart:any = [];
  barchartRaw:any = []; 
  Goodcurrent_Account_StatusCount = [];
  Goodcurrent_Account_StatusCountRaw = []; 
  Badcurrent_Account_StatusCount = []; 
  Badcurrent_Account_StatusCountRaw = [];
  current_Account_StatusHorizontal = []; 
  current_Account_StatusHorizontalRaw = []; 
  listDistinctcurrent_Account_Status:any=[];
  listoutputcurrent_Account_Statuss: TblOutput_TableDto[] = [];
  listoutputcurrent_Account_StatussRaw: Tbl_ScoringData[] = [];
  current_Account_StatusTitle: string;
  current_Account_StatusTitleRaw: string;
  constructor(
    private _service: CurveServiceProxy,
    private _inputData: Tbl_ScoringDataAppSeriviceServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
    private inj: Injector
  ) { 
    super(inj)
  }


  ngOnInit(): void {
    this.getAllForcurrent_Account_Status();
    this.getAllForcurrent_Account_StatusRaw();
    this.getcurrent_Account_Status();
  }

  fornullcurrent_Account_Status(): void{
    
    let x = this.current_Account_Status;
    if(x == "All"){
      this.postForAllcurrent_Account_Status();
      this.getAllForcurrent_Account_Status();
    }else{
      this.getcountForcurrent_Account_StatusChart();
    }
}

fornullcurrent_Account_StatusRaw(): void{
  debugger;
  let x = this.current_Account_Status;
  if(x == "All"){
    this.postForAllcurrent_Account_StatusRaw();
    this.getAllForcurrent_Account_StatusRaw();
  }else{
    this.getcountForcurrent_Account_StatusChartRaw();
  }
}

postForAllcurrent_Account_Status():void{
  this._service.postForAll().subscribe(() => {
  });
  this.getbarchartForcurrent_Account_StatusCount();
}
postForAllcurrent_Account_StatusRaw():void{
  this._service.postForAllRaw().subscribe(() => {
  });
  this.getbarchartForcurrent_Account_StatusCountRaw();
}


getAllForcurrent_Account_Status(): void{
  this._service.getTblOutput().subscribe((result) => {
    this.listoutputcurrent_Account_Statuss = result;
  });
}
getAllForcurrent_Account_StatusRaw(): void{
  this._inputData.getInputDataForCount().subscribe((result) => {
    this.listoutputcurrent_Account_StatussRaw = result;
  });
}

oncurrent_Account_StatusSelected(val:any){
  this.customcurrent_Account_StatusFunction(val);
  this.Searchcurrent_Account_Status();
  this.Searchcurrent_Account_StatusRaw();
  this.fornullcurrent_Account_Status();
  this.fornullcurrent_Account_StatusRaw();
 }

 customcurrent_Account_StatusFunction(val:any){
  this.modifiedText = val + " selected";
}

Searchcurrent_Account_Status(){
  if(this.current_Account_Status != ""){
    this.listoutputcurrent_Account_Statuss = this.listoutputcurrent_Account_Statuss.filter(res=>{ 
      return res.current_Account_Status.toLocaleLowerCase().match(this.current_Account_Status.toLocaleLowerCase());
    });
  }else if(this.current_Account_Status == ""){
    this.ngOnInit();
  } 
}


Searchcurrent_Account_StatusRaw(){
  if(this.current_Account_Status != ""){
    this.listoutputcurrent_Account_StatussRaw = this.listoutputcurrent_Account_StatussRaw.filter(res=>{ 
      return res.current_Account_Status.toLocaleLowerCase().match(this.current_Account_Status.toLocaleLowerCase());
    });
  }else if(this.current_Account_Status == ""){
    this.ngOnInit();
  } 
}

public getRowsValueForGood_Badcurrent_Account_Status(flag) {
  if (flag === null) {
    return this.listoutputcurrent_Account_Statuss.length;
  } else {
    return this.listoutputcurrent_Account_Statuss.filter(i => (i.good_Bad == flag)).length;
  }
}

public getRowsValueForGood_Badcurrent_Account_StatusRaw(flag) {
  if (flag === null) {
    return this.listoutputcurrent_Account_StatussRaw.length;
  } else {
    return this.listoutputcurrent_Account_StatussRaw.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}
getcountForcurrent_Account_StatusChart(): void{
  this._service.postCurrAccStatusParam(this.current_Account_Status).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForcurrent_Account_StatusCount();
  });
}

getcountForcurrent_Account_StatusChartRaw(): void{
  this._service.postCurrAccStatParamRaw(this.current_Account_Status).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForcurrent_Account_StatusCountRaw();
  });
}


getbarchartForcurrent_Account_StatusCount(): void{
  // this.reload();
  this.isActive = true;
  this.current_Account_StatusTitle = "Cleansed"
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
   result.forEach(x => {  
      this.Goodcurrent_Account_StatusCount.push(x.good);  
      this.Badcurrent_Account_StatusCount.push(x.bad);  
      this.current_Account_StatusHorizontal.push(x.goodLabel);  
    }); 
    this  
    this.barchart = new Chart('goodcurrent_Account_Status', {  
      type: 'bar',  
      data: {  
        labels: this.current_Account_StatusHorizontal,  
        datasets: [  
          {  
            data: this.Goodcurrent_Account_StatusCount,
            label: 'Good',  borderColor: '#3cba9f',  
            backgroundColor: [  
              "#3cb371",  
              "#0000FF",  
              "#9966FF",  
              "#4C4CFF" 
            ],  
            // fill: true 
          },
          {  
            data: this.Badcurrent_Account_StatusCount,  
            label: 'Bad',
            borderColor: '#3cba9f',  
            backgroundColor: [  
              "#eb4034",  
              "#eb4034",  
              "##eb4034",  
              "##eb4034" 
            ],  
            // fill: true 
          }
        ]  
      },  
      options: {  
        // legend: {  
        //   display: true  
        // },  
        scales: {  
          xAxes: {  
            display: true  
          },  
          yAxes: {  
            display: true  
          },  
        }  
      }  
    });  
  });  
}

getbarchartForcurrent_Account_StatusCountRaw(): void{
  // this.reload();
  this.isActive = true;
  this.current_Account_StatusTitleRaw = "Uncleanse"
  this._service.getGoodBadInputRaw().subscribe((result: Tbl_GoodBadInputRawDto[]) => {  
   result.forEach(x => {  
      this.Goodcurrent_Account_StatusCountRaw.push(x.good);  
      this.Badcurrent_Account_StatusCountRaw.push(x.bad);  
      this.current_Account_StatusHorizontalRaw.push(x.goodLabel);  
    }); 
    this  
    this.barchartRaw = new Chart('goodcurrent_Account_Statusraw', {  
      type: 'bar',  
      data: {  
        labels: this.current_Account_StatusHorizontalRaw,  
        datasets: [  
          {  
            data: this.Goodcurrent_Account_StatusCountRaw,
            label: 'Good',  
            borderColor: '#3cba9f',  
            backgroundColor: [  
              "#3cb371",  
              "#0000FF",  
              "#9966FF",  
              "#4C4CFF" 
            ],  
            // fill: true 
          },
          {  
            data: this.Badcurrent_Account_StatusCountRaw,  
            label: 'Bad',
            borderColor: '#3cba9f',  
            backgroundColor: [  
              "#eb4034",  
              "#eb4034",  
              "##eb4034",  
              "##eb4034" 
            ],  
            // fill: true 
          }
        ]  
      },  
      options: {  
        // legend: {  
        //   display: true  
        // },  
        scales: {  
          xAxes: {  
            display: true  
          },  
          yAxes: {  
            display: true  
          },  
        }  
      }  
    });  
  });  
}
getcurrent_Account_Status(){
  this._service.getDistictCurrAccStatus().subscribe(res =>{
    this.listDistinctcurrent_Account_Status = res;
  })
}
}
