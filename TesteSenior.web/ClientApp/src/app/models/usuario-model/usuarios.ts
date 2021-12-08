export class Usuarios {
  public id: number;
  public nome: string;
  public email: string;
  public senha: string;
  public perfil: string;

  constructor() {
    this.id = 0;
    this.nome = '';
    this.email = '';
    this.senha = '';
    this.perfil = '';

  }

   public  Limpar(){
     this.email = "";
     this.senha = "";

    }
  }
