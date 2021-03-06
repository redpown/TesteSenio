import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Edificio } from '../../models/edificio-model/edificio';

@Injectable({
  providedIn: 'root'
})
export class EdificioService {
//aqui crio funcoes que retonar apenas um Observable
 public url: string =  document.getElementsByTagName('base')[0].href; // api

  // injetando o HttpClient
  constructor(private httpClient: HttpClient) {
    this.url = this.url + "api/TabelaEdificio";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os Edificios
  getEdificios(): Observable<Edificio[]> {
    return this.httpClient.get<Edificio[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem um Edificio pelo id
  getEdificioById(id: number): Observable<Edificio> {
    return this.httpClient.get<Edificio>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva uma Edificio
  saveEdificio(edificio: Edificio): Observable<Edificio> {
    return this.httpClient.post<Edificio>(this.url, JSON.stringify(edificio), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza um Edificio
  updateEdificio(edificio: Edificio): Observable<Edificio> {
                                       //url      ,body,                 , headers
                                       //this.url, JSON.stringify(Edificio), this.httpOptions)
    return this.httpClient.put<Edificio>(this.url, JSON.stringify(edificio), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta uma Edificio
  deleteEdificio(id:number) {
    return this.httpClient.delete<Edificio>(this.url + '/' + id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // Manipula????o de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `C??digo do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
