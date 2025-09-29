namespace DesafioHotel.Domain.Entities;

public class Pessoa
{
    private string _nome = string.Empty;
    private string _sobrenome = string.Empty;
    private int _idade;

    public string Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O nome não pode ser vazio");
            _nome = value.Trim();
        }
    }

    public string Sobrenome
    {
        get => _sobrenome;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("O sobrenome não pode ser vazio");
            _sobrenome = value.Trim();
        }
    }

    public int Idade
    {
        get => _idade;
        set
        {
            if (value < 0)
                throw new ArgumentException("A idade não pode ser negativa");
            _idade = value;
        }
    }


    public Pessoa() : this("SemNome", "SemSobrenome", 0) { }

    public Pessoa(string nome, string sobrenome, int idade)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Idade = idade;
    }


    public override string ToString()
    {
        return $"{Nome} {Sobrenome} (Idade: {Idade})";
    }
}
