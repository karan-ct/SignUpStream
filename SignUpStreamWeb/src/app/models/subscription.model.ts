import { MembershipPlanTypes } from '../enums/membership-plan-type.enum';

export class Subscription {
  Id!: number;
  PricePlanId!: string;
  TotalAmount: number = 0;
  TotalBranch: number = 1;
  PromoCodeId!: number | null;

  constructor() {
    this.TotalBranch = 1;
  }
}
