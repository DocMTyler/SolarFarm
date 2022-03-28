using NUnit.Framework;
using SolarFarm.BLL;
using SolarFarm.DAL;
using SolarFarm.Core.DTO;
using System;


namespace SolarFarm.Tests
{
    public class Tests
    {
        static PanelRepository repo = new();
        PanelService service = new(repo);

        [Test]
        public void AddServiceReturnsTrue()
        {
            Panel panel = new();
            panel.Section = "North";
            panel.Row = 1;
            panel.Column = 1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.Material = (Material)4;
            panel.IsTracking = true;

            Assert.IsTrue(service.Add(panel));
        }

        [Test]
        public void RemoveServiceReturnsFalse()
        {
            Panel panel = new();
            panel.Section = "North";
            panel.Row = 3;
            panel.Column = 1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.Material = (Material)4;
            panel.IsTracking = true;

            Assert.IsFalse(service.Remove(panel));
        }

        [Test]
        public void UpdateServiceReturnsTrue()
        {
            Panel panel1 = new();
            panel1.Section = "North";
            panel1.Row = 1;
            panel1.Column = 1;
            panel1.YearInstalled = DateTime.Parse("1/1/2020");
            panel1.Material = (Material)4;
            panel1.IsTracking = true;

            Panel panel2 = new();
            panel2.Section = "North";
            panel2.Row = 1;
            panel2.Column = 1;
            panel2.YearInstalled = DateTime.Parse("1/1/2020");
            panel2.Material = (Material)2;
            panel2.IsTracking = true;

            Assert.IsTrue(service.Update(panel1, panel2));
        }

        [Test]
        public void AddRepoReturnsTrue()
        {
            Panel panel = new();
            panel.Section = "North";
            panel.Row = 2;
            panel.Column = 1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.Material = (Material)4;
            panel.IsTracking = true;

            Assert.IsTrue(service.Add(panel));
        }

        [Test]
        public void RemoveRepoReturnsFalse()
        {
            Panel panel = new();
            panel.Section = "North";
            panel.Row = 3;
            panel.Column = 1;
            panel.YearInstalled = DateTime.Parse("1/1/2020");
            panel.Material = (Material)4;
            panel.IsTracking = true;

            Assert.IsFalse(service.Remove(panel));
        }

        [Test]
        public void UpdateRepoReturnsTrue()
        {
            Panel panel1 = new();
            panel1.Section = "North";
            panel1.Row = 1;
            panel1.Column = 1;
            panel1.YearInstalled = DateTime.Parse("1/1/2020");
            panel1.Material = (Material)4;
            panel1.IsTracking = true;

            Panel panel2 = new();
            panel2.Section = "North";
            panel2.Row = 1;
            panel2.Column = 1;
            panel2.YearInstalled = DateTime.Parse("1/1/2020");
            panel2.Material = (Material)2;
            panel2.IsTracking = true;

            Assert.IsTrue(service.Update(panel1, panel2));
        }
    }
}