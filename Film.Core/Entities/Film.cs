namespace Film.Core.Entities
{
    public class Film : BaseEntity
    {
        public string FilmName { get; set; }
        public string DirectorName { get; set;}
        public DateTime ReleasedYear { get; set; }
    }
}
