using DesafioHotel.Domain.Enums;

namespace DesafioHotel.Domain.Entities;

public class Suite
{
    public required TipoSuite TipoSuite { get; set; }
    public required bool PossuiCamaCasal { get; set; }

    private int _capacidade;
    private decimal _valorDiaria;
    private string _descricao = string.Empty;

    public int Capacidade
    {
        get => _capacidade;
        set
        {
            if (value <= 0)
                throw new ArgumentException("A capacidade deve ser maior que zero");
            _capacidade = value;
        }
    }

    public decimal ValorDiaria
    {
        get => _valorDiaria;
        set
        {
            if (value <= 0)
                throw new ArgumentException("O valor da diária deve ser maior que zero");
            _valorDiaria = value;
        }
    }

    public string Descricao
    {
        get => _descricao;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("A descrição não pode ser vazia");
            _descricao = value.Trim();
        }
    }


    public Suite() : this(TipoSuite.Economica, 1, 20, false, "Suíte econômica padrão") { }

    public Suite(TipoSuite tipoSuite, int capacidade, decimal valorDiaria, bool possuiCamaCasal, string descricao)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
        PossuiCamaCasal = possuiCamaCasal;
        Descricao = descricao;
    }


    public override string ToString()
    {
        return $"{TipoSuite} - Capacidade: {Capacidade}, " +
               $"Valor diária: {ValorDiaria:C2}, " +
               $"Cama casal: {(PossuiCamaCasal ? "Sim" : "Não")}, " +
               $"Descrição: {Descricao}";
    }
}
