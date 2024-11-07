import { Component } from '@angular/core';
import { SignupComponent } from '../../signup/signup.component';
import { SubscriptionComponent } from '../../subscription/subscription.component';
import { AuthService } from '../../../services/auth.service';
import { SubscriptionService } from '../../../services/subscription.service';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonService } from '../../../services/common.service';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [SignupComponent, SubscriptionComponent, HttpClientModule],
  providers: [AuthService, SubscriptionService, CommonService],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {

}
