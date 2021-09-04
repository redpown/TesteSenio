import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Cidade } from 'src/app/models/cidade-model/cidade';
import { Generic } from '../../models/generic-model/generic';

@Injectable({
  providedIn: 'root'
})
export class GenericoService {
//aqui crio funcoes que retonar apenas um Observable
  public base: string =  document.getElementsByTagName('base')[0].href; // api
  public url: string = "";

  // injetando o HttpClient
  constructor(private httpClient: HttpClient) {
  
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos as Cidades
  getColeta(): Observable<Generic[]> {
    this.url = this.base + "api/Coletas";
    return this.httpClient.get<Generic[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getExames(): Observable<Generic[]> {
    this.url = this.base + "api/Exames";
    return this.httpClient.get<Generic[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getTipoExames(): Observable<Generic[]> {
    this.url = this.base + "api/TipoExame";
    return this.httpClient.get<Generic[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  getExamesStatus(): Observable<Generic[]> {
    this.url = this.base + "api/ExameStatus";
    return this.httpClient.get<Generic[]>(this.url)
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
