import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { constants } from '../../domain/constants';
import { Payment } from './payment.model';
import { NgForm } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  list: Payment[] = []
  formData: Payment = new Payment()
  isFormSubmitted: boolean = false

  constructor(private http: HttpClient) {

  }

  refreshList() {
    this.http.get(this.getReadAllUrl())
      .subscribe({
        next: res => {
          this.list = res as Payment[]
        },
        error: err => { console.log(err) }
      })
  }

  createPayment() {
    let clone = this.clonePayment(this.formData);
    clone.expirationDate = this.toDateFormat(clone.expirationDate)

    return this.http.post(this.getCreateUrl(), clone)
  }

  updatePayment() {
    let clone = this.clonePayment(this.formData);
    clone.expirationDate = this.toDateFormat(clone.expirationDate)

    return this.http.put(this.getUpdateUrl(clone.id), clone)
  }

  deletePayment(id: number) {
    return this.http.delete(this.getDeleteUrl(id))
  }

  resetForm(form: NgForm): void {
    form.form.reset()
    this.formData = new Payment()
    this.isFormSubmitted = false
  }

  toDateFormat(monthAndYear: string): string {
    let [month, year] = monthAndYear.split('/')

    let fullDateTime: string = `20${year}-${month}-01T12:00:00.0000000`

    return fullDateTime
  }

  clonePayment(payment: Payment): Payment {
    let clone = Object.assign(Object.create(Object.getPrototypeOf(payment)), payment)

    return clone;
  }

  getReadAllUrl(): string {
    let readAllUrl: string = environment.apiBaseUrl + constants.api.payments.readAll

    return readAllUrl
  }

  getCreateUrl(): string {
    let createUrl: string = environment.apiBaseUrl + constants.api.payments.create

    return createUrl
  }

  getUpdateUrl(id: number): string {
    let updateUrl: string = environment.apiBaseUrl + constants.api.payments.update + `/${String(id)}`

    return updateUrl
  }

  getDeleteUrl(id: number): string {
    let deleteUrl: string = environment.apiBaseUrl + constants.api.payments.delete + `/${String(id)}`

    return deleteUrl
  }
}
