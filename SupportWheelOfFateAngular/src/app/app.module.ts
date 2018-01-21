import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { SupportListComponent } from './components/support-list/support-list.component';
import { SupportListGeneratorService } from './services/support-list-generator.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    SupportListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    SupportListGeneratorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
