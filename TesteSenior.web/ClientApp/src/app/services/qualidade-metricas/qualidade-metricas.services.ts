import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, subscribeOn } from 'rxjs/operators';
import { QualidadeMetricas } from 'src/app/models/qualidade-metricas-model/qualidade-metricas';


@Injectable({
  providedIn: 'root'
})
export class QualidadeMetricasService {
//aqui crio funcoes que retonar apenas um Observable
  public url: string =  document.getElementsByTagName('base')[0].href; // api


  // injetando o HttpClient
  constructor(private httpClient: HttpClient) {
    this.url = this.url + "api/qualidademetricas";
  }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos as QualidadeMetricass
  getQualidadeMetricass(): Observable<QualidadeMetricas[]> {
    return this.httpClient.get<QualidadeMetricas[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem uma QualidadeMetricas pelo id
  getQualidadeMetricasById(id: number): Observable<QualidadeMetricas> {
    return this.httpClient.get<QualidadeMetricas>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva uma QualidadeMetricas
  saveQualidadeMetricas(QualidadeMetricas: QualidadeMetricas): Observable<QualidadeMetricas> {
    return this.httpClient.post<QualidadeMetricas>(this.url, JSON.stringify(QualidadeMetricas), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza uma QualidadeMetricas
  updateQualidadeMetricas(QualidadeMetricas: QualidadeMetricas): Observable<QualidadeMetricas> {
    return this.httpClient.put<QualidadeMetricas>(this.url, JSON.stringify(QualidadeMetricas), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // deleta uma QualidadeMetricas
  deleteQualidadeMetricas(id:number) {
    return this.httpClient.delete<QualidadeMetricas>(this.url + '/' + id, this.httpOptions)
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
