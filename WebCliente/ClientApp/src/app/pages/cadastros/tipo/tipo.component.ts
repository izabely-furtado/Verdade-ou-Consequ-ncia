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
  selector: 'app-tipo',
  templateUrl: './tipo.component.html',
  styleUrls: ['./tipo.component.css']
})
export class TipoComponent implements OnInit {

  novoTipo: boolean = false;
  filtro: any = {};
  tipo: any = {};
  endereco: any = {};
  loading = false;
  visualizando: any = false;
  listaTipos: any = [];
  element: HTMLImageElement;

  currentUser: any = {};

  //partes de testes de funcionários
  cabecalho: any = {};
  listaPaginas: any = [];
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
  }

  getFormatterDate(item) {
    return this.global.dateFormater(item);
  }

  add() {
    this.novoTipo = true;
    this.tipo = {};
  }

  back() {
    this.obterTipos();
    this.novoTipo = false;
    this.tipo = {};
  }
  
  valida(tipo) {
    if (tipo.descricao == null || tipo.descricao == "") {
      Swal.fire({
        type: 'error',
        title: 'Oops...',
        text: 'Insira a descrição!'
      });
      return false;
    }
    return true;
  }

  edit(tipo) {
    this.novoTipo = true;
    this.obterTipo(tipo);
    this.visualizando = false;

  }

  view(tipo) {
    this.edit(tipo);
    this.visualizando = true;
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
  
  submit() {
    if (this.valida(this.tipo)) {
      this.loading = true;
      if (this.tipo.id != null) {
        this.apiService.Put("Tipo", this.tipo).then(
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
        this.apiService.Post("Tipo", this.tipo).then(
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

  remove(tipo) {
    this.loading = true;
    this.apiService.Delete("Tipo", tipo.cpf + "?uuid=" + tipo.cpf).then(
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


  obterTipo(tipo) {
    this.loading = true;
    this.apiService.GetOne("Tipo", tipo.cpf + "?uuid=" + tipo.cpf).then(
      result => {
        this.tipo = result;
        if (this.tipo != null && this.tipo.data_nascimento != null) {
          this.tipo.data_nascimento_str = this.global.dateFormater(result['data_nascimento']);
        }
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
  
}
