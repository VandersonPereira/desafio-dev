import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarregarArquivoFormComponent } from './components/carregar-arquivo-form/carregar-arquivo-form.component';
import { LoginComponent } from './components/login/login.component';
import { MovimentacaoFinanceiraComponent } from './components/movimentacao-financeira/movimentacao-financeira.component';

const routes: Routes = [
  { path: '', redirectTo:'login', pathMatch:'full' },
  { path: 'login', component:LoginComponent },
  { path: 'movimentacoes', component:MovimentacaoFinanceiraComponent },
  { path:'carregar-arquivo', component:CarregarArquivoFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
