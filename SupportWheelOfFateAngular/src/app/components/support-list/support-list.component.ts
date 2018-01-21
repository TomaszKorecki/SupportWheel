import { Component, Input } from '@angular/core';
import { SupportListGeneratorService } from '../../services/support-list-generator.service';
import { SupportDay } from '../../models/support-day.model';

@Component({
  selector: 'app-support-list',
  templateUrl: './support-list.component.html',
  styleUrls: ['./support-list.component.scss']
})
export class SupportListComponent  {
  @Input()
  public supportDays: SupportDay[] = [];

}
