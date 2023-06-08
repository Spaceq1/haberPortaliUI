import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeknolojilerComponent } from './teknolojiler.component';

describe('TeknolojilerComponent', () => {
  let component: TeknolojilerComponent;
  let fixture: ComponentFixture<TeknolojilerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeknolojilerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeknolojilerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
