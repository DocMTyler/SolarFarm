using System;
using System.IO;
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

        public void Setup()
        {
            _ui.Display(Directory.GetCurrentDirectory());
            _ui.Display("Press any key to continue");
            Console.ReadKey();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                switch (GetMenuChoice())
                {
                    case 1:
                        ViewPanelInfo();
                        break;
                    case 2:
                        ViewAllPanels();
                        break;
                    case 3:
                        AddPanel();
                        break;
                    case 4:
                        EditPanel();
                        break;
                    case 5:
                        RemovePanel();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        _ui.Display("Invalid input. Please enter a number 1 - 7");
                        break;
                }
            }
        }

        public int GetMenuChoice()
        {
            DisplayMenu();
            bool isValid = int.TryParse(Console.ReadLine(), out int output);
            while (!isValid)
            {
                _ui.Display("Invalid entry, enter a number 1 - 7");
                isValid = int.TryParse(Console.ReadLine(), out output);
            }
            return output;
        }

        public void DisplayMenu()
        {
            _ui.Display("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            _ui.Display("Main Menu");
            _ui.Display("=========");
            _ui.Display("1. Load Panel Info");
            _ui.Display("2. View All Panels");
            _ui.Display("3. Add a Panel");
            _ui.Display("4. Edit a Panel");
            _ui.Display("5. Delete a Panel");
            _ui.Display("6. Quit");
            _ui.Display("Please enter a selection 1 - 7");
        }

        public void ViewPanelInfo()
        {
            _ui.Display("Viewing Panel");
        }

        public void ViewAllPanels()
        {
            _ui.Display("Viewing all Panels");
        }

        public void AddPanel()
        {
            _ui.Display("Adding Panel");
        }

        public void EditPanel()
        {
            _ui.Display("Editing Panel");
        }

        public void RemovePanel()
        {
            _ui.Display("Removing Panel");
        }
    }
}
