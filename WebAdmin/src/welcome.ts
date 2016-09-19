import { inject } from 'aurelia-dependency-injection';
import { ValidationRules, ValidationControllerFactory } from 'aurelia-validation';
import { BootstrapFormRenderer } from './resources/validation-render/bootstrap-render';

@inject(ValidationControllerFactory)
export class RegistrationForm {
  firstName: string; lastName: string; email: string; controller = null;

  constructor(controller: ValidationControllerFactory) {
    this.controller = controller.createForCurrentScope();
    this.controller.addRenderer(new BootstrapFormRenderer());
  }
  activate() {
  }
  submit() {
    let errors = this.controller.validate();

  }
  reset() {
    this.firstName = '';
    this.lastName = '';
    this.email = '';
    this.controller.reset();
  }
}

ValidationRules
  .ensure('firstName').required().withMessage('yêu cầu nhập first name')
  .ensure('lastName').required()
  .ensure('email').required().email()
  .on(RegistrationForm);