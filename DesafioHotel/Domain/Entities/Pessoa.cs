namespace DesafioHotel.Domain.Entities;

public class Pessoa
{
    public required string Nome { get; set; }
    public required string Sobrenome { get; set; }
    public required int Idade { get; set; }


    public Pessoa() : this("", "", 0) { }

    public Pessoa(string nome, string sobrenome, int idade)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }


    public override string ToString()
    {
        return $"{Nome} {Sobrenome} (Idade: {Idade})";
    }
}
