using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace RollABall
{
    public sealed class XMLData : IData<SavedData>
    {
        public void Save(SavedData player, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosX");
            element.SetAttribute("value", player.Position.X.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosY");
            element.SetAttribute("value", player.Position.Y.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosZ");
            element.SetAttribute("value", player.Position.Z.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsEnable");
            element.SetAttribute("value", player.IsEnabled.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " +
                                 Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(path);
        }

        public SavedData Load(string path = "")
        {
            var result = new SavedData();
            if (!File.Exists(path)) return result;
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Name";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }
                    key = "PosX";
                    if (reader.IsStartElement(key))
                    {
                        float.TryParse(reader.GetAttribute("value"), out result.Position.X);
                    }
                    key = "PosY";
                    if (reader.IsStartElement(key))
                    {
                        float.TryParse(reader.GetAttribute("value"), out result.Position.Y);
                    }
                    key = "PosZ";
                    if (reader.IsStartElement(key))
                    {
                        float.TryParse(reader.GetAttribute("value"), out result.Position.Z);
                    }
                    key = "IsEnable";
                    if (reader.IsStartElement(key))
                    {
                        bool.TryParse(reader.GetAttribute("value"), out result.IsEnabled);
                    }
                }
            }
            return result;
        }

        public void SaveArr(SavedData[] data, string path = null)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Bonuses");
            xmlDoc.AppendChild(rootNode);

            for (int i = 0; i < data.Length; i++)
            {
                var Name = xmlDoc.CreateElement("Name");
                Name.SetAttribute("value", data[i].Name);
                rootNode.AppendChild(Name);

                var PosX = xmlDoc.CreateElement("PosX");
                PosX.SetAttribute("PosX", data[i].Position.X.ToString());
                Name.AppendChild(PosX);

                var PosY = xmlDoc.CreateElement("PosY");
                PosY.SetAttribute("PosY", data[i].Position.Y.ToString());
                Name.AppendChild(PosY);

                var PosZ = xmlDoc.CreateElement("PosZ");
                PosZ.SetAttribute("PosZ", data[i].Position.Z.ToString());
                Name.AppendChild(PosZ);

                var IsEnable = xmlDoc.CreateElement("IsEnable");
                IsEnable.SetAttribute("IsEnable", data[i].IsEnabled.ToString());
                Name.AppendChild(IsEnable);
            }
            xmlDoc.Save(path);
        }

        public Dictionary<string, SavedData> LoadArr(string path = null)
        {
            var bonuses = new Dictionary<string, SavedData>();
            if (!File.Exists(path)) return bonuses;

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement xRoot = xml.DocumentElement;

            SavedData result;
            string name = string.Empty;

            foreach (XmlNode xnode in xRoot)
            {
                result = new SavedData();
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("value");
                    name = attr.Value;
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name.Equals("PosX"))
                    {
                        float.TryParse(childnode.Attributes.GetNamedItem("PosX").Value, out result.Position.X);
                    }
                    if (childnode.Name.Equals("PosY"))
                    {
                        float.TryParse(childnode.Attributes.GetNamedItem("PosY").Value, out result.Position.Y);
                    }
                    if (childnode.Name.Equals("PosZ"))
                    {
                        float.TryParse(childnode.Attributes.GetNamedItem("PosZ").Value, out result.Position.Z);
                    }
                    if (childnode.Name.Equals("IsEnable"))
                    {
                        bool.TryParse(childnode.Attributes.GetNamedItem("IsEnable").Value, out result.IsEnabled);
                    }
                }
                bonuses.Add(name, result);
            }
            return bonuses;
        }
    }
}
