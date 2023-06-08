import { ProfilComponent } from './components/profil/profil.component';
import { SignupComponent } from './components/signup/signup.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { UyelerComponent } from './components/uyeler/uyeler.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {
  canActivate,
  redirectUnauthorizedTo,
  redirectLoggedInTo,
} from '@angular/fire/auth-guard';
import { AppComponent } from './app.component';
import { KategorilerComponent } from './components/kategoriler/kategoriler.component';
import { SporComponent } from './components/kategoriler/spor/spor.component';
import { TeknolojilerComponent } from './components/kategoriler/teknolojiler/teknolojiler.component';
import { GundemComponent } from './components/kategoriler/gundem/gundem.component';
import { SiyasetComponent } from './components/kategoriler/siyaset/siyaset.component';
import { FeaturedComponent } from './components/featured/featured.component';

const redirectToLogin = () => redirectUnauthorizedTo(['login']);
const redirectToHome = () => redirectLoggedInTo(['']);
const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'featured',
    component: FeaturedComponent
  },
  {
    path: 'kategoriler',
    children: [
      {
        path: 'spor',
        component: SporComponent
      },
      {
        path: 'teknoloji',
        component: TeknolojilerComponent
      },
      {
        path: 'gundem',
        component: GundemComponent
      },
      {
        path: 'siyaset',
        component: SiyasetComponent
      }
    ]
  },
  {
    path: 'profil',
    component: ProfilComponent,
    ...canActivate(redirectToLogin),
  },
  {
    path: 'uyeler',
    component: UyelerComponent,
    ...canActivate(redirectToLogin),
  },
  {
    path: 'login',
    component: LoginComponent,
    ...canActivate(redirectToHome),
  },
  {
    path: 'signup',
    component: SignupComponent,
    ...canActivate(redirectToHome),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
