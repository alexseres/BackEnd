namespace HearthStone_Backend.Models
{
    public class CardBack
    {
        public string CardBackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public bool Enabled{ get; set; }
        public string Img { get; set; }
        public string ImgAnimated { get; set; }
        public string SortCategory { get; set; }
        public string SortOrder { get; set; }
        public string Locale { get; set; }
    }
}