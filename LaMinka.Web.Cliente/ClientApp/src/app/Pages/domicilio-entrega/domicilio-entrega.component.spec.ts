import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DomicilioEntregaComponent } from './domicilio-entrega.component';

describe('DomicilioEntregaComponent', () => {
  let component: DomicilioEntregaComponent;
  let fixture: ComponentFixture<DomicilioEntregaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DomicilioEntregaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DomicilioEntregaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
