using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows;

namespace Monitor2
{
    public class ConfigurationLoader
    {
        public UIStyle LoadUIConfiguration(string path)
        {
            try
            {
                UIStyle appStyle = new UIStyle();
                XDocument doc = XDocument.Load(path);

                var genData = (from item in doc.Descendants("GeneralStyle")
                               select new
                               {
                                   BaseColor = item.Element("BaseColor").Value,
                                   Color1 = item.Element("Color1").Value,
                                   Color2 = item.Element("Color2").Value,
                                   Color3 = item.Element("Color3").Value,
                                   Color4 = item.Element("Color4").Value
                               }).ToList();

                appStyle.GenStyleBaseColor = genData[0].BaseColor;
                appStyle.GenStyleColor1 = genData[0].Color1;
                appStyle.GenStyleColor2 = genData[0].Color2;
                appStyle.GenStyleColor3 = genData[0].Color3;
                appStyle.GenStyleColor4 = genData[0].Color4;

                var loadBarData = (from item in doc.Descendants("LoadBarStyle")
                                   select new
                                   {
                                       ColorVeryLow = item.Element("ColorVeryLow").Value,
                                       ColorLow = item.Element("ColorLow").Value,
                                       ColorMed = item.Element("ColorMed").Value,
                                       ColorHigh = item.Element("ColorHigh").Value,
                                       ColorVeryHigh = item.Element("ColorVeryHigh").Value
                                   }).ToList();

                appStyle.LoadBarStyleVeryLow = loadBarData[0].ColorVeryLow;
                appStyle.LoadBarStyleLow = loadBarData[0].ColorLow;
                appStyle.LoadBarStyleMed = loadBarData[0].ColorMed;
                appStyle.LoadBarStyleHigh = loadBarData[0].ColorHigh;
                appStyle.LoadBarStyleVeryHigh = loadBarData[0].ColorVeryHigh;

                return appStyle;
            }
            catch (FileNotFoundException fe)
            {
                MessageBox.Show("Configuration file not found" + Environment.NewLine + fe.Message);
                return new UIStyle();
            }
            catch (ArgumentOutOfRangeException ae)
            {
                MessageBox.Show("Wrong format of configuration file" + Environment.NewLine + ae.Message);
                return new UIStyle();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unexpected exception: " + e.Message);
                return new UIStyle();
            }
        }

    }
}