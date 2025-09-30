using DesafioHotel.Domain.Entities;
using DesafioHotel.Domain.Services;
using DesafioHotel.Domain.Enums;

namespace CsharpPOO.Testes;

public class SuiteServiceTest
{
    public static void Executar()
    {
        TestarAdicionarSuiteComSucesso();
        TestarAdicionarSuiteDuplicada();
        TestarObterTodasSuites();
        TestarRemoverSuiteComSucesso();
        TestarRemoverSuiteInexistente();
    }

    private static void TestarAdicionarSuiteComSucesso()
    {
        Console.WriteLine(">>> Adicionar Suite (Sucesso) <<<");

        var service = new SuiteService();
        var suite = new Suite
        {
            TipoSuite = TipoSuite.Economica,
            Capacidade = 2,
            ValorDiaria = 100m,
            PossuiCamaCasal = false,
            Descricao = "Suíte econômica"
        };

        service.AdicionarSuite(suite);

        Console.WriteLine($"Total de suítes: {service.ObterTodas().Count}");
    }

    private static void TestarAdicionarSuiteDuplicada()
    {
        Console.WriteLine("\n>>> Adicionar Suite (Falha - Duplicada) <<<");

        var service = new SuiteService();
        var suite = new Suite
        {
            TipoSuite = TipoSuite.Standard,
            Capacidade = 3,
            ValorDiaria = 200m,
            PossuiCamaCasal = true,
            Descricao = "Suíte standard"
        };

        service.AdicionarSuite(suite);

        try
        {
            service.AdicionarSuite(suite);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }
    }

    private static void TestarObterTodasSuites()
    {
        Console.WriteLine("\n>>> Obter todas as Suítes <<<");

        var service = new SuiteService();
        service.AdicionarSuite(new Suite(TipoSuite.Economica, 2, 100m, false, "Econômica"));
        service.AdicionarSuite(new Suite(TipoSuite.Luxo, 4, 350m, true, "Luxo"));

        var suites = service.ObterTodas();

        foreach (var s in suites)
        {
            Console.WriteLine($"- {s.TipoSuite} | Capacidade: {s.Capacidade} | Valor: {s.ValorDiaria:C}");
        }
    }

    private static void TestarRemoverSuiteComSucesso()
    {
        Console.WriteLine("\n>>> Remover Suite (Sucesso) <<<");

        var service = new SuiteService();
        var suite = new Suite();
        service.AdicionarSuite(suite);

        bool removido = service.RemoverSuite(suite);

        Console.WriteLine($"Removida: {removido}");
        Console.WriteLine($"Total de suítes: {service.ObterTodas().Count}");
    }

    private static void TestarRemoverSuiteInexistente()
    {
        Console.WriteLine("\n>>> Remover Suite (Falha - Inexistente) <<<");

        var service = new SuiteService();
        var suite = new Suite(TipoSuite.Luxo, 4, 350m, true, "Luxo");

        bool removido = service.RemoverSuite(suite);

        Console.WriteLine($"Removida: {removido} (esperado: false)");
    }
}
