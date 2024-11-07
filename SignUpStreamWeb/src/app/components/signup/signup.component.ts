import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { AbstractControl, FormControl, FormGroup, FormsModule, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SubscriptionComponent } from "../subscription/subscription.component";
import { User } from '../../models/user.model';
import { Title } from '@angular/platform-browser';
import { Country } from '../../models/country.model';
import { CommonService } from '../../services/common.service';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule, SubscriptionComponent],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent implements OnInit {
  title = 'Sign Up';
  countries: Country[] = [];
  selectedCountry: Country | null = null;
  user: User = new User();
  passFieldTextType = false;
  confirmPassFieldTextType = false;
  @ViewChild("subscription") subscription!: SubscriptionComponent;
  constructor(public authService: AuthService, private titleService: Title, private commonService: CommonService) {
    this.titleService.setTitle(this.title);
  }

  minPasswordLength = 8;
  signupForm = new FormGroup({
    FirstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    LastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
    Email: new FormControl('', [Validators.required, Validators.email]),
    Password: new FormControl('', [Validators.required, this.passwordValidator()]),
    ConfirmPassword: new FormControl('', [Validators.required, this.passwordValidator()]),
    CountryCode: new FormControl('', [Validators.required]),
    Phone: new FormControl('', [Validators.required, Validators.minLength(10), Validators.pattern(/^(\+\d{1,3}[- ]?)?\d{10}$/)]),
    Gender: new FormControl('', [Validators.required]),
  },
    {
      validators: this.matchValidator('Password', 'ConfirmPassword')
    });
  termsAccepted = false;

  ngOnInit(): void {
    this.loadCountries();
  }

  // On form submit
  onSubmit() {
    if (this.signupForm.valid) {
      let newUser = new User(this.signupForm.value);
      newUser.Subscription = this.user.Subscription;
      this.authService.signUp(newUser).subscribe({
        next: (res: any) => {
          if (res && res.succeeded) {
            this.signupForm.reset();
            alert('Sign Up Successful');
          }
          else if (res.errors && res.errors.length > 0) {
            let errorMessage = 'Error(s) while saving user. Please refer below:\n';
            res.errors.forEach((error: any) => {
              errorMessage += `${error.description}`;
            });
            alert(errorMessage);
          }
          else {
            alert('Something went wrong. Please try again.')
          }
        }, error: (err) => {
          alert('Sign Up Error');
        }
      });
    } else {
      console.log('Form is invalid');
    }
  }

  onCountryChange(event: Event): void {
    const selectedIsoCode = (event.target as HTMLSelectElement).value;
    this.selectedCountry = this.countries.find(country => country.isoCode === selectedIsoCode) || null;

  }

  private matchValidator(controlName: string, matchingControlName: string): ValidatorFn {
    return (abstractControl: AbstractControl) => {
      const control = abstractControl.get(controlName);
      const matchingControl = abstractControl.get(matchingControlName);

      if (matchingControl!.errors && !matchingControl!.errors?.['ConfirmedValidator']) {
        return null;
      }

      if (control!.value !== matchingControl!.value) {
        const error = { confirmedValidator: 'Passwords do not match.' };
        matchingControl!.setErrors(error);
        return error;
      } else {
        matchingControl!.setErrors(null);
        return null;
      }
    }
  }

  private passwordValidator(): ValidatorFn {
    return (abstractControl: AbstractControl) => {
      const control = abstractControl.value;
      let error: any = {};
      if (control != null) {
        let value = control;
        const hasUpperCase = /[A-Z]/.test(value);
        const hasLowerCase = /[a-z]/.test(value);
        const hasNumeric = /[0-9]/.test(value);
        const hasSpecial = /[!@#$%^&*(),.?":{}|<>]/.test(value);
        const hasMinLength = value.length >= this.minPasswordLength;
        if (!hasUpperCase) error['upperCase'] = true;
        if (!hasLowerCase) error['lowerCase'] = true;
        if (!hasNumeric) error['numeric'] = true;
        if (!hasSpecial) error['specialChar'] = true;
        if (!hasMinLength) error['minlength'] = true;
        return error;
      }
      return null;
    }
  }

  private loadCountries(): void {
    this.commonService.getConutriesList().subscribe((data) => {
      this.countries = data;
      this.selectedCountry = this.countries[0]; // Set default country
      this.signupForm.controls.CountryCode.setValue(this.selectedCountry.dialCode);
    })
  }

}

