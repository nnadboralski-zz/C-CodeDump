using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace hp_tac_concentra2mm
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(args[0]))
            {
                XDocument xd = XDocument.Load(args[0]);
                var nodes = from node in xd.Descendants("node")
                            let ID = node.Attribute("ID").Value where ID != null
                            let ProductLine = node.Attribute("Productline") ?? String.Empty where ProductLine != null 
                            let ShowCheckBox = node.Attribute("ShowCheckBox") where ShowCheckBox != null
                            select new
                            {
                                ID = node.Attribute("ID").Value,
                                ShowCheckBox = node.Attribute("ShowCheckBox").Value,
                                ProductLine = node.Attribute("Productline").Value ?? String.Empty
                            };


                foreach (var node in nodes)
                {
                    //Console.WriteLine("\nTemplate - " + node.Template + "\nText - " + node.Text + "\nID - " + node.ID + "\nEndLevel2Code - " + node.EndLevel2Code + "\nDoc_Link - " + node.Doc_Link);
                    Console.WriteLine("\nSCB: " + node.ShowCheckBox + node.ProductLine);
                    /*if (node.ShowCheckBox == "true")
                    {
                        Console.WriteLine("Error!");
                        var nodedata = (from node1 in xd.Descendants("node") where node1.Attribute("ID").Value.Equals(node.ID) select node1).Single();
                        nodedata.Attribute("ShowCheckBox").Value = "This showcheckbox was automatically changed.";
                    }*/
                }
                // xd.Save("Test.xml");
                Console.ReadKey();
            }
        }
    }
}
