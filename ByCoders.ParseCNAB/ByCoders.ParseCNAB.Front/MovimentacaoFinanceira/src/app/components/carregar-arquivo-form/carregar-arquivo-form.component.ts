import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-carregar-arquivo-form',
  templateUrl: './carregar-arquivo-form.component.html',
  styleUrls: ['./carregar-arquivo-form.component.css']
})
export class CarregarArquivoFormComponent implements OnInit {

  constructor(private http: HttpClient) { }

  evento: any;
  dados: any;

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

    if (this.evento.target.files &&  this.evento.target.files[0]){

      const arquivo = this.evento.target.files[0];
      const formData = new FormData();
      formData.append('arquivo', arquivo);

      this.http.post('https://localhost:44314/api/v1/movimentacao-financeira/upload-arquivo', formData)
        .subscribe(resposta =>
          {
            this.dados = resposta['dados'];
            alert(this.dados.mensagem);
          }, erro => {
            alert('Não foi possível carregar o seu arquivo. Por favor, tente de novo mais tarde!');
          });
    }
    else{
      alert('Por favor, adicione um arquivo antes!');
    }
  }
}
