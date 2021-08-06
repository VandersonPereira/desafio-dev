import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarregarArquivoFormComponent } from './carregar-arquivo-form.component';

describe('CarregarArquivoFormComponent', () => {
  let component: CarregarArquivoFormComponent;
  let fixture: ComponentFixture<CarregarArquivoFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarregarArquivoFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarregarArquivoFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
