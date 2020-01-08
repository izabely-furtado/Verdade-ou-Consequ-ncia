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
  selector: 'app-alerta',
  templateUrl: './alerta.component.html',
  styleUrls: ['./alerta.component.css']
})
export class AlertaComponent implements OnInit {

  novoAlerta: boolean = false;
  filtro: any = {};
  alerta: any = {};
  endereco: any = {};
  loading = false;
  visualizando: any = false;
  listaTipos: any = [];
  listaAlertas: any = [];
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
    this.obterAlertas();

  }

  getFormatterDate(item) {
    return this.global.dateFormater(item);
  }

  add() {
    this.novoAlerta = true;
    this.alerta = {};
  }

  back() {
    this.obterAlertas();
    this.novoAlerta = false;
    this.alerta = {};
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
    this.novoAlerta = true;
    this.obterAlerta(pessoa);
    //this.alerta = pessoa;
    this.visualizando = false;

  }

  view(pessoa) {
    this.edit(pessoa);
    this.visualizando = true;
  }

  obterAlertas() {
    this.loading = true;
    this.apiService.Get("Alerta").then(
      result => {
        this.listaAlertas = result;
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
    this.listaTipos = [];
    this.listaTipos.push({ descricao: "Pulo - Verdade", id: 1 });
    this.listaTipos.push({ descricao: "Pulo - Consequencia", id: 2 });
    this.listaTipos.push({ descricao: "21+", id: 3 });
    this.listaTipos.push({ descricao: "Parabenização", id: 4 });
    
  }
  
  submit() {
    if (this.valida(this.alerta)) {
      this.loading = true;
      if (this.alerta.id != null) {
        this.apiService.Put("Alerta", this.alerta).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Alerta salvo com sucesso!'
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
        this.apiService.Post("Alerta", this.alerta).then(
          result => {
            this.back();
            this.loading = false;
            Swal.fire({
              type: 'success',
              title: 'Sucesso!',
              text: 'Alerta salvo com sucesso!'
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

  remove(alerta) {
    this.loading = true;
    this.apiService.Delete("Alerta", alerta.id).then(
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


  obterAlerta(alerta) {
    this.loading = true;
    this.apiService.GetOne("Alerta", alerta.id).then(
      result => {
        this.alerta = result;
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
    if (tipo == 1) {
      return "Pulo - Verdade";
    }
    if (tipo == 2) {
      return "Pulo - Consequencia";
    }
    if (tipo == 3) {
      return "21+";
    }
    if (tipo == 4) {
      return "Parabenização";
    }
  }
  

}
