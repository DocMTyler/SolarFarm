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
            _panels = ReadFile(Directory.GetCurrentDirectory() + @"\Panels.csv");
        }

        public List<Panel> FindPanelsBySection(string section)
        {
            List<Panel> panelList = new();
            foreach (var storedPanel in _panels)
            {
                if (section == storedPanel.Section)
                {
                    panelList.Add(storedPanel);
                }
            }
            return panelList;
        }

        public Panel Get(Panel panel)
        {
            foreach (var storedPanel in _panels)
            {
                if (panel.Section == storedPanel.Section && panel.Row == storedPanel.Row && panel.Column == storedPanel.Column)
                {
                    return storedPanel;
                }
            }
            return new Panel();
        }

        public bool Add(Panel panel)
        {
            int beforeAdd = _panels.Count;
            
            foreach(var storedPanel in _panels)
            {
                if(storedPanel.Section == panel.Section && storedPanel.Row == panel.Row && storedPanel.Column == panel.Column)
                {
                    Console.WriteLine("Cannot add a duplicate panel.");
                    Console.ReadLine();
                    return false;
                }
            }
            _panels.Add(panel);
            int afterAdd = _panels.Count;
            WriteFile(Directory.GetCurrentDirectory() + @"\Panels.csv");
            return beforeAdd != afterAdd;
        }

        public bool Remove(Panel panel)
        {
            int beforeRemove = _panels.Count;
            
            bool isEmpty = true;
            foreach(var storedPanel in _panels)
            {
                if(storedPanel.Section == panel.Section && storedPanel.Row == panel.Row && storedPanel.Column == panel.Column)
                {
                    isEmpty = false;
                    break;
                }
            }

            if (!isEmpty)
            {
                _panels.Remove(panel);
            }
            else
            {
                Console.WriteLine("Panel does not exist.");
                Console.ReadKey();
                return false;
            }

            int afterRemove = _panels.Count;
            WriteFile(Directory.GetCurrentDirectory() + @"\Panels.csv");
            return beforeRemove != afterRemove;
        }

        public bool Update(Panel panelBeingEdited, Panel editedPanel)
        {
            for (int i = 0; i < _panels.Count; i++)
            {
                if(_panels[i].Section == panelBeingEdited.Section && _panels[i].Row == panelBeingEdited.Row && _panels[i].Column == panelBeingEdited.Column)
                {
                    _panels[i] = editedPanel;
                    WriteFile(Directory.GetCurrentDirectory() + @"\Panels.csv");
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

        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Section,Row,Column,YearInstalled,Material,IsTracking"); // advance to next line
                foreach(var panel in _panels)
                {
                    sw.WriteLine($"{panel.Section},{panel.Row},{panel.Column},{panel.YearInstalled},{(int)panel.Material},{panel.IsTracking}");
                }
                
            }
            return;
        }
    }
}
