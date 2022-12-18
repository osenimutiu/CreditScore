import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CurveServiceProxy, GoodBadDto, GoodBadServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-curr-acc-stat',
  templateUrl: './curr-acc-stat.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class CurrAccStatComponent implements OnInit {
  p: number = 1;
  saving: boolean = false;
  active: boolean = false;
  current_Account_Status: string;
  modifiedText: string;
  Linechart:any = [];
  barchart:any = [];
  GoodCount = [];
  BadCount = [];
  Horizontal = [];
  listDistinctcurrent_Account_Status:any=[];
  key: string = '';
  reverse: boolean = false;
  listoutput: TblOutput_TableDto[] = [];
  title: string = 'Good and Bad Counts for Current Account Status';
  isActive: boolean = false;
  constructor(
    private _service: CurveServiceProxy,
    private _gbService: GoodBadServiceProxy,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getAll();
    this.getcurrent_Account_Status();
  }

  fornullcase(): void{
    let x = this.current_Account_Status;
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

  onCurrentAccountStatusSelected(val:any){
    this.customFunction(val);
    this.Search();
    this.fornullcase();
    // this.getcurrent_Account_Status();
   }

   customFunction(val:any){
    this.modifiedText = val + " selected";
  }

  Search(){
    if(this.current_Account_Status != ""){
      this.listoutput = this.listoutput.filter(res=>{
        return res.current_Account_Status.toLocaleLowerCase().match(this.current_Account_Status.toLocaleLowerCase());
      });
    }else if(this.current_Account_Status == ""){
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
  this._service.postCurrAccStatusParam(this.current_Account_Status).pipe(finalize(() => this.saving = false))
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

getcurrent_Account_Status(){
  this._service.getDistictCurrAccStatus().subscribe(res =>{
    this.listDistinctcurrent_Account_Status = res;
  })
}

}
