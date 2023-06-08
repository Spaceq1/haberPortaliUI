import { Component } from '@angular/core';
import { Modal } from 'bootstrap';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-siyaset',
  templateUrl: './siyaset.component.html',
  styleUrls: ['./siyaset.component.scss']
})
export class SiyasetComponent {
  modal!: Modal;
  modalBaslik: string = "";
  constructor(
  ) {

  }

  ngOnInit(): void {

  }
  haber1(el: HTMLElement) {
    this.modalBaslik = "Dolar Düştü!";
    this.modal = new bootstrap.Modal(el);
    this.modal.show();
  }
  haber2(el: HTMLElement) {
    this.modalBaslik = "Akdeniz Üniversitesi Seçildi!";
    this.modal = new bootstrap.Modal(el);
    this.modal.show();
  }
  haber3(el: HTMLElement) {
    this.modalBaslik = "Türkiye Birinci Oldu!";
    this.modal = new bootstrap.Modal(el);
    this.modal.show();
  }
}
