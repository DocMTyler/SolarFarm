using System;
using SolarFarm.DAL;
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

        public List<Panel> LoadAll()
        {
            return _repo.GetAll();
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

        public bool Edit(Panel panelBeingEdited, Panel editedPanel)
        {
            return _repo.Edit(panelBeingEdited, editedPanel);
        }
    }
}
