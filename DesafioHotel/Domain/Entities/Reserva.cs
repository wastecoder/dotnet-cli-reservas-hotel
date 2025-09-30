namespace DesafioHotel.Domain.Entities;

public class Reserva
{
    public DateOnly DataCheckIn { get; set; }
    public DateOnly DataCheckOut { get; set; }

    private int _diasReservados;
    private List<Pessoa> _hospedes = [];
    private Suite _suite = null!;

    public List<Pessoa> Hospedes
    {
        get => _hospedes;
        set
        {
            if (value == null || value.Count == 0)
                throw new ArgumentException("A reserva deve ter pelo menos um hóspede");
            _hospedes = value;
        }
    }

    public Suite Suite
    {
        get => _suite;
        set
        {
            _suite = value ?? throw new ArgumentException("A reserva deve ter uma suíte válida");
        }
    }

    public int DiasReservados
    {
        get => _diasReservados;
        set
        {
            if (value <= 0)
                throw new ArgumentException("O número de dias deve ser maior que zero");
            _diasReservados = value;
        }
    }


    public Reserva() { }

    public Reserva(List<Pessoa> hospedes, Suite suite, int diasReservados, DateOnly dataCheckIn, DateOnly dataCheckOut)
    {
        if (dataCheckOut <= dataCheckIn)
            throw new ArgumentException("A data de check-out deve ser posterior ao check-in");

        Hospedes = hospedes;
        Suite = suite;
        DiasReservados = diasReservados;
        DataCheckIn = dataCheckIn;
        DataCheckOut = dataCheckOut;
    }


    public override string ToString()
    {
        return $"Reserva de {Hospedes.Count} hóspede(s), " +
               $"Suíte: {Suite.TipoSuite}, " +
               $"Dias: {DiasReservados}, " +
               $"Check-in: {DataCheckIn}, Check-out: {DataCheckOut}";
    }
}
