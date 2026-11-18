using System.ComponentModel.DataAnnotations;

public class Povprasevanje
{
    
    public int Id { get; set; }
    public int OglasId { get; set; }
    public Oglas Oglas { get; set; } = null!;
    public int KupecId { get; set; }
    public Uporabnik Kupec { get; set; } = null!;

    public string Sporocilo { get; set; } = "";
    public string? Odgovor { get; set; }
    public DateTime DatumOddaje { get; set; } = DateTime.UtcNow;
}