import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-movimentacao-financeira',
  templateUrl: './movimentacao-financeira.component.html',
  styleUrls: ['./movimentacao-financeira.component.css']
})
export class MovimentacaoFinanceiraComponent implements OnInit {

  constructor(private http: HttpClient) { }

  dados: any;
  movimentacoes: any;
  total = 0;

  ngOnInit(): void {

    this.http.get('https://localhost:44314/api/v1/movimentacao-financeira/')
        .subscribe(resposta => {

            this.dados = resposta['dados'];
            console.log(this.dados);

            this.movimentacoes = this.dados.movimentacoes;
            this.movimentacoes.forEach(movimentacao => {
              this.total += (movimentacao.natureza === 'Saída' ? movimentacao.valor * (-1) :  movimentacao.valor);
            });

          }, erro => {
            alert('Não foi possível carregar as movimentações. Por favor, tente de novo mais tarde!');
        });
  }
}


