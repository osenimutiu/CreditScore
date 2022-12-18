import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CurveServiceProxy, GoodBadDto, GoodBadServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-time-jobbin',
  templateUrl: './time-jobbin.component.html',
  styles: [
  ]
})
export class TimeJobbinComponent implements OnInit {
  p: number = 1;
  saving: boolean = false;
  active: boolean = false;
  time_at_jobbin: string;
  modifiedText: string;
  Linechart:any = []; 
  barchart:any = []; 
  GoodCount = []; 
  BadCount = []; 
  Horizontal = []; 
  listDistincttime_at_jobbin:any=[];
  key: string = '';
  reverse: boolean = false;
  listoutput: TblOutput_TableDto[] = [];
  title: string = 'Good and Bad Counts for Time at Job Bin';
  isActive: boolean = false;
  constructor(
    private _service: CurveServiceProxy,
    private _gbService: GoodBadServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getAll();
    this.getDistincttime_at_jobbin();
  }

  fornullcase(): void{
    let x = this.time_at_jobbin;
    if(x == "All"){
      this.postForAll();
      this.getAll();
    }else{
      this.getcountForChart();
    }
    
  }
  postForAll():void{
    this._service.postForAll().subscribe(() => {
    });
    this.getbarchartForCount();
  }
  getAll(): void{
    this._service.getTblOutput().subscribe((result) => {
      this.listoutput = result;
    });
  }

  onTime_at_jobbinSelected(val:any){
    this.customFunction(val);
    this.Search();
    this.fornullcase();
    // this.getDistinct();
   }

   customFunction(val:any){
    this.modifiedText = val + " selected";
  }

  Search(){
    if(this.time_at_jobbin != ""){
      this.listoutput = this.listoutput.filter(res=>{ 
        return res.time_at_Jobbin.toLocaleLowerCase().match(this.time_at_jobbin.toLocaleLowerCase());
      });
    }else if(this.time_at_jobbin == ""){
      this.ngOnInit();
    } 
  }
public getRowsValueForGood_Bad(flag) {
  if (flag === null) {
    return this.listoutput.length;
  } else {
    return this.listoutput.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

getcountForChart(): void{
    
  this._service.postTime_at_JobbinParam(this.time_at_jobbin).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForCount();
  });
}

getbarchartForCount(): void{
  // this.reload();
  this.isActive = true;
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
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

getDistincttime_at_jobbin(){
  this._service.getDistictTime_at_Jobbin().subscribe(res =>{
    this.listDistincttime_at_jobbin = res;
  })
}

}