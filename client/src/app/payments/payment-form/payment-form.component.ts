import { Component } from '@angular/core';
import { PaymentService } from '../../shared/payment.service';
import { NgForm } from '@angular/forms';
import { Payment } from '../../shared/payment.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-form',
  standalone: false,
  templateUrl: './payment-form.component.html',
  styles: ``
})
export class PaymentFormComponent {

  constructor(public paymentService: PaymentService,
    private toastr: ToastrService
  ) {

  }

  onSubmit(form: NgForm) {
    this.paymentService.isFormSubmitted = true

    if (!form.valid) {
      return
    }

    if (this.isNewForm()) {
      this.sendCreatePayment(form)
    } else {
      this.sendUpdatePayment(form)
    }
  }

  sendCreatePayment(form: NgForm) {
    this.paymentService.createPayment()
      .subscribe({
        next: res => {
          this.paymentService.list = res as Payment[]
          this.paymentService.resetForm(form)
          this.toastr.success('Inserted successfully', 'Payments Register')
        },
        error: err => { console.log(err) }
      })
  }

  sendUpdatePayment(form: NgForm) {
    this.paymentService.updatePayment()
      .subscribe({
        next: res => {
          this.paymentService.list = res as Payment[]
          this.paymentService.resetForm(form)
          this.toastr.success('Updated successfully', 'Payments Register')
        },
        error: err => { console.log(err) }
      })
  }

  isNewForm = () => this.paymentService.formData.id == 0
}
