namespace AsyncAwaitLab.Models.Weathers
{
    public class DataSeries
    {
        public int Timepoint { get; set; }
        public int Cloudcover { get; set; }
        public int Seeing { get; set; }
        public int Transparency { get; set; }
        public int LiftedIndex { get; set; }
        public int Rh2m { get; set; }
        public Wind10m Wind10m { get; set; }
        public int Temp2m { get; set; }
        public string PrecType { get; set; }
    }
}