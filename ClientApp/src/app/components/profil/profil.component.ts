import { Uye } from './../../models/Uye';
import { HotToastService } from '@ngneat/hot-toast';
import { FormGroup, FormControl } from '@angular/forms';
import { FbservisService } from 'src/app/services/fbservis.service';
import { Component, NgModule, OnInit } from '@angular/core';
import { concatMap } from 'rxjs';
import { switchMap } from 'rxjs';
import * as bootstrap from 'bootstrap';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {
  modal!: Modal;
  modalBaslik: string = "";
  uye = this.fbServis.AktifUyeBilgi;
  frm: FormGroup = new FormGroup({
    uid: new FormControl(),
    email: new FormControl(),
    displayName: new FormControl(),
    tel: new FormControl(),
    adres: new FormControl(),
    admin: new FormControl(),
    spor: new FormControl(),
    tek: new FormControl(),
    gundem: new FormControl(),
  });
  constructor(
    public fbServis: FbservisService,
    public htoast: HotToastService

  ) { }

  ngOnInit() {
    this.fbServis.AktifUyeBilgi
      .subscribe((user) => {
        this.frm.patchValue({ ...user });
      });
  }
  Kaydet() {
    this.fbServis
      .UyeDuzenle(this.frm.value)
      .pipe(
        this.htoast.observe({
          loading: 'Güncelleniyor',
          success: 'Güncellendi',
          error: 'Hata Oluştu',
        })
      )
      .subscribe();
  }
  ResimYukle(event: any, user: Uye) {
    this.fbServis
      .uploadImage(event.target.files[0], `images/profile/${user.uid}`)
      .pipe(
        this.htoast.observe({
          loading: 'Fotoğraf Yükleniyor...',
          success: 'Fotoğraf yüklendi',
          error: 'Hata oluştu',
        }),
        concatMap((foto) =>
          this.fbServis.UyeDuzenle({ uid: user.uid, foto })
        )
      )
      .subscribe();
  }


  UyeEkleDuzenle() {
    var uye: Uye = this.frm.value
    if (!uye.uid) {

      this.fbServis.KayitOl(this.frm.value.email, this.frm.value.parola).pipe(
        switchMap(({ user: { uid } }) =>
          this.fbServis.UyeEkle({
            uid,
            displayName: this.frm.value.displayName,
            // parola: this.frm.value.parola,
            tel: this.frm.value.tel,
            email: this.frm.value.email,
            admin: this.frm.value.admin,
          })
        ),
        this.htoast.observe({
          loading: 'Üye Ekleniyor',
          success: 'Üye Eklendi',
          error: ({ message }) => `Hata : ${message}`,
        })
      ).subscribe();
      this.modal.toggle();
    } else {
      this.fbServis.UyeDuzenle(uye).pipe(
        this.htoast.observe({
          loading: "Üye Güncelleniyor",
          success: "Üye Güncellendi",
          error: ({ message }) => `Hata : ${message}`
        })
      ).subscribe();
      this.modal.toggle();
    }
  }

  Duzenle(user: Uye, el: HTMLElement) {
    this.frm.patchValue(user);
    this.modalBaslik = "Kategorileri Düzenle";
    this.modal = new bootstrap.Modal(el);
    this.modal.show();
  }
}


