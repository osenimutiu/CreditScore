import { Component, OnInit, Injector } from '@angular/core';
import { TenantDashboardServiceProxy } from '@shared/service-proxies/service-proxies';
import { DashboardChartBase } from '../dashboard-chart-base';
import { WidgetComponentBaseComponent } from '../widget-component-base';

class DailySalesLineChart extends DashboardChartBase {

  chartData: any[];
  scheme: any = {
    name: 'green',
    selectable: true,
    group: 'Ordinal',
    domain: [
      '#34bfa3'
    ]
  };

  constructor(private _dashboardService: TenantDashboardServiceProxy) {
    super();
  }

  dirtylocation = ['ogba','lekki','ikeja','ketu','Mushin','Agege','Ajah','ikoyi','Alimosho','ikorodu','Anthony']

  init(data) {
    this.chartData = [];
    for (let i = 0; i < data.length; i++) {
      this.chartData.push({
        name:this.dirtylocation[i],// i + "lag",
        value: data[i]
      });
    
    }
  }
 dirtydata = [ 3,4,9,6,9,9,3,9,3,2]

  reload() {
    this.showLoading();
    this._dashboardService
      .getDailySales()
      .subscribe(result => {
        this.init(this.dirtydata);
        this.hideLoading();
      });
  }
}

@Component({
  selector: 'app-widget-daily-sales',
  templateUrl: './widget-daily-sales.component.html',
  styleUrls: ['./widget-daily-sales.component.css']
})
export class WidgetDailySalesComponent extends WidgetComponentBaseComponent implements OnInit {

  dailySalesLineChart: DailySalesLineChart;

  constructor(injector: Injector,
    private _tenantdashboardService: TenantDashboardServiceProxy) {
    super(injector);
    this.dailySalesLineChart = new DailySalesLineChart(this._tenantdashboardService);
  }

  ngOnInit() {
    this.dailySalesLineChart.chartData;
    this.dailySalesLineChart.reload();
  }
}