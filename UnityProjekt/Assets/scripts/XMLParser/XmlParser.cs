using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

namespace XMLParser
{
	public class Parser
	{	
		public List<Building> Buildings;
		
		public Parser (string filePath)
		{
			Buildings = new List<Building>();
			
			using (XmlReader reader = XmlReader.Create(filePath))
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element
					    && reader.Name.ToLower() == "buildings")
					{
						readBuildings(reader.ReadSubtree());
					}
				}
				
				/*foreach (Building building in buildings)
				{
					Console.WriteLine(building.Name);
					Console.WriteLine("\t" + building.Prefab);
					
					foreach (Upgrade upgrade in building.Upgrades)
					{
						Console.WriteLine("\t\t" + upgrade.Name);
						
						Console.WriteLine("\t\t\t" + upgrade.Values.getProperty("capacity"));
					}
				}*/
			}
		}
		
		private void readBuildings (XmlReader inReader)
		{
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element
					&& inReader.Name.ToLower() == "building")
				{
					readBuilding(inReader.ReadSubtree());
				}
			}
		}
		
		private void readBuilding (XmlReader inReader)
		{
			Building building = new Building();
			
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					switch (inReader.Name.ToLower())
					{
						case "name":
							building.Name = inReader.ReadElementString();
							break;
						case "identifier":
							building.Identifier = inReader.ReadElementString();
							break;
						case "type":
							switch (inReader.ReadElementString().ToLower())
							{
								case "pollutionreducer":
									building.Type = BuildingTypes.PollutionReducer;
									break;
								case "powerplant":
									building.Type = BuildingTypes.Powerplant;
									break;
								case "house":
									building.Type = BuildingTypes.House;
									break;
								case "storage":
									building.Type = BuildingTypes.Storage;
									break;
							}
							break;
						case "properties":
							readProperties(inReader.ReadSubtree(), building.Values);
							break;
						case "active":
							readActive(inReader.ReadSubtree(), building.Values);
							break;
						case "passive":
							readPassive(inReader.ReadSubtree(), building.Values);
							break;
						case "construct":
							readConstruct(inReader.ReadSubtree(), building.Values);
							break;
						case "upgrades":
							readUpgrades(inReader.ReadSubtree(), building);
							break;
					}
				}
			}
			
			if (building.isValid()) Buildings.Add(building);
		}
		
		private void readProperties (XmlReader inReader, ValueGroup inValues)
		{
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					if (inReader.Name.ToLower() == "item") 
					{
						try
						{
							inValues.addProperty(inReader.GetAttribute("type"),
								Convert.ToDouble(inReader.GetAttribute("value")));
						}
						catch (FormatException)
						{
							Console.WriteLine("Value has invalid type.");
						}
					}
				}
			}
		}
		
		private void readActive (XmlReader inReader, ValueGroup inValues)
		{
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					if (inReader.Name.ToLower() == "item") 
					{
						try
						{
							inValues.addActive(inReader.GetAttribute("type"),
								Convert.ToDouble(inReader.GetAttribute("value")));
						}
						catch (FormatException)
						{
							Console.WriteLine("Value has invalid type.");
						}
					}
				}
			}
		}
		
		private void readPassive (XmlReader inReader, ValueGroup inValues)
		{
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					if (inReader.Name.ToLower() == "item") 
					{
						try
						{
							inValues.addPassive(inReader.GetAttribute("type"),
								Convert.ToDouble(inReader.GetAttribute("value")));
						}
						catch (FormatException)
						{
							Console.WriteLine("Value has invalid type.");
						}
					}
				}
			}
		}
		
		private void readConstruct (XmlReader inReader, ValueGroup inValues)
		{
			inReader.Read();
			
			try
			{
				inValues.ConstructTime = Convert.ToInt32(inReader.GetAttribute("time"));
			}
			catch (FormatException)
			{
				Console.WriteLine("Construct time has invalid type.");
			}
			
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					if (inReader.Name.ToLower() == "item") 
					{
						try
						{
							inValues.addConstruct(inReader.GetAttribute("type"),
								Convert.ToDouble(inReader.GetAttribute("value")));
						}
						catch (FormatException)
						{
							Console.WriteLine("Value has invalid type.");
						}
					}
				}
			}
		}
		
		private void readUpgrades (XmlReader inReader, Building inBuilding)
		{
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element
					&& inReader.Name.ToLower() == "upgrade")
				{
					readUpgrade(inReader.ReadSubtree(), inBuilding);
				}
			}
		}
		
		private void readUpgrade (XmlReader inReader, Building inBuilding)
		{
			Upgrade upgrade = new Upgrade();
			
			while (inReader.Read())
			{
				if (inReader.NodeType == XmlNodeType.Element)
				{
					switch (inReader.Name.ToLower())
					{
						case "name":
							upgrade.Name = inReader.ReadElementString();
							break;
						case "properties":
							readProperties(inReader.ReadSubtree(), upgrade.Values);
							break;
						case "active":
							readActive(inReader.ReadSubtree(), upgrade.Values);
							break;
						case "passive":
							readPassive(inReader.ReadSubtree(), upgrade.Values);
							break;
						case "construct":
							readConstruct(inReader.ReadSubtree(), upgrade.Values);
							break;
					}
				}
			}
			
			inBuilding.Upgrades.Add(upgrade);
		}
	}
}

