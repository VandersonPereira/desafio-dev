import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor() { }

  title = 'MovimentacaoFinanceira';

  abrirLoading(){
    document.getElementById('loading').style.display = "block";
  }

  fecharLoading(){
    document.getElementById('loading').style.display = "none";
  }
}
