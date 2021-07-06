import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { Pagamento } from '../../models/pagamento-model/pagamento';

@Injectable({
  providedIn: 'root'
})
export class PagamentoService {
//aqui crio funcoes que retonar apenas um Observable
  private url: string;
  //url = 'https://localhost:44324/api/TabelaEdificio'; // api

  // injetando o HttpClient
  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + "api/TabelaPagamentosCondominio";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os Pagamentos
  getPagamentos(): Observable<Pagamento[]> {
    return this.httpClient.get<Pagamento[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem um Pagamento pelo id
  getPagamentoById(id: number): Observable<Pagamento> {
    return this.httpClient.get<Pagamento>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva uma Edificio
  savePagamento(pagamento: Pagamento): Observable<Pagamento> {
    return this.httpClient.post<Pagamento>(this.url, JSON.stringify(pagamento), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza um Pagamento
  updatePagamento(pagamento: Pagamento): Observable<Pagamento> {
                                       //url      ,body,                 , headers
                                       //this.url, JSON.stringify(Edificio), this.httpOptions)
    return this.httpClient.put<Pagamento>(this.url, JSON.stringify(pagamento), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta uma Edificio
  deleteEdificio(id:number) {
    return this.httpClient.delete<Pagamento>(this.url + '/' + id, this.httpOptions)
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
