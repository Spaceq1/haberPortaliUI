import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SporComponent } from './spor.component';

describe('SporComponent', () => {
  let component: SporComponent;
  let fixture: ComponentFixture<SporComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SporComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SporComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
