namespace panel.Models
{
    public class Server
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string email { set; get; }
        public string ip { set; get; }
        /*public string ipnode { set; get; }*/
        public string? ContainerId { set; get; }
        public int Port { set; get; }
        public string? Setup { set; get; }
        public string? Image { set; get; }
        public float cpu { set; get; }
        public double memory { set; get; }
        public int Disk { set; get; }

        
    }
}
