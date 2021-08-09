import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppComponent }  from 'src/app/app.component';

@Component({
  selector: 'app-carregar-arquivo-form',
  templateUrl: './carregar-arquivo-form.component.html',
  styleUrls: ['./carregar-arquivo-form.component.css']
})
export class CarregarArquivoFormComponent implements OnInit {

  constructor(private http: HttpClient) { }

  evento: any;
  dados: any;
  appComponent = new AppComponent();

  ngOnInit(): void {
  }

  registrarArquivo(event){
    this.evento = event;
  }

  carregarArquivo(){

    if(this.evento == null){
      alert('Por favor, adicione um arquivo antes!');
      return;
    }

    var currentUser = JSON.parse(localStorage.getItem('currentUser'));
    var token = currentUser.token;

    var headers = new HttpHeaders()
    .set('Authorization', `Bearer ${token}`)
    .set('Access-Control-Allow-Origin', '*');
    
    this.appComponent.abrirLoading();

    if (this.evento.target.files &&  this.evento.target.files[0]){

      const arquivo = this.evento.target.files[0];
      const formData = new FormData();
      formData.append('arquivo', arquivo);

      this.http.post('https://localhost:44314/api/v1/movimentacao-financeira/upload-arquivo', formData, { 'headers' : headers})
        .subscribe(resposta =>
          {
            this.dados = resposta['dados'];
            alert(this.dados.mensagem);
            this.appComponent.fecharLoading();
          }, erro => {
            this.appComponent.fecharLoading();
            alert('Não foi possível carregar o seu arquivo. Por favor, tente de novo mais tarde!');
          });
    }
    else{
      this.appComponent.fecharLoading();
      alert('Por favor, adicione um arquivo antes!');
    }
  }
}
