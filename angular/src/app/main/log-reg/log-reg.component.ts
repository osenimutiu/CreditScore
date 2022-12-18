import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AppComponentBase } from '@shared/common/app-component-base';
import { GetLogRegressionForViewDto, GoodBadDto, GoodBadServiceProxy, LogRegressionServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';
import Chart from 'chart.js/auto';
// import { Chart } from 'chart.js';

@Component({
  selector: 'app-log-reg',
  templateUrl: './log-reg.component.html',
  styles: [
  ]
})
export class LogRegComponent extends AppComponentBase implements OnInit {
  p: number = 1;
  saving: boolean = false;
  active: boolean = false;
  training_Test: string;
  modifiedText: string;
  progressCount:number = 0;
  completedCount:number = 0;

  key: string = '';
  reverse: boolean = false;
  regressions: GetLogRegressionForViewDto[] = [];
  isActive:boolean = false;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('locationInput') locationInput: ElementRef;

  Training_Test = [];  
  Return_on_Asset = [];  
  Linechart:any = []; 
  barchart:any = []; 
  GoodCount = []; 
  BadCount = []; 
  Horizontal = []; 

  foreighty: any;
  fortwenty: any;


  constructor(
    injector: Injector,
    private _service: LogRegressionServiceProxy,
    private _gbService: GoodBadServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this.getAll();
    //this.distinctCount();
    this.thirdCount();
  }

  getAllWRStProErr(): void{
    let x = this.training_Test;
    if(x == ""){
      this.postForAllRegression();
      this.getAll();
    }else{
      this.getcountForChart();
    }
    // if(x == ""){
    //   alert('empty');
    // }else{
    //   alert(' not empty');
    // }
  }

  postForAllRegression(){
    this._service.postForAllRegression().subscribe(()=>{
    });
    this.getbarchartForCount();
  }


  

  getAll(): void{
    this._service.getAll().subscribe((result) => {
      this.regressions = result;
    });
  }

  onTraining_TestSelected(val:any){
    this.customFunction(val);
    //this.preProcessing();
    this.Search();
    //this.getcountForChart();
    this.getAllWRStProErr();
    // this.thirdCount();
    // this.getAllForChart();
    // this.getbarchart();
    
   
    // let flag = 80;
    // let flagb = 20;
    // this.foreighty = this.getRowsValue(flag);
    // this.fortwenty = this.getRowsValue(flagb);
   }

  customFunction(val:any){
    this.modifiedText = val + " selected";

  
  }

  Search(){
    if(this.training_Test != ""){
      this.regressions = this.regressions.filter(res=>{ 
        return res.training_Test.toLocaleLowerCase().match(this.training_Test.toLocaleLowerCase());
      });
    }else if(this.training_Test == ""){
      this.ngOnInit();
    } 
  }
 distinctCount(): void{
  var counts = {};
for (var i = 0; i < this.regressions.length; i++) {
    counts[this.regressions[i].total_assets_bin] = 1 + (counts[this.regressions[i].return_on_Assets_bin] || 0);
    
}
}

secondCount(): void{
  //arr = ["jam", "beef", "cream", "jam"]
  this.regressions.sort();
var count = 1;
var results = "";
for (var i = 0; i < this.regressions.length; i++)
{
    if (this.regressions[i] == this.regressions[i+1])
    {
      count +=1;
    }
    else
    {
        results += this.regressions[i].return_on_Assets_bin + " --> " + count + " times\n" ;
        count=1;
    }
}
}

thirdCount(): void{
  this.regressions.forEach(item => {
    if (item.return_on_Assets_bin > 20) {
      this.progressCount ++;
    } else {
      this.completedCount ++;
    }
  });
}

public getRowsValue(flag) {
  if (flag === null) {
    return this.regressions.length;
  }
  else {
    return this.regressions.filter(i => (i.return_on_Assets_bin == flag)).length;
    
  }
}
public getRowsValueForGood_Bad(flag) {
  if (flag === null) {
    return this.regressions.length;
  } else {
    return this.regressions.filter(i => (i.good_Bad == flag)).length;
  }
}

getAllForChart(): void{
    
  this._service.getRegressionBySearch(this.training_Test).subscribe((result: GetLogRegressionForViewDto[]) => {  
    this.regressions = result;
   result.forEach(x => {  
     this.Training_Test.push(x.training_Test);  
     this.Return_on_Asset.push(x.return_on_Assets_bin);  
   });  
   this  
   this.Linechart = new Chart('canvas', {  
     type: 'line',  
     data: {  
       labels: this.Training_Test,  

       datasets: [  
         {  
           data: this.Return_on_Asset,  
           borderColor: '#3cb371',  
           backgroundColor: "#0000FF",  
         }  
       ]  
     },  
     options: {  
      //  legend: {  
      //    display: true  
      //  },  
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

  getbarchart(): void{
    this._service.getRegressionBySearch(this.training_Test).subscribe((result: GetLogRegressionForViewDto[]) => {  
      result.forEach(x => {  
        this.Training_Test.push(x.training_Test);  
        this.Return_on_Asset.push(x.return_on_Assets_bin);  
      }); 
    //   this.ft = this.getRowsValueForGood_Bad(true);
    //  this.kt = this.getRowsValueForGood_Bad(false); 
      this  
      this.barchart = new Chart('canvasb', {  
        type: 'bar',  
        data: {  
          labels: this.Training_Test,  
          datasets: [  
            {  
              data: this.Return_on_Asset,  
              borderColor: '#3cba9f',  
              backgroundColor: [  
                "#3cb371",  
                "#0000FF",  
                "#9966FF",  
                "#4C4CFF"  
                // "#00FFFF",  
                // "#f990a7",  
                // "#aad2ed",  
                // "#FF00FF",  
                // "Blue",  
                // "Red",  
                // "Blue"  
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

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  labels: String[] = ['Good', 'Bad'];
  dataSet1: GetLogRegressionForViewDto[] = [];
  dataSet2: GetLogRegressionForViewDto[] = [];
  st: number;
  bt: number;
  ft: number;
  kt: number;
  Good:any= [];
  Bad: [];
  
  // return this.regressions.filter(i => (i.good_Bad == flag)).length;
  // result.forEach(x => {  
  //   this.Training_Test.push(x.training_Test);  
  //   this.Return_on_Asset.push(x.return_on_Assets_bin);  
  // });  
  createChart() {
    var countgb = 0;
    this.dataSet1.forEach(item => {
      this.Good.push(item.good_Bad);
      countgb= countgb + 1;
    });
    for(var t = 1; t <= this.dataSet2.length; t++){
    return this.dataSet2.filter(i => (i.good_Bad == false)).length;
    }
    this.ft = this.getRowsValueForGood_Bad(true);
    this.kt = this.getRowsValueForGood_Bad(false);
    // this.Good.push(this.ft);
    var chartInstance = new Chart('chartJSContainer', {
     
      type: 'bar',
      data: {
        labels: this.labels,
        datasets: [
          {
            
            data: this.ft,
            label: 'Good',
            backgroundColor: '#fa9cb0'
          },
          {
            data: this.kt,
            label: 'Bad',
            backgroundColor: '#7b8dfd'
          }
        ]
      },
      options: {
        indexAxis: 'y',
        scales: {
          x: {
            stacked: true
          },
          y: {
            stacked: true
          }
        }
      }
    });
    console.log(this.ft);
    console.log(this.kt);
    // alert(this.ft);
  }

  getcountForChart(): void{
    
    this._gbService.getTrain_TestParam(this.training_Test).pipe(finalize(() => this.saving = false))
    .subscribe(() =>{
     this.notify.success(this.l(''));
     this.getbarchartForCount();
    });
  }

  getbarchartForCount(): void{
    // this.reload();
    this.isActive = true;
    this._gbService.getGoodBadData().subscribe((result: GoodBadDto[]) => {  
      result.forEach(x => {  
        this.GoodCount.push(x.good);  
        this.BadCount.push(x.bad);  
        this.Horizontal.push(x.goodLabel);  
      }); 
      this  
      this.barchart = new Chart('canvasc', {  
        type: 'bar',  
        data: {  
          labels: this.Horizontal,  
          datasets: [  
            {  
              data: this.GoodCount,
              label: 'Good',  
              borderColor: '#3cba9f',  
              backgroundColor: [  
                "#3cb371",  
                "#0000FF",  
                "#9966FF",  
                "#4C4CFF"  
                // "#00FFFF",  
                // "#f990a7",  
                // "#aad2ed",  
                // "#FF00FF",  
                // "Blue",  
                // "Red",  
                // "Blue"  
              ],  
              // fill: true 
            },
            {  
              data: this.BadCount,  
              label: 'Bad',
              borderColor: '#3cba9f',  
              backgroundColor: [  
                "#eb4034",  
                "#eb4034",  
                "##eb4034",  
                "##eb4034"  
                // "#00FFFF",  
                // "#f990a7",  
                // "#aad2ed",  
                // "#FF00FF",  
                // "Blue",  
                // "Red",  
                // "Blue"  
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

  sort(key){
    this.key = key;
    this.reverse = !this.reverse;
  }
}
