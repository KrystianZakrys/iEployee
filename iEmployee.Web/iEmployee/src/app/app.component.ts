import { Component, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { SpinnerService } from './spinner.service';
import { ToasterService } from 'angular2-toaster';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'iEmployee';
  loading: boolean = false;

  /**
   * Creates an instance of app component.
   * @param spinner 
   */
  constructor(private spinnerService: SpinnerService, private toasterService: ToasterService){}

  ngOnInit(): void {
    this.listenToLoading();
  }
 
  /**
   * Listens to loading
   */
  listenToLoading(): void{
    this.spinnerService.loadingSub
    .pipe(delay(0))
    .subscribe((loading)=> {
      this.loading = loading;
    });
  }

  /**
   * Shows toaster
   */
  showToaster(){
    this.toasterService.pop('success','Tak','Arrgs');
  }
}
