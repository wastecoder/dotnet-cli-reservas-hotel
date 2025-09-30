using DesafioHotel.Domain.Entities;
using DesafioHotel.Domain.Services;
using DesafioHotel.Domain.Enums;

namespace DesafioHotel.Tests;

public class ReservaServiceTest
{
    public static void Executar()
    {
        TestarAdicionarReservaSucesso();
        TestarAdicionarReservaSemHospedes();
        TestarAdicionarReservaExcessoHospedes();
        TestarAdicionarReservaDatasInvalidas();
        TestarObterTodasReservas();
        TestarObterPorSuite();
        TestarCalcularValorTotalSemDesconto();
        TestarCalcularValorTotalComDesconto();
        TestarRemoverReserva();
    }

    private static Reserva CriarReservaValida(int dias = 5, int qtdHospedes = 2, Suite? suite = null)
    {
        suite ??= new Suite(TipoSuite.Standard, 3, 200m, true, "Standard");

        var hospedes = new List<Pessoa>();
        for (int i = 0; i < qtdHospedes; i++)
        {
            hospedes.Add(new Pessoa($"Pessoa{i + 1}", "Teste", 25));
        }

        return new Reserva(
            hospedes,
            suite,
            dias,
            DateOnly.FromDateTime(DateTime.Today),
            DateOnly.FromDateTime(DateTime.Today.AddDays(dias))
        );
    }

    private static void TestarAdicionarReservaSucesso()
    {
        Console.WriteLine(">>> Adicionar Reserva (Sucesso) <<<");

        var service = new ReservaService();
        var reserva = CriarReservaValida();

        service.AdicionarReserva(reserva);

        Console.WriteLine($"Reservas totais: {service.ObterTodas().Count}");
    }

    private static void TestarAdicionarReservaSemHospedes()
    {
        Console.WriteLine("\n>>> Adicionar Reserva (Falha - Sem Hóspedes) <<<");

        var service = new ReservaService();
        var suite = new Suite(TipoSuite.Economica, 2, 100m, false, "Econômica");

        try
        {
            var reserva = new Reserva(
                [], // Dá erro aqui
                suite,
                2,
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2))
            );

            service.AdicionarReserva(reserva); // Aqui também valida lista vazia, mas não chega aqui
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }
    }

    private static void TestarAdicionarReservaExcessoHospedes()
    {
        Console.WriteLine("\n>>> Adicionar Reserva (Falha - Excesso de Hóspedes) <<<");

        var service = new ReservaService();
        var suite = new Suite(TipoSuite.Standard, 2, 150m, true, "Standard");
        var reserva = CriarReservaValida(qtdHospedes: 3, suite: suite);

        try
        {
            service.AdicionarReserva(reserva);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }
    }

    private static void TestarAdicionarReservaDatasInvalidas()
    {
        Console.WriteLine("\n>>> Adicionar Reserva (Falha - Datas Inválidas) <<<");

        var service = new ReservaService();
        var suite = new Suite(TipoSuite.Luxo, 2, 300m, true, "Luxo");

        var hospedes = new List<Pessoa> { new Pessoa("Ana", "Teste", 28) };

        try
        {
            var reserva = new Reserva(
                hospedes,
                suite,
                2,
                DateOnly.FromDateTime(DateTime.Today.AddDays(5)),
                DateOnly.FromDateTime(DateTime.Today) // Check-out antes do check-in
            );

            service.AdicionarReserva(reserva);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }
    }

    private static void TestarObterTodasReservas()
    {
        Console.WriteLine("\n>>> Obter Todas Reservas <<<");

        var service = new ReservaService();
        var reserva1 = CriarReservaValida();
        var reserva2 = CriarReservaValida();

        service.AdicionarReserva(reserva1);
        service.AdicionarReserva(reserva2);

        var todas = service.ObterTodas();
        Console.WriteLine($"Quantidade de reservas: {todas.Count}");
    }

    private static void TestarObterPorSuite()
    {
        Console.WriteLine("\n>>> Obter Reservas por Suite <<<");

        var service = new ReservaService();
        var suiteLuxo = new Suite(TipoSuite.Luxo, 2, 500m, true, "Luxo");

        var reservaLuxo = CriarReservaValida(suite: suiteLuxo);
        var reservaStandard = CriarReservaValida();

        service.AdicionarReserva(reservaLuxo);
        service.AdicionarReserva(reservaStandard);

        var reservasLuxo = service.ObterPorSuite(suiteLuxo);

        Console.WriteLine($"Reservas para suíte Luxo: {reservasLuxo.Count}");
    }

    private static void TestarCalcularValorTotalSemDesconto()
    {
        Console.WriteLine("\n>>> Calcular Valor Total (Sem Desconto) <<<");

        var service = new ReservaService();
        var reserva = CriarReservaValida(dias: 5);

        service.AdicionarReserva(reserva);
        var valor = service.CalcularValorTotal(reserva);

        Console.WriteLine($"Valor calculado: {valor:C}");
    }

    private static void TestarCalcularValorTotalComDesconto()
    {
        Console.WriteLine("\n>>> Calcular Valor Total (Com Desconto) <<<");

        var service = new ReservaService();
        var reserva = CriarReservaValida(dias: 12);

        service.AdicionarReserva(reserva);
        var valor = service.CalcularValorTotal(reserva);

        Console.WriteLine($"Valor calculado com desconto: {valor:C}");
    }

    private static void TestarRemoverReserva()
    {
        Console.WriteLine("\n>>> Remover Reserva <<<");

        var service = new ReservaService();
        var reserva = CriarReservaValida();

        service.AdicionarReserva(reserva);
        Console.WriteLine($"Antes da remoção: {service.ObterTodas().Count}");

        bool removida = service.RemoverReserva(reserva);

        Console.WriteLine($"Removida: {removida}");
        Console.WriteLine($"Depois da remoção: {service.ObterTodas().Count}");
    }
}
