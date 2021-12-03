import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Usuarios } from '../../models/usuario-model/usuarios';


@Injectable({
  providedIn: 'root'
})
export class UsuariosService {
//aqui crio funcoes que retonar apenas um Observable
  public url: string =  document.getElementsByTagName('base')[0].href; // api


  // injetando o HttpClient
  constructor(private httpClient: HttpClient) {
    this.url = this.url + "api/Usuario";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos as Usuarioss
  getUsuarios(): Observable<Usuarios[]> {
    return this.httpClient.get<Usuarios[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem uma Usuarios pelo id
  getUsuariosById(id: number): Observable<Usuarios> {
    return this.httpClient.get<Usuarios>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // Validar um Usuario pelo login
  validarUsuariosByLogin(Usuarios: Usuarios): Observable<Usuarios> {
    return this.httpClient.post<Usuarios>(this.url + '/login', JSON.stringify(Usuarios), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva uma Usuarios
  saveUsuarios(Usuarios: Usuarios): Observable<Usuarios> {
    return this.httpClient.post<Usuarios>(this.url, JSON.stringify(Usuarios), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza uma Usuarios
  updateUsuarios(Usuarios: Usuarios): Observable<Usuarios> {
    return this.httpClient.put<Usuarios>(this.url, JSON.stringify(Usuarios), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta uma Usuarios
  deleteUsuarios(id:number) {
    return this.httpClient.delete<Usuarios>(this.url + '/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
