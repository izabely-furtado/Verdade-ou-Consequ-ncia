import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { PessoaComponent } from './pages/cadastros/pessoa/pessoa.component';
import { AlertaComponent } from './pages/cadastros/alerta/alerta.component';
import { TipoComponent } from './pages/cadastros/tipo/tipo.component';
import { ConsequenciaComponent } from './pages/cadastros/consequencia/consequencia.component';
import { VerdadeComponent } from './pages/cadastros/verdade/verdade.component';

export const appRoutes: Routes = [
  {
    path: '', component: HomeComponent, children: [
      {
        path: 'cadastros', children: [
          { path: 'pessoa', component: PessoaComponent },
          { path: 'alerta', component: AlertaComponent },
          { path: 'consequencia', component: ConsequenciaComponent },
          { path: 'verdade', component: VerdadeComponent },
          { path: 'tipo', component: TipoComponent },
        ]
      },
    ]
  },
  // { path: 'erro', component: ErroComponent, pathMatch: 'full' },
];
