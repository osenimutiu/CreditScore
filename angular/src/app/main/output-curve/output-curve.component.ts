import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CurveServiceProxy, TblOutput_TableDto, Tbl_GoodBadInputDto, Tbl_GoodBadInputRawDto, Tbl_ScoringData, Tbl_ScoringDataAppSeriviceServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import Chart from 'chart.js/auto';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';



@Component({
  selector: 'app-output-curve',
  templateUrl: './output-curve.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class OutputCurveComponent extends AppComponentBase implements OnInit {
  product: string;
  saving: boolean = false;
  isActive: boolean = false;
  modifiedText: string;
  Linechart:any = []; 
  barchart:any = []; 
  barchartRaw:any = []; 
  GoodProductCount = []; 
  GoodProductCountRaw = []; 
  BadProductCount = []; 
  BadProductCountRaw = []; 
  ProductHorizontal = []; 
  ProductHorizontalRaw = []; 
  listDistinctProduct:any=[];
  listoutputProducts: TblOutput_TableDto[] = [];
  listoutputProductsRaw: Tbl_ScoringData[] = [];
  productTitle: string;
  productTitleRaw: string;
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
    this.getAllForProduct();
    this.getAllForProductRaw();
    this.getDistinctProduct();
  }
  
  fornullProduct(): void{
    let x = this.product;
    if(x == "All"){
      this.postForAllProduct();
      this.getAllForProduct();
    }else{
      this.getcountForProductChart();
    }
}
  fornullProductRaw(): void{
    let x = this.product;
    if(x == "All"){
      this.postForAllProductRaw();
      this.getAllForProductRaw();
    }else{
      this.getcountForProductChartRaw();
    }
}

postForAllProduct():void{
  this._service.postForAll().subscribe(() => {
  });
  this.getbarchartForProductCount();
}
postForAllProductRaw():void{
  this._service.postForAllRaw().subscribe(() => {
  });
  this.getbarchartForProductCountRaw();
}

getAllForProduct(): void{
  this._service.getTblOutput().subscribe((result) => {
    this.listoutputProducts = result;
  });
}
getAllForProductRaw(): void{
  this._inputData.getInputDataForCount().subscribe((result) => {
    this.listoutputProductsRaw = result;
  });
}

onProductSelected(val:any){
  //this.reload();
  this.customProductFunction(val);
  this.SearchProduct();
  this.SearchProductRaw();
  this.fornullProduct();
  this.fornullProductRaw();
 }
 customProductFunction(val:any){
  this.modifiedText = val + " selected";
}

 
SearchProduct(){
  if(this.product != ""){
    this.listoutputProducts = this.listoutputProducts.filter(res=>{ 
      return res.product.toLocaleLowerCase().match(this.product.toLocaleLowerCase());
    });
  }else if(this.product == ""){
    this.ngOnInit();
  } 
}

SearchProductRaw(){
  if(this.product != ""){
    this.listoutputProductsRaw = this.listoutputProductsRaw.filter(res=>{ 
      return res.product.toLocaleLowerCase().match(this.product.toLocaleLowerCase());
    });
  }else if(this.product == ""){
    this.ngOnInit();
  } 
}

public getRowsValueForGood_BadProduct(flag) {
  if (flag === null) {
    return this.listoutputProducts.length;
  } else {
    return this.listoutputProducts.filter(i => (i.good_Bad == flag)).length;
  }
}
public getRowsValueForGood_BadProductRaw(flag) {
  if (flag === null) {
    return this.listoutputProductsRaw.length;
  } else {
    return this.listoutputProductsRaw.filter(i => (i.good_Bad == flag)).length;
  }
}

reload() {
  this.router.routeReuseStrategy.shouldReuseRoute = () => false;
  this.router.onSameUrlNavigation = 'reload';
  this.router.navigate(['./'], { relativeTo: this.route });
}

getcountForProductChart(): void{
  this._service.postProductParam(this.product).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForProductCount();
  });
}
getcountForProductChartRaw(): void{
  this._service.postProductParamRaw(this.product).pipe(finalize(() => this.saving = false))
  .subscribe(() =>{
   this.getbarchartForProductCountRaw();
  });
}


getbarchartForProductCount(): void{
  //this.reload();
  this.isActive = true;
  this.productTitle = "Cleansed"
  this._service.getTbl_GoodBadInputData().subscribe((result: Tbl_GoodBadInputDto[]) => {  
   result.forEach(x => {  
      this.GoodProductCount.push(x.good);  
      this.BadProductCount.push(x.bad);  
      this.ProductHorizontal.push(x.goodLabel);  
    }); 
    this  
    this.barchart = new Chart('goodProduct', {  
      type: 'bar',  
      data: {  
        labels: this.ProductHorizontal,  
        datasets: [  
          {  
            data: this.GoodProductCount,
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
            data: this.BadProductCount,  
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

getbarchartForProductCountRaw(): void{
  // this.reload();
  this.isActive = true;
  this.productTitleRaw = "Uncleanse"
  this._service.getGoodBadInputRaw().subscribe((result: Tbl_GoodBadInputRawDto[]) => {  
   result.forEach(x => {  
      this.GoodProductCountRaw.push(x.good);  
      this.BadProductCountRaw.push(x.bad);  
      this.ProductHorizontalRaw.push(x.goodLabel);  
    }); 
    this  
    this.barchartRaw = new Chart('goodProductraw', {  
      type: 'bar',  
      data: {  
        labels: this.ProductHorizontalRaw,  
        datasets: [  
          {  
            data: this.GoodProductCountRaw,
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
            data: this.BadProductCountRaw,  
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

getDistinctProduct(){
  this._service.getDistictProduct().subscribe(res =>{
    this.listDistinctProduct = res;
  })
}

}
