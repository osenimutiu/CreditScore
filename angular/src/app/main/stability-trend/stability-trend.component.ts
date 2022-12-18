import { Component, Injector, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { CurveServiceProxy, ScoreCardServiceProxy, StabiltyTrendDto, ViewbincountpercentageDto } from '@shared/service-proxies/service-proxies';
import Chart from 'chart.js/auto';
import html2canvas from 'html2canvas'
import jspdf from 'jspdf';
@Component({
  selector: 'app-stability-trend',
  templateUrl: './stability-trend.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class StabilityTrendComponent extends AppComponentBase implements OnInit {
  Sample = [];
  Recent = [];
  RecentThreeMonths = [];
  RecentSixMonths = [];
  Bins = [];
  Percentage = [];
  Binning = [];
  Attribte= [];
  stabilityTrends: StabiltyTrendDto[] = [];
  viewBinCount: ViewbincountpercentageDto[] = [];
  Linechart:any = [];
  LinechartForPercView:any = [];
  stabilityTrendTitle: string = 'Stabilty Trend';
  attrb: string;
  distList:any = [];
  isActive: boolean;
 
  constructor(private injector: Injector,
    private _service: ScoreCardServiceProxy,
    private _curveService: CurveServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { super(injector)}
  ngOnInit(): void {
    // this.getProfitAnalysis();
    this.executeStabilityTrend();
  }
  // getProfitAnalysis(){
  //   this._service.getStabiltyTrend().subscribe(res => {
  //     this.stabilityTrends = res;
  //     this.stabilityTrends.forEach(x => {
  //       this.Sample.push(x.sampleFrequencyPerc);
  //       this.Recent.push(x.recentFrequencyPerc);
  //       this.RecentThreeMonths.push(x.threeMonthFrequencyPerc);
  //       this.RecentSixMonths.push(x.sixMonthFrequencyPerc);
  //       this.Bins.push(x.bins);
  //     });
  //     this
  //     this.Linechart = new Chart('stabilityTrending', {
  //       type: 'line',
  //       data: {
  //         labels: this.Bins,
  //         datasets: [
  //           {
  //           data: this.Sample,  
  //           label: 'Sample',
  //           borderColor: '#4287f5',  
  //           backgroundColor: "#4287f5",
  //           },
  //           {
  //           data: this.Recent,  
  //           label: 'Recent',
  //           borderColor: '#f57542',  
  //           backgroundColor: "#f57542",
  //           },
  //           {
  //           data: this.RecentThreeMonths,  
  //           label: 'Recent-3Months',
  //           borderColor: '#999290',  
  //           backgroundColor: "#999290",
  //           },
  //           {
  //           data: this.RecentSixMonths,  
  //           label: 'Recent-6Months',
  //           borderColor: '#ebe313',  
  //           backgroundColor: "#ebe313",
  //           },
  //         ]
  
  //       },
  //       options: {  
  //         // legend: {  
  //         //   display: true  
  //         // }, 
  //         scales: {  
  //           xAxes: {  
  //             display: true  
  //           },  
  //           yAxes: {  
  //             display: true  
  //           },  
  //         }  
  //       } 
  //     });
  //   });
  // }
  
  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }

  exportExcel() {
    import("xlsx").then(xlsx => {
        const worksheet = xlsx.utils.json_to_sheet(this.stabilityTrends); // Sale Data
        const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
        const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
        this.saveAsExcelFile(excelBuffer, "StabilityTrends");
    });
  }
  
  saveAsExcelFile(buffer: any, fileName: string): void {
    import("file-saver").then(FileSaver => {
      let EXCEL_TYPE =
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8";
      let EXCEL_EXTENSION = ".xlsx";
      const data: Blob = new Blob([buffer], {
        type: EXCEL_TYPE
      });
      FileSaver.saveAs(
        data,
        // fileName + "_export_" + new Date().getTime() + EXCEL_EXTENSION
        fileName + EXCEL_EXTENSION
      );
    });
  }

  // download(){
  //   var element = document.getElementById('stabilityTrendChart')
  //   html2canvas(element).then((canvas)=> {
  //     var imgData = canvas.toDataURL('image/png')
  //     var imgHeight = canvas.height * 308 / canvas.width;
  //     var doc = new jspdf()
  //     doc.addImage(imgData, 0, 0, 208, imgHeight)
  //     doc.save("StabilityTrend.pdf")
  //   })
  // }
  download(){
    var element = document.getElementById('stabilityTrendChart')
    html2canvas(element).then((canvas)=> {
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth / canvas.width;
      var heightLeft = imgHeight;
      const contentDataURL = canvas.toDataURL('image.png')
      let pdf = new jspdf('p', 'mm', 'a4');
      var position = 0;
      pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, imgHeight)
      pdf.save("StabilityTrend.pdf")
    });
  }

  executeStabilityTrend(){
    this._curveService.executeStabilityTrend('Input_Data','credit_exclusion','Good_Bad').subscribe(()=>{
      // this.getPercentageBinCount();
      this.getDistinctAttribute();
    });
  }

 getPercentageBinCount(){
   this.isActive= true
    this._curveService.getViewbincountpercentage(this.attrb).subscribe(res => {
      this.viewBinCount = res;
      this.viewBinCount.forEach(x => {
        this.Percentage.push(x.percentage);
        this.Attribte.push(x.attribute);
        this.Binning.push(x.binning);
      });
      this
      this.Linechart = new Chart('chart', {
        type: 'line',
        data: {
          labels: this.Binning,
          datasets: [
            {
            data: this.Percentage,  
            label: 'Percentage',
            borderColor: '#0479cc',  
            backgroundColor: "#cc2904",
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

  getDistinctAttribute(){
    this._curveService.getDistinctAttributes().subscribe(response => {
      this.distList = response;
    });
  }
  }
  