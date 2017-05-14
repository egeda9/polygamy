namespace Polygamy.Models
{
    public class AppSettings
    {
        private string defaultConnection;

        public string DefaultConnection
        {
            get => defaultConnection;
            set => defaultConnection = value;
        }
    }
}
