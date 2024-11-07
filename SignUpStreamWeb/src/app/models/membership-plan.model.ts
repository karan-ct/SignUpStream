import { MembershipPlanTypes } from '../enums/membership-plan-type.enum';

export class MembershipPlan {
  id!: number;
  price: number = 0;
  membershipPlanType!: MembershipPlanTypes;
  discount!: number;
  active: boolean = true;
}
