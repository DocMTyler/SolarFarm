using System;
using SolarFarm.Core.DTO;
using System.Collections.Generic;
using SolarFarm.Core.Interfaces;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository
    {
        private List<Panel> _panels;

        public PanelRepository()
        {
            //Call Read File methods
            _panels = new List<Panel>();
            Panel panel = new();
            panel.Section = "";
            panel.Row = 1;
            panel.Column = 1;
            panel.Year = new();
            panel.IsTracking = false;
            panel.Material = (Material)1;
        }

        public List<Panel> GetAll()
        {
            List<Panel> panels = new(_panels);
            return panels;
        }

        public Panel Get(Panel panel)
        {
            foreach(var storedPanel in _panels)
            {
                if(panel.Section == storedPanel.Section && panel.Row == storedPanel.Row && panel.Column == storedPanel.Column)
                {
                    return storedPanel;
                }
            }
            return new Panel();
        }

        public bool Add(Panel panel)
        {
            int beforeAdd = _panels.Count;
            if (!_panels.Contains(panel)) _panels.Add(panel);
            int afterAdd = _panels.Count;

            return beforeAdd != afterAdd;
        }

        public bool Remove(Panel panel)
        {
            int beforeRemove = _panels.Count;
            if (_panels.Contains(panel)) _panels.Remove(panel);
            int afterRemove = _panels.Count;
            return beforeRemove != afterRemove;
        }

        public bool Edit(Panel panelBeingEdited, Panel editedPanel)
        {
            for(int i = 0; i < _panels.Count; i++)
            {
                if(_panels[i].Section == panelBeingEdited.Section && _panels[i].Row == panelBeingEdited.Row && _panels[i].Column == panelBeingEdited.Column)
                {
                    _panels[i] = editedPanel;
                    return true;
                }
            }
            return false;
        }

        public List<Panel> ReadFile(string path)
        {
            return new List<Panel>();
        }

    }
}
