using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolarFarm.Core.DTO;

namespace SolarFarm.Core.Interfaces
{
    public interface IPanelRepository
    {
        List<Panel> GetAll();
        Panel Get(Panel panel);
        bool Add(Panel panel);
        bool Remove(Panel panel);
        bool Edit(Panel panelBeingEdited, Panel editedPanel);
    }

    public interface IPanelService
    {
        List<Panel> LoadAll();
        Panel LoadPanel(Panel panel);
        bool Add(Panel panel);
        bool Remove(Panel panel);
        public bool Edit(Panel panelBeingEdited, Panel editedPanel);
    }
}
