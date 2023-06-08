import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiyasetComponent } from './siyaset.component';

describe('SiyasetComponent', () => {
  let component: SiyasetComponent;
  let fixture: ComponentFixture<SiyasetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SiyasetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SiyasetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
