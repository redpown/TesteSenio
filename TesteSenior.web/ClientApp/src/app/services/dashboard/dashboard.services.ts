/*classe criado para servir como um objeto json generico para dashboard
pois todas possuem os mesmos nomes de atributos

*/
import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Dashboard } from '../../models/dashboard-model/dashboard';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
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
  GetAllAcidoUrico(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllAcidoUrico";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  GetAllHIV(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllHIV";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  GetAllCreatinina(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllCreatinina";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }


  GetAllHemograma(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllHemograma";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  GetAllUrina1(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllUrina1";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  GetAllUreia(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllUreia";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  GetAllLDH(): Observable<Dashboard[]> {
    this.url = this.base + "api/Metrica/GetAllLDH";
    return this.httpClient.get<Dashboard[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
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
