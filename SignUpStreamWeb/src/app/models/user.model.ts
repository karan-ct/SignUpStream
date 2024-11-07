import { Subscription } from "./subscription.model";

export class User {
    Id!: string;
    FirstName!: string | null;
    LastName!: string | null;
    Password!: string | null;
    Phone!: string | null;
    CountryCode!: string | null;
    Gender!: string | null;
    Subscription: Subscription = new Subscription();

    constructor(init?: Partial<User>) {
        Object.assign(this, init);
    }
}