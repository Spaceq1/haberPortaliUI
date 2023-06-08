import { HotToastService } from '@ngneat/hot-toast';
import { Gorev } from '../../models/Gorev';
import { FbservisService } from './../../services/fbservis.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Modal } from 'bootstrap';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  modal!: Modal;
  modalBaslik: string = "";
  uye = this.fbServis.AktifUyeBilgi;
  constructor(
    public fbServis: FbservisService,
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
