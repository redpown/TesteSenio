import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Apartamento } from '../../models/apartamento-model/apartamento';

@Injectable({
  providedIn: 'root'
})
export class ApartamentoService {
//aqui crio funcoes que retonar apenas um Observable
public url: string =  document.getElementsByTagName('base')[0].href;

  // injetando o HttpClient
  constructor(private httpClient: HttpClient) {
    this.url = this.url + "api/TabelaApartamento";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os Apartamentos
  getApartamentos(): Observable<Apartamento[]> {
    return this.httpClient.get<Apartamento[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem um Apartamento pelo id
  getApartamentoById(id: number): Observable<Apartamento> {
    return this.httpClient.get<Apartamento>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva um Apartamento
  saveApartamento(apartamento: Apartamento): Observable<Apartamento> {
    return this.httpClient.post<Apartamento>(this.url, JSON.stringify(apartamento), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza um Apartamento
  updateApartamento(apartamento: Apartamento): Observable<Apartamento> {
    return this.httpClient.put<Apartamento>(this.url, JSON.stringify(apartamento), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta um Apartamento
  deleteEdificio(id:number) {
    return this.httpClient.delete<Apartamento>(this.url + '/' + id, this.httpOptions)
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
