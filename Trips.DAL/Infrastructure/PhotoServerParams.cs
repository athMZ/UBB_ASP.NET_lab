namespace Trips.DAL.Infrastructure
{
    public class PhotoServerParams
    {
        public const string Section = "PhotoServer";

        public string ServerUrl { get; set; }
        public string FileStorageLocation { get; set; }
        public string FileUploadLocation { get; set; }
    }
}
