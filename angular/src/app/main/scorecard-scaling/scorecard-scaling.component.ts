import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ScoreCardScalingDto, ScoreCardServiceProxy } from '@shared/service-proxies/service-proxies';
import { Paginator } from 'primeng/paginator';
import { LazyLoadEvent } from 'primeng/public_api';
import { Table } from 'primeng/table';
import html2canvas from 'html2canvas'
import jspdf from 'jspdf';

@Component({
  selector: 'app-scorecard-scaling',
  templateUrl: './scorecard-scaling.component.html',
  animations: [appModuleAnimation()],
  styles: [
  ]
})
export class ScorecardScalingComponent extends AppComponentBase implements OnInit {
  @ViewChild('dataTable', { static: true }) dataTable: Table;
  @ViewChild('paginator', { static: true }) paginator: Paginator;
  result:any=[];
  listScaling: ScoreCardScalingDto[] = [];
  p:number = 1;
    constructor(private injector: Injector,
       private _service: ScoreCardServiceProxy,
       private route: ActivatedRoute,
      private router: Router)
     {
       super(injector)
      }
  
    ngOnInit(): void {
      this.getScorecardScaling();
    }
    getScoreCardScaling(event?: LazyLoadEvent): void{
      if (this.primengTableHelper.shouldResetPaging(event)) {
        this.paginator.changePage(0);
        return;
    }
  
    this.primengTableHelper.showLoadingIndicator();
      this._service.getScoreCardScaling(
         
         ) .subscribe((result) => {
          this.primengTableHelper.records = result;
          this.result.push(this.primengTableHelper.records);
          this.primengTableHelper.hideLoadingIndicator();
        });
    }
    
    reload() {
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.router.onSameUrlNavigation = 'reload';
      this.router.navigate(['./'], { relativeTo: this.route });
    }

    getScorecardScaling(){
      this._service.getScoreCardScaling().subscribe(res => {
        this.listScaling = res;
      });
    }

    download(){
    var element = document.getElementById('scorecard-scaling')
    html2canvas(element).then((canvas)=> {
      var imgData = canvas.toDataURL('image/png')
      var imgHeight = canvas.height * 208 / canvas.width;
      var doc = new jspdf()
      doc.addImage(imgData, 0, 0, 208, imgHeight)
      doc.save("scorecardScaling.pdf")
    })
  }
  }
  