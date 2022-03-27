using System;
using SolarFarm.Core.DTO;
using SolarFarm.BLL;
using SolarFarm.Core.Interfaces;

namespace SolarFarm.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO ui = new ConsoleIO();
            PanelController execution = new PanelController(ui);
            IPanelService service = PanelServiceFactory.GetPanelService();
            execution.Service = service;
            execution.Run();
        }
    }
}
