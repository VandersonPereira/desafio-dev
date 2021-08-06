import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimentacaoFinanceiraComponent } from './movimentacao-financeira.component';

describe('MovimentacaoFinanceiraComponent', () => {
  let component: MovimentacaoFinanceiraComponent;
  let fixture: ComponentFixture<MovimentacaoFinanceiraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimentacaoFinanceiraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MovimentacaoFinanceiraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
