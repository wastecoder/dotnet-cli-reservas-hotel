using DesafioHotel.Domain.Entities;

namespace DesafioHotel.Domain.Services;

public class ReservaService
{
    private readonly List<Reserva> _reservas = [];


    public IReadOnlyList<Reserva> ObterTodas()
    {
        return _reservas.AsReadOnly();
    }

    public void AdicionarReserva(Reserva reserva)
    {
        if (reserva == null)
            throw new ArgumentException("Reserva inválida");

        // TODO: adicionar exceções personalizadas
        if (reserva.Hospedes.Count == 0)
            throw new ArgumentException("A reserva deve ter pelo menos um hóspede");

        if (reserva.Hospedes.Count > reserva.Suite.Capacidade)
            throw new InvalidOperationException(
                $"A suíte escolhida não comporta {reserva.Hospedes.Count} hóspedes");

        if (reserva.DataCheckOut <= reserva.DataCheckIn)
            throw new ArgumentException("Check-out deve ser posterior ao check-in");

        _reservas.Add(reserva);
    }

    public decimal CalcularValorTotal(Reserva reserva)
    {
        if (reserva == null)
            throw new ArgumentException("Reserva inválida");

        decimal valor = reserva.DiasReservados * reserva.Suite.ValorDiaria;

        if (reserva.DiasReservados >= 10)
            valor *= 0.9m;

        return valor;
    }

    public bool RemoverReserva(Reserva reserva)
    {
        return _reservas.Remove(reserva);
    }

    public List<Reserva> ObterPorSuite(Suite suite)
    {
        return _reservas.Where(r => r.Suite == suite).ToList();
    }
}
