export class Usuarios {
  public id: number;
  public nome: string;
  public email: string;
  public senha: string;

  constructor() {
    this.id = 0;
    this.nome = '';
    this.email = '';
    this.senha = '';

  }

   public  Limpar(){
     this.email = "";
     this.senha = "";

    }
  }
