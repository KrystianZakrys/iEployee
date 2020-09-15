import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { HttpRequestInterceptor } from './http-request.interceptor';

import { EmployeeModule } from './employee/employee.module';
import { ProjectModule } from './project/project.module';
import { MessagesModule } from './messages/messages.module';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { ToasterModule} from 'angular2-toaster';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    EmployeeModule,
    ProjectModule,
    MessagesModule,
    MatProgressSpinnerModule,
    ToasterModule.forRoot()
  ],
  providers: [HttpClientModule,
    {
       provide: HTTP_INTERCEPTORS,
       useClass: HttpRequestInterceptor,
       multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
