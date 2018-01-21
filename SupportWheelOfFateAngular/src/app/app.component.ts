import { Component, OnInit } from '@angular/core';
import { SupportListGeneratorService } from './services/support-list-generator.service';
import { SupportDay } from './models/support-day.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  public supportDays: SupportDay[] = [];

  constructor(private supportListGeneratorService: SupportListGeneratorService) {



  }

  ngOnInit() {
    this.supportListGeneratorService.getSupportList().subscribe(supportDays => {
      this.supportDays = supportDays;
    });
  }

  onReload() {
    this.supportListGeneratorService.reloadSupportList().subscribe(supportDays => {
      this.supportDays = supportDays;
    });
  }
}
