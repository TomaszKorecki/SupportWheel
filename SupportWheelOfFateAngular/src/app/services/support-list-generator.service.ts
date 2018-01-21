import { Injectable } from '@angular/core';
import { SupportDay } from '../models/support-day.model';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';

import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable()
export class SupportListGeneratorService {

  constructor(private http: HttpClient) { }

  private supportListEndpointPrefix = 'supportList';
  private supportListReloadEndpointPrefix = '/new';

  public getSupportList(): Observable<SupportDay[]> {
    return this.http.get<SupportDay[]>(environment.apiUrl + this.supportListEndpointPrefix);
  }

  public reloadSupportList() {
    return this.http.get<SupportDay[]>(environment.apiUrl + this.supportListEndpointPrefix + this.supportListReloadEndpointPrefix, {});
  }
}
