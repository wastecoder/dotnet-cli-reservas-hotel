using DesafioHotel.Domain.Enums;

namespace DesafioHotel.Domain.Entities;

public class Suite
{
    public required TipoSuite TipoSuite { get; set; }
    public required int Capacidade { get; set; }
    public required decimal ValorDiaria { get; set; }
    public required bool PossuiCamaCasal { get; set; }
    public required string Descricao { get; set; }


    public Suite() : this(TipoSuite.Economica, 1, 20, false, "") { }

    public Suite(TipoSuite tipoSuite, int capacidade, decimal valorDiaria, bool possuiCamaCasal, string descricao)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
        PossuiCamaCasal =  possuiCamaCasal;
        Descricao = descricao;
    }


    public override string ToString()
    {
        return $"{TipoSuite} - Capacidade: {Capacidade}, Valor diária: {ValorDiaria:C}, " +
               $"Cama casal: {(PossuiCamaCasal ? "Sim" : "Não")}, Desc: {Descricao}";
    }
}
