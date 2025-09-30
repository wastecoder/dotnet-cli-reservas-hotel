using DesafioHotel.Domain.Entities;
using DesafioHotel.Domain.Enums;

namespace DesafioHotel.Domain.Services;

public class SuiteService
{
    private readonly List<Suite> _suites = [];


    public SuiteService(bool adicionarSuitesPadroes = false)
    {
        if (adicionarSuitesPadroes)
            AdicionarSuitesPadroes();
    }


    public IReadOnlyList<Suite> ObterTodas()
    {
        return _suites.AsReadOnly();
    }

    public Suite? ObterPorTipo(TipoSuite tipo)
    {
        return _suites.FirstOrDefault(s => s.TipoSuite == tipo);
    }

    public void AdicionarSuite(Suite suite)
    {
        if (suite == null)
            throw new ArgumentException("Suíte inválida");

        if (_suites.Any(s => s.TipoSuite == suite.TipoSuite && s.Descricao == suite.Descricao))
            throw new InvalidOperationException("Essa suíte já está cadastrada");

        _suites.Add(suite);
    }

    public bool RemoverSuite(Suite suite)
    {
        return _suites.Remove(suite);
    }

    private void AdicionarSuitesPadroes()
    {
        var suite1 = new Suite
        {
            TipoSuite = TipoSuite.Economica,
            Capacidade = 2,
            ValorDiaria = 100m,
            PossuiCamaCasal = false,
            Descricao = "Suíte econômica básica"
        };

        var suite2 = new Suite
        {
            TipoSuite = TipoSuite.Standard,
            Capacidade = 3,
            ValorDiaria = 200m,
            PossuiCamaCasal = true,
            Descricao = "Suíte standard confortável"
        };

        var suite3 = new Suite
        {
            TipoSuite = TipoSuite.Luxo,
            Capacidade = 4,
            ValorDiaria = 350m,
            PossuiCamaCasal = true,
            Descricao = "Suíte luxo com varanda"
        };

        _suites.AddRange(new List<Suite> { suite1, suite2, suite3 });
    }
}
