import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto, Tbl_GoodBadInputRawDto, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-output-curve-res-stat',
  templateUrl: './output-curve-res-stat.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class OutputCurveResStatComponent extends AppComponentBase implements OnInit {
  resident_status: string;
  saving: boolean = false;
  isActive: boolean = false;
  modifiedText: string;
  Linechart:any = []; 
  barchart:any = []; 
  barchartRaw:any = []; 
  Goodresident_statusCount = []; 
  Goodresident_statusCountRaw = []; 
  Badresident_statusCount = []; 
  Badresident_statusCountRaw = [];
  resident_statusHorizontal = []; 
  resident_statusHorizontalRaw = []; 
  listDistinctresident_status:any=[];
  listoutputresident_statuss: TblOutput_TableDto[] = [];
  listoutputresident_statussRaw: Tbl_ScoringData[] = [];
  resident_statusTitle: string;
  resident_statusTitleRaw: string;


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
    this.getAllForresident_status();
    this.getAllForresident_statusRaw();
    this.getDistinctResidentStatus();
  }


  fornullresident_status(): void{
    let x = this.resident_status;
    if(x == "All"){
      this.postForAllresident_status();
      this.getAllForresident_status();
    }else{
      this.getcountForresident_statusChart();
    }
}

fornullresident_statusRaw(): void{
  let x = this.resident_status;
  if(x == "All"){
    this.postForAllresident_statusRaw();
    this.getAllForresident_statusRaw();
  }else{
    this.getcountForresident_statusChartRaw();
  }
}


postForAllresident_status():void{
  this._service.postForAll().subscribe(() => {
  });
  this.getbarchartForresident_statusCount();
}

postForAllresident_statusRaw():void{
  this._service.postForAllRaw().subscribe(() => {
  });
  this.getbarchartForresident_statusCountRaw();
}

getAllForresident_status(): void{
  this._service.getTblOutput().subscribe((result) => {
    this.listoutputresident_statuss = result;
  });
}

getAllForresident_statusRaw(): void{
  this._inputData.getInputDataForCount().subscribe((result) => {
    this.listoutputresident_statussRaw = result;
  });
}


onresident_statusSelected(val:any){
  this.customresident_statusFunction(val);
  this.Searchresident_status();
  this.Searchresident_statusRaw();
  this.fornullresident_status();
  this.fornullresident_statusRaw();
 }

 customresident_statusFunction(val:any){
  this.modifiedText = val + " selected";
}

Searchresident_status(){
  if(this.resident_status != ""){
    this.listoutputresident_statuss = this.listoutputresident_statuss.filter(res=>{ 
      return res.resident_status.toLocaleLowerCase().match(this.resident_status.toLocaleLowerCase());
    });
  }else if(this.resident_status == ""){
    this.ngOnInit();
  } 
}

Searchresident_statusRaw(){
  if(this.resident_status != ""){
    this.listoutputresident_statussRaw = this.listoutputresident_statussRaw.filter(res=>{ 
      return res.resident_status.toLocaleLowerCase().match(this.resident_status.toLocaleLowerCase());
    });
  }else if(this.resident_status == ""){
    this.ngOnInit();
  } 
}


public getRowsValueForGood_Badresident_status(flag) {
  if (flag === null) {
    return this.listoutputresident_statuss.length;
  } else {
    return this.listoutputresident_statuss.filter(i => (i.good_Bad == flag)).length;
  }
}

public getRowsValueForGood_Badresident_statusRaw(flag) {
  if (flag === null) {
    return this.listoutputresident_statussRaw.length;
  } else {
    return this.listoutputresident_statussRaw.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}


getcountForresident_statusChart(): void{
  this._service.postResident_statusParam(this.resident_status).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForresident_statusCount();
  });
}

getcountForresident_statusChartRaw(): void{
  this._service.postResidentStatusParamRaw(this.resident_status).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForresident_statusCountRaw();
  });
}



getbarchartForresident_statusCount(): void{
  // this.reload();
  this.isActive = true;
  this.resident_statusTitle = "Cleansed"
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
   result.forEach(x => {  
      this.Goodresident_statusCount.push(x.good);  
      this.Badresident_statusCount.push(x.bad);  
      this.resident_statusHorizontal.push(x.goodLabel);  
    }); 
    this  
    this.barchart = new Chart('goodresident_status', {  
      type: 'bar',  
      data: {  
        labels: this.resident_statusHorizontal,  
        datasets: [  
          {  
            data: this.Goodresident_statusCount,
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
            data: this.Badresident_statusCount,  
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

getbarchartForresident_statusCountRaw(): void{
  // this.reload();
  this.isActive = true;
  this.resident_statusTitleRaw = "Uncleanse"
  this._service.getGoodBadInputRaw().subscribe((result: Tbl_GoodBadInputRawDto[]) => {  
   result.forEach(x => {  
      this.Goodresident_statusCountRaw.push(x.good);  
      this.Badresident_statusCountRaw.push(x.bad);  
      this.resident_statusHorizontalRaw.push(x.goodLabel);  
    }); 
    this  
    this.barchartRaw = new Chart('goodresident_statusraw', {  
      type: 'bar',  
      data: {  
        labels: this.resident_statusHorizontalRaw,  
        datasets: [  
          {  
            data: this.Goodresident_statusCountRaw,
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
            data: this.Badresident_statusCountRaw,  
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

getDistinctResidentStatus(){
  this._service.getDistictResident_status().subscribe(res =>{
    this.listDistinctresident_status = res;
  })
}


}
