namespace DesafioHotel.Domain.Entities;

public class Reserva
{
    public required List<Pessoa> hospedes { get; set; }
    public required Suite suite { get; set; }
    public required int DiasReservados { get; set; }
    public required DateOnly DataCheckIn { get; set; }
    public required DateOnly DataCheckOut { get; set; }


    public Reserva() : this(1) { }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }
    
    
    public override string ToString()
    {
        return $"Reserva de {hospedes.Count} hóspede(s), " +
               $"Suíte: {suite.TipoSuite}, " +
               $"Dias: {DiasReservados}, " +
               $"Check-in: {DataCheckIn}, Check-out: {DataCheckOut}";
    }
}
