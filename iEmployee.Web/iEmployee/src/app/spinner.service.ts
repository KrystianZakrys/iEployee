import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {
  loadingSub: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  loadingMap: Map<string,boolean> = new Map<string,boolean>();

  
  /**
   * Creates an instance of spinner service.
   */
  constructor() { }

 
  /**
   * Sets loading
   * @param loading 
   * @param url 
   */
  setLoading(loading: boolean, url: string): void{
    if(!url)
    {
      throw new Error('The request URL must be provided to the SpinnerService.setLoading()');
    }

    if(loading === true)
    {
      this.loadingMap.set(url,loading);
      this.loadingSub.next(true);
    }
    else if(loading === false && this.loadingMap.has(url))
    { 
      this.loadingMap.delete(url);
    }
    
    if(this.loadingMap.size === 0){
      this.loadingSub.next(false);
    }
  }
  
}
