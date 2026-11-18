public class Ocena
{
    public int Id { get; set; }
    public int AvtorId { get; set; }
    public Uporabnik Avtor { get; set; } = null!;

    public int? OglasId { get; set; }
    public Oglas? Oglas { get; set; }
    public int? OcenjeniUporabnikId { get; set; }
    public Uporabnik? OcenjeniUporabnik { get; set; }

    public int Zvezdice { get; set; } // 1-5
    public DateTime DatumOcene { get; set; } = DateTime.UtcNow;
}