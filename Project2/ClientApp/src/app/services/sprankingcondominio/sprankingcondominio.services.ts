import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { SPRankingCondominio } from '../../models/sprankingcondominio-model/sprankingcondominio';

@Injectable({
  providedIn: 'root'
})
export class SPRankingCondominioService {
//aqui crio funcoes que retonar apenas um Observable
  private url: string;
  //url = 'https://localhost:44324/api/TabelaEdificio'; // api

  // injetando o HttpClient
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + "api/SPRankingCondominio";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os SPRankingCondominio
  getSPRankingCondominios(): Observable<SPRankingCondominio[]> {
    return this.httpClient.get<SPRankingCondominio[]>(this.url)
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
