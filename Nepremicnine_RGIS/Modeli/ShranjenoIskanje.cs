public class ShranjenoIskanje
{
    public int Id { get; set; }
    public int UporabnikId { get; set; }
    public Uporabnik Uporabnik { get; set; } = null!;

    public string? Iskalniniz { get; set; }
    public decimal? MinCena { get; set; }
    public decimal? MaxCena { get; set; }
    public double? MinKvadratura { get; set; }
    public double? MaxKvadratura { get; set; }
    public int? StevilоSob { get; set; }
    public TipNepremicnine? Tip { get; set; }
    public bool ObvestilaVklopljena { get; set; } = true;
    public DateTime DatumShranjevanja { get; set; } = DateTime.UtcNow;
}