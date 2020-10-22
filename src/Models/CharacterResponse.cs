namespace CoreMe.Models
{
    public class CharacterResponse
    {
        public string Url { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Culture { get; set; } = string.Empty;
        public string Born { get; set; } = string.Empty;
        public string Died { get; set; } = string.Empty;
        public string[] Titles { get; set; } = new string[0];
        public string[] Aliases { get; set; } = new string[0];
        public string Father { get; set; } = string.Empty;
        public string Mother { get; set; } = string.Empty;
        public string Spouse { get; set; } = string.Empty;
        public string[] Allegiances { get; set; } = new string[0];
        public string[] Books { get; set; } = new string[0];
        public string[] PovBooks { get; set; } = new string[0];
        public string[] TvSeries { get; set; } = new string[0];
        public string[] PlayedBy { get; set; } = new string[0];
    }
}