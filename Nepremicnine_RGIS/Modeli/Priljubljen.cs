public class Priljubljen
{
    public int UporabnikId { get; set; }
    public Uporabnik Uporabnik { get; set; } = null!;
    public int OglasId { get; set; }
    public Oglas Oglas { get; set; } = null!;
}