import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Cidade } from 'src/app/models/cidade-model/cidade';

@Injectable({
  providedIn: 'root'
})
export class CidadeService {
//aqui crio funcoes que retonar apenas um Observable
  private url: string;
  //url = 'https://localhost:44324/api/TabelaCidade'; // api

  // injetando o HttpClient
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + "api/TabelaCidade";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os Cidades
  getCidades(): Observable<Cidade[]> {
    return this.httpClient.get<Cidade[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem uma Cidade pelo id
  getCidadeById(id: number): Observable<Cidade> {
    return this.httpClient.get<Cidade>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva uma Cidade
  saveCidade(cidade: Cidade): Observable<Cidade> {
    return this.httpClient.post<Cidade>(this.url, JSON.stringify(cidade), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza uma Cidade
  updateCidade(cidade: Cidade): Observable<Cidade> {
                                       //url      ,body,                 , headers
                                       //this.url, JSON.stringify(cidade), this.httpOptions)
    return this.httpClient.put<Cidade>(this.url, JSON.stringify(cidade), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta uma Cidade
  deleteCidade(id:number) {
    return this.httpClient.delete<Cidade>(this.url + '/' + id, this.httpOptions)
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
