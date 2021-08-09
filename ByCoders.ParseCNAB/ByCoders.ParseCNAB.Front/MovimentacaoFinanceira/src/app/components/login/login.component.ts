import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient, private router:Router) { }

  appComponent = new AppComponent();
  email : string;
  senha : string;
  dados : any;
  
  ngOnInit(): void {
  }

  fazerLogin(){

    this.appComponent.abrirLoading();

    const comando =  { email : this.email, senha : this.senha}

    this.http.post('https://localhost:44314/api/v1/usuario/login', comando)
      .subscribe(resposta =>
        {
          this.dados = resposta['dados'];

          localStorage.setItem('currentUser', JSON.stringify({ token: this.dados.token.trim(), nome: this.dados.nome }));

          this.appComponent.fecharLoading();

          this.router.navigate(['movimentacoes']);

        }, erro => {
          this.appComponent.fecharLoading();
          alert('Não foi possível realizar o login. Por favor, tente de novo mais tarde!');
        });
  }
}
