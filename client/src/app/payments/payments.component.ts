import { Component, OnInit } from '@angular/core';
import { PaymentService } from '../shared/payment.service';
import { Payment } from '../shared/payment.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payments',
  standalone: false,
  templateUrl: './payments.component.html',
  styles: ``
})

export class PaymentsComponent implements OnInit {

  constructor(public paymentService: PaymentService,
    private toastr: ToastrService
  ) {

  }

  ngOnInit(): void {
    this.paymentService.refreshList()
  }

  populatePaymentForm(selectedItem: Payment): void {
    let clone = this.paymentService.clonePayment(selectedItem)
    clone.expirationDate = this.toMonthAndYear(clone.expirationDate)

    this.paymentService.formData = clone
  }

  toMonthAndYear(dateTimeString: string): string {
    let dateTime = dateTimeString.split("T")
    if (!dateTime || dateTime.length == 0) {
      return ''
    }

    let [year, month] = dateTime[0]
      .substring(2, 7)
      .split('-')

    return [month, year].join('/')
  }

  toCardNumberFormat(cardNumber: string): string {
    let len: number = cardNumber.length
    let result: string[] = []

    for (let i = 0; i < len; i++) {
      result.push(cardNumber[i])
      if ((i + 1) % 4 == 0 && i != len - 1) {
        result.push('-')
      }
    }

    return result.join('')
  }

  onDelete(id: number): void {
    if (!confirm('Are you sure you want to delete this record?')) {
      return
    }

    this.paymentService.deletePayment(id)
      .subscribe({
        next: res => {
          this.paymentService.list = res as Payment[]
          this.toastr.error('Deleted Successfully', 'Payments Register')
        },
        error: err => { console.log(err) }
      })
  }
}
