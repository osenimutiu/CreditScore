import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto, Tbl_GoodBadInputRawDto, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-output-curve-pay-perf',
  templateUrl: './output-curve-pay-perf.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class OutputCurvePayPerfComponent extends AppComponentBase implements OnInit {
  payment_performance: string;
  saving: boolean = false;
  isActive: boolean = false;
  modifiedText: string;
  Linechart:any = []; 
  barchart:any = []; 
  barchartRaw:any = []; 
  Goodpayment_performanceCount = []; 
  Goodpayment_performanceCountRaw = []; 
  Badpayment_performanceCount = []; 
  Badpayment_performanceCountRaw = [];
  payment_performanceHorizontal = []; 
  payment_performanceHorizontalRaw = []; 
  listDistinctpayment_performance:any=[];
  listoutputpayment_performances: TblOutput_TableDto[] = [];
  listoutputpayment_performancesRaw: Tbl_ScoringData[] = [];
  payment_performanceTitle: string;
  payment_performanceTitleRaw: string;
  listDistinctpayPerformance: string[];

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
    this.getAllForpayment_performance();
    this.getAllForpayment_performanceRaw();
    this.getDistinctpayPerformance();
  }

  fornullpayment_performance(): void{
    let x = this.payment_performance;
    if(x == "All"){
      this.postForAllpayment_performance();
      this.getAllForpayment_performance();
    }else{
      this.getcountForpayment_performanceChart();
    }
}

fornullpayment_performanceRaw(): void{
  let x = this.payment_performance;
  if(x == "All"){
    this.postForAllpayment_performanceRaw();
    this.getAllForpayment_performanceRaw();
  }else{
    this.getcountForpayment_performanceChartRaw();
  }
}

postForAllpayment_performance():void{
  this._service.postForAll().subscribe(() => {
  });
  this.getbarchartForpayment_performanceCount();
}

postForAllpayment_performanceRaw():void{
  this._service.postForAllRaw().subscribe(() => {
  });
  this.getbarchartForpayment_performanceCountRaw();
}


getAllForpayment_performance(): void{
  this._service.getTblOutput().subscribe((result) => {
    this.listoutputpayment_performances = result;
  });
}

getAllForpayment_performanceRaw(): void{
  this._inputData.getInputDataForCount().subscribe((result) => {
    this.listoutputpayment_performancesRaw = result;
  });
}


onpayment_performanceSelected(val:any){
  this.custompayment_performanceFunction(val);
  this.Searchpayment_performance();
  this.Searchpayment_performanceRaw();
  this.fornullpayment_performance();
  this.fornullpayment_performanceRaw();
 }

 custompayment_performanceFunction(val:any){
  this.modifiedText = val + " selected";
}


Searchpayment_performance(){
  if(this.payment_performance != ""){
    this.listoutputpayment_performances = this.listoutputpayment_performances.filter(res=>{ 
      return res.payment_performance.toLocaleLowerCase().match(this.payment_performance.toLocaleLowerCase());
    });
  }else if(this.payment_performance == ""){
    this.ngOnInit();
  } 
}


Searchpayment_performanceRaw(){
  if(this.payment_performance != ""){
    this.listoutputpayment_performancesRaw = this.listoutputpayment_performancesRaw.filter(res=>{ 
      return res.payment_performance.toLocaleLowerCase().match(this.payment_performance.toLocaleLowerCase());
    });
  }else if(this.payment_performance == ""){
    this.ngOnInit();
  } 
}


public getRowsValueForGood_Badpayment_performance(flag) {
  if (flag === null) {
    return this.listoutputpayment_performances.length;
  } else {
    return this.listoutputpayment_performances.filter(i => (i.good_Bad == flag)).length;
  }
}


public getRowsValueForGood_Badpayment_performanceRaw(flag) {
  if (flag === null) {
    return this.listoutputpayment_performancesRaw.length;
  } else {
    return this.listoutputpayment_performancesRaw.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}


getcountForpayment_performanceChart(): void{
  this._service.postPayment_performanceParam(this.payment_performance).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForpayment_performanceCount();
  });
}

getcountForpayment_performanceChartRaw(): void{
  this._service.postPayment_performanceParamRaw(this.payment_performance).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForpayment_performanceCountRaw();
  });
}


getbarchartForpayment_performanceCount(): void{
  // this.reload();
  this.isActive = true;
  this.payment_performanceTitle = "Cleansed"
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
   result.forEach(x => {  
      this.Goodpayment_performanceCount.push(x.good);  
      this.Badpayment_performanceCount.push(x.bad);  
      this.payment_performanceHorizontal.push(x.goodLabel);  
    }); 
    this  
    this.barchart = new Chart('goodpayment_performance', {  
      type: 'bar',  
      data: {  
        labels: this.payment_performanceHorizontal,  
        datasets: [  
          {  
            data: this.Goodpayment_performanceCount,
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
            data: this.Badpayment_performanceCount,  
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

getbarchartForpayment_performanceCountRaw(): void{
  // this.reload();
  this.isActive = true;
  this.payment_performanceTitleRaw = "Uncleanse"
  this._service.getGoodBadInputRaw().subscribe((result: Tbl_GoodBadInputRawDto[]) => {  
   result.forEach(x => {  
      this.Goodpayment_performanceCountRaw.push(x.good);  
      this.Badpayment_performanceCountRaw.push(x.bad);  
      this.payment_performanceHorizontalRaw.push(x.goodLabel);  
    }); 
    this  
    this.barchartRaw = new Chart('goodpayment_performanceraw', {  
      type: 'bar',  
      data: {  
        labels: this.payment_performanceHorizontalRaw,  
        datasets: [  
          {  
            data: this.Goodpayment_performanceCountRaw,
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
            data: this.Badpayment_performanceCountRaw,  
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
getDistinctpayPerformance(){
  this._service.getDistictPayment_performance().subscribe(res =>{
    this.listDistinctpayPerformance = res;
  })
}
}
