public class BlokiranUporabnik
{
    public int BlokerId { get; set; }
    public Uporabnik Bloker { get; set; } = null!;
    public int BlokiranId { get; set; }
    public Uporabnik Blokiran { get; set; } = null!;
}