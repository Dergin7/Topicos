namespace API.Models;

//O objeto é o Carro já o Id, Name e CriadoEm são as informações deste
public class Carro 
{
    //int, string e DateTime é o tipo do objeto(Id,Name,CriadoEm) números, letras e a data de hoje.
    //O get e o set definem o objeto, com get você puxa a informação e o set você adiciona a informação
    public int Id { get; set;}
    public string Name { get; set;}
    public DateTime CriadoEm { get; set;}

    // aqui está sendo definido que CriadoEm receberá a informação da data e hora de do extamomento que for requisitado
    public Carro() {
        this.CriadoEm = DateTime.Now;
    }
};