export class Cidade {
  public codigoCidade: number = 0;
  public nomeCidade: string = "";
  public estado: string = "";
  public checkbox: boolean = true;

   public  Limpar(){
      this.codigoCidade = 0;
      this.nomeCidade = "";
      this.estado = "";
    }
  }
