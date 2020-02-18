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
  selector: 'app-consequencia',
  templateUrl: './consequencia.component.html',
  styleUrls: ['./consequencia.component.css']
})
export class ConsequenciaComponent implements OnInit {

  novaConsequencia: boolean = false;
  filtro: any = {};
  consequencia: any = {};
  endereco: any = {};
  loading = false;
  visualizando: any = false;
  listaTipos: any = [];
  listaIdades: any = [];
  listaConsequencias: any = [];
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
    this.obterConsequencias();

  }

  getFormatterDate(item) {
    return this.global.dateFormater(item);
  }

  add() {
    this.novaConsequencia = true;
    this.consequencia = {};
  }

  back() {
    this.obterConsequencias();
    this.novaConsequencia = false;
    this.consequencia = {};
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

  edit(consequencia) {
    this.novaConsequencia = true;
    this.obterConsequencia(consequencia);
    //this.consequencia = pessoa;
    this.visualizando = false;

  }

  view(consequencia) {
    this.edit(consequencia);
    this.visualizando = true;
  }

  obterConsequencias() {
    this.loading = true;
    this.apiService.Get("Consequencia").then(
      result => {
        this.listaConsequencias = result;
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
        console.log(this.listaTipos);
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
    if (this.valida(this.consequencia)) {
      this.loading = true;
      if (this.consequencia.id != null) {
        this.apiService.Put("Consequencia", this.consequencia).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Consequencia salvo com sucesso!'
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
        this.apiService.Post("Consequencia", this.consequencia).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Consequencia salvo com sucesso!'
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

  remove(consequencia) {
    this.loading = true;
    this.apiService.Delete("Consequencia", consequencia.id).then(
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


  obterConsequencia(consequencia) {
    this.loading = true;
    this.apiService.GetOne("Consequencia", consequencia.id).then(
      result => {
        this.consequencia = result;
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

  descIdade(idade) {
    if (idade == 0) { return "Livre"; }
    if (idade == 12) { return "12+"; }
    if (idade == 15) { return "15+"; }
    if (idade == 18) { return "18+"; }
    if (idade == 21) { return "21+"; }
  }
  

}
