using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A building placed by the user.
/// </summary>
public abstract class Building : MonoBehaviour
{
    public enum ResourceType { Power, Work, Pollution };
	public enum Type { House, NuclearPowerplant, CoalPowerplant, WaterPowerplant, 
		SolarPowerplant, BioPowerplant, WindPowerplant, FusionPowerplant,
		PumpedStoragePowerStation, FuelCell, Battery, Forest, Ionizer, NuclearRepository };
	
    public Tile tileRef;
	protected bool isEnabled;
    protected GameManager gameManager;
    public Dictionary<ResourceType, float> currentValues;
    //public Dictionary<ResourceType, float> currentOutput;

	public List<Upgrade> Upgrades;
	
	public int updateLevel
	{
		get;
		protected set;
	}

	public bool IsEnabled
	{
		get;
		set;
	}
	
	// Use this for initialization
	void Start () 
    {
        currentValues = new Dictionary<ResourceType, float>();
		
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	void Update()
	{
		this.updatePollution();
	}
	
	public void updatePollution()
	{
		tileRef.Pollution += currentValues[ResourceType.Pollution] * Time.deltaTime;
	}
	
	public float updateEfficiency() //Effizienz werte 0...2 , Work, Pollution
	{
		double Efficiency = 0.5;
		double CurrentTileEfficiency = 0;
		bool[] Surroundings = new bool[3]; // 0 = Gewässer in der nähe, 1 = Gebirge in der Nähe, 2 = ThermischesKW in der Nähe
		
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		Tile currentTile = ma.GetTileFromPosition(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		
		//auslesen der Standorttyp grundeffizienz
		switch(currentTile.Type)
		{
		case TileType.Desert:
			CurrentTileEfficiency += gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effDesert");
			break;
				
		case TileType.Grassland:
			CurrentTileEfficiency += gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effDGrassland");
			break;
			
		case TileType.Mountain:
			CurrentTileEfficiency += gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effMountain");
			break;
			
		case TileType.River:
			CurrentTileEfficiency += gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effRiver");
			break;
			
		case TileType.Sea:
			CurrentTileEfficiency += gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effSea");
			break;
		}

		//auslesen der umgebung
		for(int i=0; i<=7; i++)
		{
			switch(tilelist[i].CurrentBuilding.getBuildingType())
			{
				case Type.CoalPowerplant:
				case Type.NuclearPowerplant:
				case Type.BioPowerplant:
				case Type.FusionPowerplant:
				case Type.Forest:
					if(currentTile.CurrentBuilding.getBuildingType() == Type.House || currentTile.CurrentBuilding.getBuildingType() == Type.Forest )
					{
						Efficiency = CurrentTileEfficiency + gameManager.Buildings[0].Values.getProperty("effThermic");
					}
				break;
			}
		}
		
		//hier kommt die umgebungsberechnung
		
		
		//return Efficiency;
		return 1;
	}
	
	public abstract Type getBuildingType();
	
	protected void updateValues()
	{
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		Tile currentTile = ma.GetTileFromPosition(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		
		float ufreturn = updateEfficiency();
		XMLParser.ValueGroup values = gameManager.Buildings[(int)getBuildingType()].Values;
		//currentValues.Clear();
		
		//currentValues.Add(ResourceType.Power, 0);
		//currentValues.Add(ResourceType.Work, 0);
		//currentValues.Add(ResourceType.Pollution, 0);
		
		//currentValues[ResourceType.Power] += values.getPassive("power");
		//currentValues[ResourceType.Work] += values.getPassive("work");
		//currentValues[ResourceType.Pollution] += values.getPassive("pollution");
		
		//if (isEnabled)
		//{
		//    currentValues[ResourceType.Power] += values.getActive("power");
		//    currentValues[ResourceType.Work] += values.getActive("work");
		//    currentValues[ResourceType.Pollution] += values.getActive("pollution");
		//}
		
		// FIXME: Upgrades
		if(currentTile.CurrentBuilding.getBuildingType() == Type.House)
		{
			currentValues[ResourceType.Work] *= ufreturn;
		}
		else
		{
		currentValues[ResourceType.Power] *= ufreturn;
		}
		
	}
	
	public abstract Building applyUpgrade();
}
