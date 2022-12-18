import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto, Tbl_GoodBadInputRawDto, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-output-curve-location',
  templateUrl: './output-curve-location.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class OutputCurveLocationComponent extends AppComponentBase implements OnInit {
  location: string;
  saving: boolean = false;
  isActive: boolean = false;
  modifiedText: string;
  Linechart:any = []; 
  barchart:any = [];
  barchartRaw:any = []; 
  GoodlocationCount = []; 
  GoodlocationCountRaw = []; 
  BadlocationCount = []; 
  BadlocationCountRaw = []; 
  locationHorizontal = [];
  locationHorizontalRaw = []; 
  listDistinctlocation:any=[];
  listoutputlocations: TblOutput_TableDto[] = [];
  listoutputlocationsRaw: Tbl_ScoringData[] = [];
  locationTitle: string;
  locationTitleRaw: string;


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
    this.getAllForlocation();
    this.getAllForlocationRaw();
    this.getDistinctLocation();
  }

  fornulllocation(): void{
    let x = this.location;
    if(x == "All"){
      this.postForAlllocation();
      this.getAllForlocation();
    }else{
      this.getcountForlocationChart();
    }
}

fornulllocationRaw(): void{
  let x = this.location;
  if(x == "All"){
    this.postForAlllocationRaw();
    this.getAllForlocationRaw();
  }else{
    this.getcountForlocationChartRaw();
  }
}

postForAlllocation():void{
  this._service.postForAll().subscribe(() => {
  });
  this.getbarchartForlocationCount();
}
postForAlllocationRaw():void{
  this._service.postForAllRaw().subscribe(() => {
  });
  this.getbarchartForlocationCountRaw();
}


getAllForlocation(): void{
  this._service.getTblOutput().subscribe((result) => {
    this.listoutputlocations = result;
  });
}
getAllForlocationRaw(): void{
  this._inputData.getInputDataForCount().subscribe((result) => {
    this.listoutputlocationsRaw = result;
  });
}


onlocationSelected(val:any){
  this.customlocationFunction(val);
  this.Searchlocation();
  this.SearchlocationRaw();
  this.fornulllocation();
  this.fornulllocationRaw();
 }

 customlocationFunction(val:any){
  this.modifiedText = val + " selected";
}


Searchlocation(){
  if(this.location != ""){
    this.listoutputlocations = this.listoutputlocations.filter(res=>{ 
      return res.location.toLocaleLowerCase().match(this.location.toLocaleLowerCase());
    });
  }else if(this.location == ""){
    this.ngOnInit();
  } 
}

SearchlocationRaw(){
  if(this.location != ""){
    this.listoutputlocationsRaw = this.listoutputlocationsRaw.filter(res=>{ 
      return res.location.toLocaleLowerCase().match(this.location.toLocaleLowerCase());
    });
  }else if(this.location == ""){
    this.ngOnInit();
  } 
}

public getRowsValueForGood_Badlocation(flag) {
  if (flag === null) {
    return this.listoutputlocations.length;
  } else {
    return this.listoutputlocations.filter(i => (i.good_Bad == flag)).length;
  }
}

public getRowsValueForGood_BadlocationRaw(flag) {
  if (flag === null) {
    return this.listoutputlocationsRaw.length;
  } else {
    return this.listoutputlocationsRaw.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

getcountForlocationChart(): void{
  this._service.postLocationParam(this.location).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForlocationCount();
  });
}

getcountForlocationChartRaw(): void{
  this._service.postLocationParamRaw(this.location).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForlocationCountRaw();
  });
}

getbarchartForlocationCount(): void{
  // this.reload();
  this.isActive = true;
  this.locationTitle = "Cleansed"
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
   result.forEach(x => {  
      this.GoodlocationCount.push(x.good);  
      this.BadlocationCount.push(x.bad);  
      this.locationHorizontal.push(x.goodLabel);  
    }); 
    this  
    this.barchart = new Chart('goodlocation', {  
      type: 'bar',  
      data: {  
        labels: this.locationHorizontal,  
        datasets: [  
          {  
            data: this.GoodlocationCount,
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
            data: this.BadlocationCount,  
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


getbarchartForlocationCountRaw(): void{
  // this.reload();
  this.isActive = true;
  this.locationTitleRaw = "Uncleanse"
  this._service.getGoodBadInputRaw().subscribe((result: Tbl_GoodBadInputRawDto[]) => {  
   result.forEach(x => {  
      this.GoodlocationCountRaw.push(x.good);  
      this.BadlocationCountRaw.push(x.bad);  
      this.locationHorizontalRaw.push(x.goodLabel);  
    }); 
    this  
    this.barchartRaw = new Chart('goodlocationraw', {  
      type: 'bar',  
      data: {  
        labels: this.locationHorizontalRaw,  
        datasets: [  
          {  
            data: this.GoodlocationCountRaw,
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
            data: this.BadlocationCountRaw,  
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

getDistinctLocation(){
  this._service.getDistictLocation().subscribe(res =>{
    this.listDistinctlocation = res;
  })
}

}

