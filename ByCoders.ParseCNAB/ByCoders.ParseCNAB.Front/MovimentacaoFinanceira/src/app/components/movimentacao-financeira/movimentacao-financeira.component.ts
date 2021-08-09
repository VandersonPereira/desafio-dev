import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppComponent }  from 'src/app/app.component';

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
  appComponent = new AppComponent();

  ngOnInit(): void {

    this.appComponent.abrirLoading();

    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    var token = currentUser.token;

    var headers = new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Authorization', `Bearer ${token}`)
    .set('Access-Control-Allow-Origin', '*');

    console.log(`Bearer ${token}`)

    this.http.get('https://localhost:44314/api/v1/movimentacao-financeira/', { 'headers' : headers})
        .subscribe(resposta => {

            this.dados = resposta['dados'];

            if(this.dados === null){
              this.appComponent.fecharLoading();
              alert('Não foi possível carregar as movimentações. Por favor, tente de novo mais tarde!');
            }

            this.movimentacoes = this.dados.movimentacoes;
            this.movimentacoes.forEach(movimentacao => {

              if(movimentacao.natureza === 2){
                movimentacao.valor *= -1;
              }

              this.total += movimentacao.valor;
            });

            this.appComponent.fecharLoading();

          }, erro => {
            this.appComponent.fecharLoading();
            alert('Não foi possível carregar as movimentações. Por favor, tente de novo mais tarde!');
        });
  }
}


