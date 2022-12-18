import { Component, OnInit, Injector } from '@angular/core';
import { DashboardChartBase } from '../dashboard-chart-base';
import { TenantDashboardServiceProxy } from '@shared/service-proxies/service-proxies';
import { WidgetComponentBaseComponent } from '../widget-component-base';

class GeneralStatsPieChart extends DashboardChartBase {

  public data = [];

  constructor(private _dashboardService: TenantDashboardServiceProxy) {
    super();
  }

  init(approvedPercent, reviewPercent, rejectPercent) {
    this.data = [
      {
        'name': 'Approved',
        'value': approvedPercent
      }, {
        'name': 'Awaiting Review',
        'value': reviewPercent
      }, {
        'name': 'Rejected',
        'value': rejectPercent
      }];

    this.hideLoading();
  }

  reload() {
    this.showLoading();
    this._dashboardService
      .getGeneralStats()
      .subscribe(result => {
        this.init(674, 179, 200);
      });
  }
}
@Component({
  selector: 'app-widget-general-stats',
  templateUrl: './widget-general-stats.component.html',
  styleUrls: ['./widget-general-stats.component.css']
})
export class WidgetGeneralStatsComponent extends WidgetComponentBaseComponent implements OnInit {

  generalStatsPieChart: GeneralStatsPieChart;
  constructor(injector: Injector,
    private _dashboardService: TenantDashboardServiceProxy) {
    super(injector);
    this.generalStatsPieChart = new GeneralStatsPieChart(this._dashboardService);
  }

  ngOnInit() {
    this.generalStatsPieChart.reload();
  }
}