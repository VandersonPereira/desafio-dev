import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FooterComponent } from 'src/app/components/footer/footer.component';
import { CarregarArquivoFormComponent } from './components/carregar-arquivo-form/carregar-arquivo-form.component';
import { MovimentacaoFinanceiraComponent } from './components/movimentacao-financeira/movimentacao-financeira.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    CarregarArquivoFormComponent,
    MovimentacaoFinanceiraComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
