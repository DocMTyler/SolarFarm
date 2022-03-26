using System;
using SolarFarm.Core.DTO;
using System.Collections.Generic;
using SolarFarm.Core.Interfaces;
using System.IO;

namespace SolarFarm.DAL
{
    public class PanelRepository : IPanelRepository
    {
        private List<Panel> _panels;

        public PanelRepository()
        {
            //Call Read File methods
            _panels = ReadFile(Directory.GetCurrentDirectory() + @"\Panels.csv");

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
            List<Panel> panelList = new();

            if (File.Exists(path))
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    string currentLine = reader.ReadLine();
                    currentLine = reader.ReadLine();
                    int lineCount = 0;

                    while(currentLine != null)
                    {
                        lineCount++;
                        Panel panel = new();
                        string[] columns = currentLine.Split(",");

                        panel.Section = columns[0];
                        panel.Row = int.Parse(columns[1]);
                        panel.Column = int.Parse(columns[2]);
                        panel.YearInstalled = DateTime.Parse(columns[3]);
                        panel.Material = (Material)int.Parse(columns[4]);
                        panel.IsTracking = bool.Parse(columns[5]);

                        panelList.Add(panel);
                        currentLine = reader.ReadLine();
                    }
                }
            }
            else
            {
                return panelList;
            }
            
            return panelList;
        }

        public List<Panel> WriteFile(string path)
        {
            
            
            return new List<Panel>();
        }


    }
}
