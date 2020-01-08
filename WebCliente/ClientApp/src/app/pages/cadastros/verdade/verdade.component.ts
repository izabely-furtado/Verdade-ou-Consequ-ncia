import { Component, OnInit, NgModule } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ReactiveFormsModule, FormControl, FormGroup } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators/map';
import { startWith } from 'rxjs/operators/startWith';
import Swal from 'sweetalert2';
import { NgxViacepService, Endereco, ErroCep, ErrorValues, NgxViacepModule } from '@brunoc/ngx-viacep';
import { Global } from '../../../global';
import { ApiService } from '../../../services/api.service';
import { FilterPipe } from 'ngx-filter-pipe';

import {
  Router,
  NavigationStart,
  NavigationEnd,
  ActivatedRoute,
  Event as NavigationEvent
} from "@angular/router";
import { AppComponent } from '../../../app.component';


@Component({
  selector: 'app-verdade',
  templateUrl: './verdade.component.html',
  styleUrls: ['./verdade.component.css']
})
export class VerdadeComponent implements OnInit {

  novaVerdade: boolean = false;
  filtro: any = {};
  verdade: any = {};
  endereco: any = {};
  loading = false;
  visualizando: any = false;
  listaTipos: any = [];
  listaIdades: any = [];
  listaSequencias: any = [];
  listaVerdades: any = [];
  element: HTMLImageElement;

  currentUser: any = {};

  //partes de testes de funcionários
  cabecalho: any = {};
  indice_selecionado: any = 0;


  constructor(
    private apiService: ApiService,
    public global: Global,
    public dialog: MatDialog,
    private router: Router,
    public viaCEP: NgxViacepService,
    private filter: FilterPipe
  ) {

  }

  ngOnInit() {
    this.obterTipos();
    this.obterIdades()
    this.obterSequencias();
    this.obterVerdades();
  }

  getFormatterDate(item) {
    return this.global.dateFormater(item);
  }

  add() {
    this.novaVerdade = true;
    this.verdade = {};
  }

  back() {
    this.obterVerdades();
    this.novaVerdade = false;
    this.verdade = {};
  }
  
  valida(pessoa) {
    if (pessoa.descricao == null || pessoa.descricao == "") {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Insira a descrição!'
      });
      return false;
    }
    if (pessoa.tipo == null || pessoa.tipo == 0) {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Insira o tipo!'
      });
      return false;
    }
    return true;
  }

  edit(pessoa) {
    this.novaVerdade = true;
    this.obterVerdade(pessoa);
    //this.verdade = pessoa;
    this.visualizando = false;

  }

  view(pessoa) {
    this.edit(pessoa);
    this.visualizando = true;
  }

  obterVerdades() {
    this.loading = true;
    this.apiService.Get("Verdade").then(
      result => {
        this.listaVerdades = result;
        this.loading = false;
      },
      err => {
        this.loading = false;
        Swal.fire({
          type: 'error',
          title: 'Oops...',
          text: err.error.mensagem
        });
      }
    );

  }

  obterTipos() {
    this.loading = true;
    this.apiService.Get("Tipo").then(
      result => {
        this.listaTipos = result;
        this.loading = false;
      },
      err => {
        this.loading = false;
        Swal.fire({
          type: 'error',
          title: 'Oops...',
          text: err.error.mensagem
        });
      }
    );
  }

  obterSequencias() {
    this.loading = true;
    this.apiService.Get("Sequencia").then(
      result => {
        this.listaSequencias = result;
        this.loading = false;
      },
      err => {
        this.loading = false;
        Swal.fire({
          type: 'error',
          title: 'Oops...',
          text: err.error.mensagem
        });
      }
    );
  }

  obterIdades() {
    this.listaIdades = [];
    this.listaIdades.push({ descricao: "Livre", id: 0 });
    this.listaIdades.push({ descricao: "12+", id: 12 });
    this.listaIdades.push({ descricao: "15+", id: 15 });
    this.listaIdades.push({ descricao: "18+", id: 18 });
    this.listaIdades.push({ descricao: "21+", id: 21 });
  }
  
  submit() {
    if (this.valida(this.verdade)) {
      this.loading = true;
      if (this.verdade.id != null) {
        this.apiService.Put("Verdade", this.verdade).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Verdade salvo com sucesso!'
            });
          },
          err => {
            this.loading = false;
            Swal.fire({
              type: 'error',
              title: 'Oops...',
              text: err.error.mensagem
            });
          }
        );
      } else {
        this.apiService.Post("Verdade", this.verdade).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Verdade salvo com sucesso!'
            });
          },
          err => {
            this.loading = false;
            Swal.fire({
              type: 'error',
              title: 'Oops...',
              text: err.error.mensagem
            });
          }
        );
      }
    }
    else {
      return;
    }
  }

  remove(verdade) {
    this.loading = true;
    this.apiService.Delete("Verdade", verdade.id).then(
      result => {
        this.ngOnInit();
        this.loading = false;
      },
      err => {
        this.loading = false;
        Swal.fire({
          type: 'error',
          title: 'Oops...',
          text: err.error.mensagem
        });
      }
    );
  }


  obterVerdade(verdade) {
    this.loading = true;
    this.apiService.GetOne("Verdade", verdade.id).then(
      result => {
        this.verdade = result;
        this.loading = false;
      },
      err => {
        this.loading = false;
        Swal.fire({
          type: 'error',
          title: 'Oops...',
          text: err.error.mensagem
        });
      }
    );

  }

  limparCampos() {
    this.indice_selecionado = "";
    this.filtro = {};
  }

  descTipo(tipo) {
    if (tipo == 1) { return "Pulo"; }
    if (tipo == 2) { return "21+"; }
    if (tipo == 3) { return "Parabenização"; }
  }


  descIdade(idade) {
    if (idade == 0) { return "Livre"; }
    if (idade == 12) { return "12+"; }
    if (idade == 15) { return "15+"; }
    if (idade == 18) { return "18+"; }
    if (idade == 21) { return "21+"; }
  }

  addTipo(tipo) {
    if (tipo == null) {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Selecione um tipo primeiro!'
      });
      return;
    }
    if (this.verdade.Tipos == null) {
      this.verdade.Tipos = [];
    }
    this.verdade.Tipos.push(tipo);
    this.verdade.tipo = {};
  }

  removeTipo(tipo_index) {
    this.verdade.Tipos.splice(tipo_index, 1);
  }

  addOpcao(opcao) {
    if (opcao == null) {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Selecione uma opção primeiro!'
      });
      return;
    }
    if (this.verdade.Opcoes == null) {
      this.verdade.Opcoes = [];
    }
    if (this.verdade.Opcoes.length >= 5) {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Foi excedido o número máximo de opções!'
      });
      return;
    }
    opcao = opcao.toUpperCase();
    this.verdade.Opcoes.push({ descricao: opcao });
    this.verdade.opcao = "";
  }

  removeOpcao(opcao_index) {
    this.verdade.Opcoes.splice(opcao_index, 1);
  }

  retornaLetra(index) {
    if (index == 0) {
      return 'A';
    }
    if (index == 1) {
      return 'B';
    }
    if (index == 2) {
      return 'C';
    }
    if (index == 3) {
      return 'D';
    }
    if (index == 4) {
      return 'E';
    }
  }

}
