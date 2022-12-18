import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { GetLogRegressionForViewDto, LogRegressionServiceProxy } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-logistic-regression-inputs',
  templateUrl: './logistic-regression-inputs.component.html',
  styles: [
  ]
})
export class LogisticRegressionInputsComponent extends AppComponentBase implements OnInit {
  p: number = 1;
  saving: boolean = false;
  active: boolean = false;
  training_Test: string;
  modifiedText: string;
  progressCount:number = 0;
  completedCount:number = 0;
  regressions: GetLogRegressionForViewDto[] = [];
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('locationInput') locationInput: ElementRef;
  constructor(
    injector: Injector,
    private _service: LogRegressionServiceProxy,
  ) { 
    super(injector)
  }

  ngOnInit(): void {
    this.getAll();
    //this.distinctCount();
    this.thirdCount();
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
    // this.distinctCount();
    // this.secondCount();
    this.thirdCount();
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
    console.log(counts);
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
// alert(count);
console.log(count);
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
  } else {
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

}
