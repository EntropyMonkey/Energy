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
    public Dictionary<ResourceType, double> currentValues;
    //public Dictionary<ResourceType, float> currentOutput;

	public List<Upgrade> Upgrades;

	public bool IsEnabled
	{
		get;
		set;
	}
	
	// Use this for initialization
	void Start () 
    {
        currentValues = new Dictionary<ResourceType, double>();
		
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	void Update()
	{
		this.updatePollution();
	}
	
	public void updatePollution()
	{
		tileRef.Pollution += this.currentValues[ResourceType.Pollution] * (double)Time.deltaTime;
	}
	
	public float[] updateEfficiency()
	{
		float[] Efficiency = new float[3]; //Effizienz werte 0...2 , Work, Pollution
		double CurrentTileEfficiency;
		
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		Tile currentTile = ma.GetTileFromPosition(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		
		for(int i=0; i<=1; i++)
		{
			if(i == 0) // Berechnung der Power Effizienz
			{
				//switch(currentTile.CurrentBuilding.getBuildingType())
				switch(currentTile.Type)
				{
				case TileType.Desert:
					CurrentTileEfficiency = gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effDesert");
					break;
						
				case TileType.Grassland:
					CurrentTileEfficiency = gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effDGrassland");
					break;
					
				case TileType.Mountain:
					CurrentTileEfficiency = gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effMountain");
					break;
					
				case TileType.River:
					CurrentTileEfficiency = gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effRiver");
					break;
					
				case TileType.Sea:
					CurrentTileEfficiency = gameManager.Buildings[(int)currentTile.CurrentBuilding.getBuildingType()].Values.getProperty("effSea");
					break;
				}
			}
			else if(i == 1) // Berechnung der Work Effizienz
			{
				
			}
		}
		
		
		
		
		return Efficiency;
	}
	
	
	/*public Dictionary<ResourceType, float> updateOutput()
	{
        float[] ufreturn = updateEfficiency();
        float flPower = output[ResourceType.Power] * ufreturn[0];
        float flWork = output[ResourceType.Work] * ufreturn[1];
        float flPollution = output[ResourceType.Pollution];
        //double daytime = -0.5 * System.Math.Cos (Math.PI / 720.0 * (Convert.ToDouble(gameManager.InGameTime) - 120)) + 1 + System.Math.Sin (0.01 * Convert.ToDouble(gameManager.InGameTime));
        
        currentOutput[ResourceType.Power] = flPower;
        currentOutput[ResourceType.Work] = flWork;
        currentOutput[ResourceType.Pollution] = flPollution;
		
		return currentOutput;
	}
	
	public Dictionary<ResourceType, float> updateInput()
	{
        float[] ufreturn = updateEfficiency();
        float flPower = input[ResourceType.Power] * ufreturn[0];
        float flWork = input[ResourceType.Work] * ufreturn[1];
        float flPollution = input[ResourceType.Pollution];
        
        
        currentInput[ResourceType.Power] = flPower;
        currentInput[ResourceType.Work] = flWork;
        currentInput[ResourceType.Pollution] = flPollution;
		
		return currentInput;
	}*/
	
	public abstract Type getBuildingType();
	
	protected void updateValues()
	{
		float[] ufreturn = updateEfficiency();
		XMLParser.ValueGroup values = gameManager.Buildings[(int)getBuildingType()].Values;
		
		currentValues.Clear();
		
		currentValues.Add(ResourceType.Power, 0);
		currentValues.Add(ResourceType.Work, 0);
		currentValues.Add(ResourceType.Pollution, 0);
		
		currentValues[ResourceType.Power] += values.getPassive("power");
		currentValues[ResourceType.Work] += values.getPassive("work");
		currentValues[ResourceType.Pollution] += values.getPassive("pollution");
		
		if (isEnabled)
		{
			currentValues[ResourceType.Power] += values.getActive("power");
			currentValues[ResourceType.Work] += values.getActive("work");
			currentValues[ResourceType.Pollution] += values.getActive("pollution");
		}
		
		// FIXME: Upgrades
		
		currentValues[ResourceType.Power] *= ufreturn[0];
		currentValues[ResourceType.Work] *= ufreturn[1];
	}
}
