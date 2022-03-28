using System;
using SolarFarm.Core.Interfaces;
using SolarFarm.Core.DTO;

namespace SolarFarm.UI
{
    class PanelController
    {
        private ConsoleIO _ui;
        public IPanelService Service { get; set; }

        public PanelController(ConsoleIO ui)
        {
            _ui = ui;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                switch (GetMenuChoice())
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        FindPanelsBySection();
                        break;
                    case 2:
                        AddPanel();
                        break;
                    case 3:
                        UpdatePanel();
                        break;
                    case 4:
                        RemovePanel();
                        break;
                    case 5:
                        MaterialsList();
                        Console.ReadKey();
                        break;
                    default:
                        _ui.Display("Invalid input. Please enter a number 0 - 5");
                        _ui.Display("Press any key to continue");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void MaterialsList()
        {
            _ui.Display("Materials List and Abbreviations");
            _ui.Display("================================");
            _ui.Display("1. MultiCrySi - MultiCrystalline Silicon");
            _ui.Display("2. MonoCrysSi - MonoCrystalline Silicon");
            _ui.Display("3. AmorphouSi - Amorphous Silicon");
            _ui.Display("4. CadmTellur - Cadmium Telluride");
            _ui.Display("5. CoIndGalSe - Copper Indium Gallium Selenide");
        }

        public int GetMenuChoice()
        {
            _ui.DisplayMenu();
            bool isValid = int.TryParse(Console.ReadLine(), out int output);
            while (!isValid)
            {
                _ui.Display("Invalid entry, enter a number 0 - 5");
                isValid = int.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }

        public void FindPanelsBySection()
        {
            Console.Clear();
            _ui.Display("Find Panels by Section");
            _ui.Display("======================");
            _ui.Display("");
            Console.Write("Enter Section Name: ");
            string section = Console.ReadLine();
            _ui.Display("");
            _ui.Display($"Panels in {section}" );
            
            _ui.Display("Row  Col Year  Material    Tracking");
            var panelList = Service.FindPanelsBySection(section);
            if (panelList.Count > 0)
            {
                foreach(var panel in panelList)
                {
                    _ui.Display(panel.ToString());
                }
            }
            _ui.Display("Press any key to continue");
            Console.ReadLine();
        }

        public void AddPanel()
        {
            Console.Clear();
            Panel panel = new();
            _ui.Display("Add a Panel");
            _ui.Display("===========");
            _ui.Display("");
            
            Console.Write("Section: ");
            panel.Section = Console.ReadLine();
            while (string.IsNullOrEmpty(panel.Section))
            {
                _ui.Display("Section cannot be empty, please enter a section");
                panel.Section = Console.ReadLine();
            }
            
            panel.Row = _ui.GetInt("Row");
            while(panel.Row < 1 || panel.Row > 250)
            {
                _ui.Display("Invalid input, Row must be between 1 and 250");
                panel.Row = _ui.GetInt("Row");
            }

            panel.Column = _ui.GetInt("Column");
            while (panel.Column < 1 || panel.Column > 250)
            {
                _ui.Display("Invalid input, Column must be between 1 and 250");
                panel.Column = _ui.GetInt("Column");
            }

            Console.Write("Material[1-5]: ");
            var materialInteger = _ui.ValidInt(Console.ReadLine());
            while (materialInteger < 1 || materialInteger > 5)
            {
                _ui.Display("Invalid input, Material must be between 1 and 5");
                materialInteger = _ui.ValidInt(Console.ReadLine());
            }
            panel.Material = (Material)materialInteger;

            Console.Write("Installation Year: ");
            panel.YearInstalled = _ui.ValiDATE("1/1/" + Console.ReadLine());

            Console.Write("Tracked [y/n]: ");
            panel.IsTracking = Console.ReadLine().ToLower() == "y" ? true : false;

            _ui.Display(Service.Add(panel) ? "Panel added" : "Panel not added");
            _ui.Display("Press any key to continue");
            Console.ReadLine();
        }

        public void UpdatePanel()
        {
            Console.Clear();
            Panel panel = new();
            _ui.Display("Update a Panel");
            _ui.Display("==============");
            _ui.Display("");
            Console.Write("Section: ");
            panel.Section = Console.ReadLine();
            while (string.IsNullOrEmpty(panel.Section))
            {
                _ui.Display("Section cannot be empty, please enter a section");
                panel.Section = Console.ReadLine();
            }

            panel.Row = _ui.GetInt("Row");
            while (panel.Row < 1 || panel.Row > 250)
            {
                _ui.Display("Invalid input, Row must be between 1 and 250");
                panel.Row = _ui.GetInt("Row");
            }

            panel.Column = _ui.GetInt("Column");
            while (panel.Column < 1 || panel.Column > 250)
            {
                _ui.Display("Invalid input, Column must be between 1 and 250");
                panel.Column = _ui.GetInt("Column");
            }
            panel.Material = (Material)1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.IsTracking = true;
            var loadedPanel = Service.LoadPanel(panel);

            if (loadedPanel.Row == 0)
            {
                _ui.Display("Could not find the requested panel.");
                _ui.Display("Press any key to continue");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            _ui.Display($"Editing {loadedPanel.Section}-{loadedPanel.Row}-{loadedPanel.Column}");
            _ui.Display("Press [Enter] to keep original value");
            _ui.Display("");
            
            Console.Write($"Section [{loadedPanel.Section}]: ");
            var enteredSection = Console.ReadLine();
            panel.Section = string.IsNullOrEmpty(enteredSection) ? loadedPanel.Section : enteredSection;

            Console.Write($"Row [{loadedPanel.Row}]: ");
            var enteredRow = Console.ReadLine();
            panel.Row = string.IsNullOrEmpty(enteredRow) ? loadedPanel.Row : _ui.ValidInt(enteredRow);
            while (panel.Row < 1 || panel.Row > 250)
            {
                _ui.Display("Invalid input, Row must be between 1 and 250");
                panel.Row = _ui.GetInt("Row");
            }

            Console.Write($"Column [{loadedPanel.Column}]: ");
            var enteredColumn = Console.ReadLine();
            panel.Column = string.IsNullOrEmpty(enteredColumn) ? loadedPanel.Column : _ui.ValidInt(enteredColumn);
            while (panel.Column < 1 || panel.Column > 250)
            {
                _ui.Display("Invalid input, Column must be between 1 and 250");
                panel.Column = _ui.GetInt("Column");
            }

            Console.Write($"Material[1-5] [{loadedPanel.Material}]: ");
            var enteredMaterial = Console.ReadLine();
            var materialInteger = string.IsNullOrEmpty(enteredMaterial) ? (int)loadedPanel.Material : _ui.ValidInt(enteredMaterial);
            while (materialInteger < 1 || materialInteger > 5)
            {
                _ui.Display("Invalid input, Material must be between 1 and 5");
                materialInteger = _ui.ValidInt(Console.ReadLine());
            }
            panel.Material = (Material)materialInteger;

            Console.Write($"Installation Year [{loadedPanel.YearInstalled:yyyy}]: ");
            var enteredYear = Console.ReadLine();
            panel.YearInstalled = string.IsNullOrEmpty(enteredYear) ? loadedPanel.YearInstalled : _ui.ValiDATE("1/1/" + enteredYear);

            Console.Write($"Tracked [{loadedPanel.IsTracking}] [y/n]: ");
            var enteredTracking = Console.ReadLine();
            panel.IsTracking = string.IsNullOrEmpty(enteredTracking) ? loadedPanel.IsTracking : enteredTracking.ToLower() == "y" ? true : false;

            _ui.Display(Service.Update(loadedPanel, panel) ? "Panel updated" : "Panel not updated");
            _ui.Display("Press any key to continue");
            Console.ReadLine();
        }

        public void RemovePanel()
        {
            Console.Clear();
            Panel panel = new();
            _ui.Display("Remove a Panel");
            _ui.Display("==============");
            _ui.Display("");
            Console.Write("Section: ");
            panel.Section = Console.ReadLine();
            while (string.IsNullOrEmpty(panel.Section))
            {
                _ui.Display("Section cannot be empty, please enter a section");
                panel.Section = Console.ReadLine();
            }

            panel.Row = _ui.GetInt("Row");
            while (panel.Row < 1 || panel.Row > 250)
            {
                _ui.Display("Invalid input, Row must be between 1 and 250");
                panel.Row = _ui.GetInt("Row");
            }

            panel.Column = _ui.GetInt("Column");
            while (panel.Column < 1 || panel.Column > 250)
            {
                _ui.Display("Invalid input, Column must be between 1 and 250");
                panel.Column = _ui.GetInt("Column");
            }
            panel.Material = (Material)1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.IsTracking = true;
            var loadedPanel = Service.LoadPanel(panel);

            if (string.IsNullOrEmpty(loadedPanel.ToString()))
            {
                _ui.Display("Could not find the requested panel.");
                _ui.Display("Press any key to continue");
                Console.ReadLine();
                return;
            }

            _ui.Display(Service.Remove(loadedPanel) ? $"Panel {loadedPanel.Section}-{loadedPanel.Row}-{loadedPanel.Column} removed" : "Panel not removed");
            _ui.Display("Press any key to continue");
            Console.ReadLine();
        }
    }
}
