import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MembershipPlanTypes } from '../../enums/membership-plan-type.enum';
import { Subscription } from '../../models/subscription.model';
import { CommonModule } from '@angular/common';
import { SubscriptionService } from '../../services/subscription.service';
import { MembershipPlan } from '../../models/membership-plan.model';

@Component({
  selector: 'app-subscription',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './subscription.component.html',
  styleUrl: './subscription.component.scss',
})
export class SubscriptionComponent implements OnInit {
  @Input() subscription!: Subscription;
  @Output() subscriptionChange = new EventEmitter<Subscription>();
  membershipPlanTypes = MembershipPlanTypes;
  membershipPlans: MembershipPlan[] = [];
  promoCodeDiscount: number = 0;
  totalAmount: number = 0;
  savedAmount: number = 0;
  promoCode: string = '';

  constructor(private subscriptionService: SubscriptionService) { }

  ngOnInit(): void {
    this.getMembershipPlans();
  }

  getMembershipPlans() {
    this.subscriptionService.getMembershipPlans().subscribe((res) => {
      if (res) {
        this.membershipPlans = res;
        this.subscription.PricePlanId = res[1].id?.toString();
        this.onMembershipPlanChange(this.subscription.PricePlanId);
      }
    });
  }

  onMembershipPlanChange(plnaId: any) {
    this.subscription.PricePlanId = plnaId;
    this.subscription.PromoCodeId = null;
    this.promoCodeDiscount = 0;
    this.updateTotalAndSavedAmount();
    this.subscriptionChange.emit(this.subscription);
  }

  onChangeBranch() {
    this.subscriptionChange.emit(this.subscription);
    this.updateTotalAndSavedAmount();
  }

  applyCoupon() {
    this.subscriptionService.applyPromoCode(this.promoCode).subscribe({
      next: (res: any) => {
        if (res) {
          this.promoCodeDiscount = res.discount;
          this.subscription.PromoCodeId = res.id;
          this.updateTotalAndSavedAmount();
          this.subscriptionChange.emit(this.subscription);
        } else {
          alert('Invalid coupon')
        }

      },
      error: (err) => {
        alert('Invalid coupon');
      },
    });
  }

  updateTotalAndSavedAmount() {
    if (!this.subscription.PricePlanId || !this.subscription.TotalBranch || !this.promoCode)
      return;

    this.subscriptionService
      .getUpdatedAmount(
        this.subscription.TotalBranch,
        this.subscription.PricePlanId,
        this.promoCode
      )
      .subscribe({
        next: (res) => {
          this.subscription.TotalAmount = res.total;
          this.totalAmount = res.total;
          this.savedAmount = res.saved;
          this.subscriptionChange.emit(this.subscription);
        },
        error: (err) => { },
      });
  }

  getDiscountedAmount(plan: MembershipPlan) {
    let discountedPrice = plan.price - (plan.price * plan.discount) / 100;
    return discountedPrice
  }
}
