using System.Net;

namespace ASP_net6_Core_webApi_.Configuration
{
    /// <summary>
    /// Информация о нашем доме
    /// </summary>
    public class HomeOptions
    {
        public int FloorAmount { get; set; }
        public string Telephone { get; set; }
        public Heating Heating { get; set; }
        public int CurrentVolts { get; set; }
        public bool GasConnected { get; set; }
        public int Area { get; set; }
        public Material Material { get; set; }
        public Address Address { get; set; }
    }
}
