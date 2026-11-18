public class Prijava
{
    public int Id { get; set; }
    public int OglasId { get; set; }
    public Oglas Oglas { get; set; } = null!;
    public int PrijaviteljId { get; set; }
    public Uporabnik Prijavitelj { get; set; } = null!;

    public string Razlog { get; set; } = "";
    public DateTime DatumPrijave { get; set; } = DateTime.UtcNow;
}