import { AbstractControl, ValidationErrors, ValidatorFn, FormGroup } from '@angular/forms';

/**
 * Password Rules:
 * - Minimum 8 characters
 * - At least 1 lowercase letter
 * - At least 1 uppercase letter
 * - At least 1 special character
 */
export function passwordStrengthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const value = control.value;

    if (!value) {
      return null;
    }

    const hasMinLength = value.length >= 8;
    const hasLowerCase = /[a-z]/.test(value);
    const hasUpperCase = /[A-Z]/.test(value);
    const hasSpecialChar = /[^a-zA-Z0-9]/.test(value);

    const passwordValid = hasMinLength && hasLowerCase && hasUpperCase && hasSpecialChar;

    return !passwordValid
      ? {
          passwordStrength: {
            hasMinLength,
            hasLowerCase,
            hasUpperCase,
            hasSpecialChar,
          },
        }
      : null;
  };
}

/**
 * Confirm Password Validator
 */
export function confirmPasswordValidator(
  passwordControlName: string,
  confirmPasswordControlName: string,
): ValidatorFn {
  return (formGroup: AbstractControl): ValidationErrors | null => {
    const group = formGroup as FormGroup;

    const passwordControl = group.get(passwordControlName);
    const confirmPasswordControl = group.get(confirmPasswordControlName);

    if (!passwordControl || !confirmPasswordControl) {
      return null;
    }

    if (confirmPasswordControl.errors && !confirmPasswordControl.errors['passwordMismatch']) {
      return null;
    }

    if (passwordControl.value !== confirmPasswordControl.value) {
      confirmPasswordControl.setErrors({
        passwordMismatch: true,
      });
    } else {
      confirmPasswordControl.setErrors(null);
    }

    return null;
  };
}
