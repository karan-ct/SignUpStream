import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { MembershipPlan } from '../models/membership-plan.model';
import { PromoCode } from '../models/promo-code.model';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionService {
  apiEndpoint = 'Subscription';
  baseUrl = `${environment.API_URL}/${this.apiEndpoint}`;

  constructor(private httpClient: HttpClient) { }

  // Get Price plans list
  getMembershipPlans(): Observable<MembershipPlan[]> {
    return this.httpClient.get<MembershipPlan[]>(`${this.baseUrl}/plans`);
  }

  // Apply promocode and get discount details
  applyPromoCode(promoCode: string): Observable<PromoCode> {
    return this.httpClient.get<PromoCode>(
      `${this.baseUrl}/applyPromo/${promoCode}`
    );
  }

  // Get Total & Saved Amount
  getUpdatedAmount(
    totalBranch: number,
    selectedPlan: string,
    promoCode: string = ''
  ) {
    return this.httpClient.get<{ total: number; saved: number }>(
      `${this.baseUrl}/getUpdatedAmount/${totalBranch}/${selectedPlan}/${promoCode}`
    );
  }
}
