import { Component } from '@angular/core';
import { Modal } from 'bootstrap';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-teknolojiler',
  templateUrl: './teknolojiler.component.html',
  styleUrls: ['./teknolojiler.component.scss']
})
export class TeknolojilerComponent {
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
