using SolarFarm.Core.DTO;
using SolarFarm.Core.Interfaces;
using System.Collections.Generic;

namespace SolarFarm.BLL
{
    public class PanelService : IPanelService
    {
        private IPanelRepository _repo;

        public PanelService(IPanelRepository repo)
        {
            _repo = repo;
        }

        public List<Panel> FindPanelsBySection(string section)
        {
            return _repo.FindPanelsBySection(section);
        }

        public Panel LoadPanel(Panel panel)
        {
            return _repo.Get(panel);
        }

        public bool Add(Panel panel)
        {
            return _repo.Add(panel);
        }

        public bool Remove(Panel panel)
        {
            return _repo.Remove(panel);
        }

        public bool Update(Panel panelBeingEdited, Panel editedPanel)
        {
            return _repo.Update(panelBeingEdited, editedPanel);
        }
    }
}
