import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CalibrationCDto, GiniInclusiveServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-caliberation',
  templateUrl: './caliberation.component.html',
  animations: [appModuleAnimation()],
  // styleUrls: ['./caliberation.css']
  styles: [
  ]
})
export class CaliberationComponent implements OnInit {
  caliberations: CalibrationCDto[] = [];
  p:number = 1;
 
  constructor(private _service: GiniInclusiveServiceProxy,
    private route: ActivatedRoute,
    private router: Router) { }
  ngOnInit(): void {
    this.getCaliberation();
  }
  getCaliberation(){
    this._service.getCalibrations().subscribe(res => {
       this.caliberations = res;
    });
  }

  reload() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.router.onSameUrlNavigation = 'reload';
    this.router.navigate(['./'], { relativeTo: this.route });
  }
}
