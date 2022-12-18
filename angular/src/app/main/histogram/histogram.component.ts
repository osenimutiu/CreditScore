import { Component, ElementRef, EventEmitter, Injector, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ComponentListDto, ComponentServiceProxy, CreateHistogramInput, HistogramListDto, HistogramServiceProxy, OperationListDto, OperationServiceProxy, PreProcessingListDto, PreProcessingServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';
import { result } from 'lodash';
import { Color } from 'ng-uikit-pro-standard/lib/free/charts/color.interface';
import { BsModalService, ModalDirective } from 'ngx-bootstrap/modal';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-histogram',
  templateUrl: './histogram.component.html',
  animations: [appModuleAnimation()],
  styleUrls: ['./histogram.component.scss']
})
export class HistogramComponent extends AppComponentBase implements OnInit {

  // chart.js
//  books = [];
books: any[] = [];
valueData: number[] = [];
labelData: any[] = [];

// valueData: number[] = [];
// labelData= [];



training: number;
test: number;




saleData = [
  { name: "lowerbound", value: 105000 },
  { name: "lowerbound1", value: 55000 },
  { name: "lowerbound2", value: 15000 },
  { name: "lowerbound3", value: 150000 },
  { name: "lowerbound4", value: 20000 }
];




hischartData = [];
hischartsData = [];

  p: number = 1;
  histograms: HistogramListDto[] = [];
  components: ComponentListDto[] = [];
  operations: OperationListDto[] = [];
  filter: string = '';
  modifiedText: string;
  preprocessings: PreProcessingListDto[] = [];
  top1Feature = [];
  distinctFeatures = []; 
  combinations = [];
  nu_ll = 0;
  outl_ier = 0;
  Components = '';
  num = 0;

//chart
UserList: any[] = [];
  done: boolean = false;
  view: any[] = [500, 300];

// options
showXAxis = true;
showYAxis = true;
gradient = false;
showLegend = true;
showXAxisLabel = true;
xAxisLabel = 'lowerbound';
showYAxisLabel = true;
yAxisLabel = 'percent';


colorScheme = {
  domain: ['#444b8f', '#1288a4', '#02cc9c', '#aadb6a']
};




  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('nameInput') nameInput: ElementRef;


histogram: CreateHistogramInput = new CreateHistogramInput();
active: boolean = false;
saving: boolean = false;
closeResult = ''; 
id: number;
featurename: string;
editingHistogram: HistogramListDto = null;
  ticks: any;




  constructor(
    injector: Injector,
    private _histogramService: HistogramServiceProxy,
    private _modalService: BsModalService,
    private _componentService: ComponentServiceProxy,
    private route: ActivatedRoute,
    private router: Router,
    private _preProcessingService: PreProcessingServiceProxy,
    private _operationService: OperationServiceProxy
  ) { 
    super(injector);
    this.dataVal();
  }

  // getDataVals(): void{
  //   this._histogramService.getHistogram(this.filter).subscribe((result) =>{
  //     this.histograms = result.items;
  //   });
  // }

  dataVal(): void {
    this._histogramService.getHistogram(this.filter)
      .subscribe((books) => {
         //this.books;
         this.histograms = books.items;
        let i = 0;
        let j = 0;
        for (i = 0; i < this.histograms.length; i++) {
          this.labelData.push(this.histograms[i].lowerBound.toString());
          this.valueData.push(this.histograms[i].percent);
        }
      });
  }
  // dataVal(): void {
  //   this._histogramService.getHistogram(this.filter)
  //     .subscribe((books) => {
  //        //this.books;
  //        this.books = books.items;
  //       let i = 0;
  //       let j = 0;
  //       for (i = 0; i < this.books.length; i++) {
  //         this.labelData.push(this.books[i][j].lowerbound.toString());
  //         this.valueData.push(this.books[i].length);
  //       }
  //     });
  // }

  // getCombinations(): void{
  //   this._histogramService.getCombinations().subscribe((result) =>{
  //     this.combinations = result;
  //   });
  // }

  // "#00FFFF",
  // "#E0FFFF",
  // "#00FFFF",

  datab = {
    labels: [this.labelData],
    datasets: [{
      data: this.valueData,
      backgroundColor: [
        "#ebdb34",
        "#74eb34",
        "#34c3eb",
        "#eb3499",
        "#34d9eb",
        "#080a0a",
        "#0a0808",
        "#ebdb34",
        "#67cf7f", 
        "#34c3eb",
        "#ebdb34",
      ]
    }]
  }

  // displayCharty(): void {

  //   this._histogramService.getHistogram(this.filter).subscribe(users => {
  //     users.arrays(element => {
  //       this.UserList.push({ "name": element.name, "value": element.age });  // can take only x y values
  //     });
  //     this.done = true;
  //     console.log(this.UserList);
  //   })

  // }

  

  ngOnInit(): void {
    // this.dataVal();
    this.getHistograms(); 
    this.getComponents();
    this.getPreProcessings(); 
    this.getOperations();
    this.getDistinctTop1Feature(); 
    this.getDistinctFeatures();
    this.getCombinations();
    this.intializeLookUp2();
    //this.preProcessing();
    this.training = 70;
    this.test = 30;
    
  }

  

  getCombinations(): void{
    this._histogramService.getCombinations().subscribe((result) =>{
      this.combinations = result;
    });
  }

  getDistinctTop1Feature(): void{
    this._histogramService.getDistinctTop1Feature().subscribe((result) =>{
      this.top1Feature = result;
    });
  }

  getDistinctFeatures(): void{
    this._histogramService.getDistinctFeatures().subscribe((result) =>{
      this.distinctFeatures = result;
      console.log(this.distinctFeatures);
    });
  }
  getOperations(): void{
    this._operationService.getOperation(this.filter).subscribe((result) =>{
      this.operations = result.items;
    } ) 
  }
  getPreProcessings(): void{
    this._preProcessingService.getPreProcessing(this.filter).subscribe((result) =>{
      this.preprocessings = result.items;
      //this.preProcessing();
    } ) 
  }
  onFeaturenameSelected(val:any){
    this.customFunction(val);
    this.preProcessing();
    this.Search();
   }

  customFunction(val:any){
    this.modifiedText = val + " selected";
  
  }

  // getHistograms(): void{
  //   this._histogramService.getHistogram(this.filter).subscribe((result) => {
      
  //      this.histograms = result.items;
  //   });
  // }

  getHistograms(): void{
    this._histogramService.getHistogram(this.filter).subscribe((result) => {
      this.histograms = result.items;
      for(var i = 0; i < this.histograms.length; i++){
        this.hischartData = [
          { name: this.histogram.lowerBound, value: this.histogram[0].percent }
        ];
      }
    });
  }

  // Search(){
  //   if(this.featurename != ""){
  //     console.log(this.histogram.percent);
  //     this.histograms = this.histograms.filter(res=>{ 
  //       for(var i = 0; i < this.histograms.length; i++){
  //         this.hischartData = [
  //           { name: res.lowerBound, value: res.percent }
  //         ];
  //       }
  //       return res.featurename.toLocaleLowerCase().match(this.featurename.toLocaleLowerCase());
  //     });
  //   }else if(this.featurename == ""){
  //     this.ngOnInit();
  //   }
  // }

  
  getComponents(): void{
    this._componentService.getComponent(this.filter).subscribe((result) => {
      this.components = result.items;
    });
  }

  data = [
    this.histograms.filter(res=>{
      { res.lowerBound, res.percent }

    })
  ]

  Search(){
    if(this.featurename != ""){
      this.histograms = this.histograms.filter(res=>{ 
        return res.featurename.toLocaleLowerCase().match(this.featurename.toLocaleLowerCase());
      });
    }else if(this.featurename == ""){
      this.ngOnInit();
    }
    
    
  }

  onShown(): void{
    this.saving = true;
    this._histogramService.createHistogram(this.histogram)
    .pipe(finalize(() => this.saving = false))
    .subscribe(() => {
      this.notify.info(this.l('Saved Successfully'));
      this.close();
      this.modalSave.emit(this.histogram);
    });
  }

  close(): void{
    this.modal.hide();
    this.active = false;
  }

  save(): void {
    let input = new CreateHistogramInput();
    this.saving = true;
    this._histogramService.createHistogram(input)
        .pipe(finalize(() => { this.saving = false; }))
        .subscribe(() => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
            this.modalSave.emit(null);
        });
 }

 deleteHistogram(histogram: HistogramListDto): void {
  this.message.confirm(
      '',
      this.l('Are you sure to delete this record?'),
      (isConfirmed) => {
          if (isConfirmed) {
              this._histogramService.deleteHistogram(histogram.id)
                  .subscribe(() => {
                      
                      this.notify.error(this.l('Successfully Deleted'));
                      _.remove(this.histograms, histogram);
                  });
          }
      }
  );
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

apply(): void{
  var rates = (<HTMLInputElement>document.getElementById("myoptions")).value;
  var opt_value;
  if ((<HTMLInputElement>document.getElementById('r1')).checked) 
               {
               opt_value = (<HTMLInputElement>document.getElementById('r1')).value;
           } 
           if ((<HTMLInputElement>document.getElementById('r2')).checked) {
            opt_value = (<HTMLInputElement>document.getElementById('r2')).value;
        } 
        if ((<HTMLInputElement>document.getElementById('r3')).checked) {
            opt_value = (<HTMLInputElement>document.getElementById('r3')).value;
        }
        this._histogramService.updateRecords(opt_value).pipe(finalize(() => this.saving = true))
        .subscribe(() =>{
         this.notify.success(this.l('Update successsfully effected'));
         
        });
}

preProcessing(): void{
  this._preProcessingService.getPreProcessing(this.filter).subscribe((result) => {
    this.preprocessings = result.items;
    this.nu_ll = this.preprocessings[0].num_null;
    this.outl_ier = this.preprocessings[0].outl_ier;
    this.Components = this.preprocessings[0].components;
    this.num = this.preprocessings[0].num;

  });
}

intializeLookUp2(): void{
  this._histogramService.getDistinctTop1Feature().subscribe((result) =>{
    result;
    this.preProcessing();
  })
  
}

xAxisTickFormatting(val: string): void {
  console.log(this.ticks);
  }

  onSelect(event:Event){
    console.log(event)
  }

  updateTest(){
    this.test = 100 - this.training;
  }

  updateTraining(){
    this.training = 100 - this.test;
  }
}






