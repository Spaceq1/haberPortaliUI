import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GundemComponent } from './gundem.component';

describe('GundemComponent', () => {
  let component: GundemComponent;
  let fixture: ComponentFixture<GundemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GundemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GundemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
