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
	
    #region Vars

    protected Tile tileRef;
	protected bool isEnabled;
    protected GameManager gameManager;
    protected Dictionary<ResourceType, float> input;
    protected Dictionary<ResourceType, float> output;
    protected Dictionary<ResourceType, float> currentInput;
    protected Dictionary<ResourceType, float> currentOutput;
     
	public List<Upgrade> Upgrades;

    #endregion
	
	// Use this for initialization
	void Start () 
    {
        input = new Dictionary<ResourceType, float>();
        output = new Dictionary<ResourceType, float>();
        currentInput = new Dictionary<ResourceType, float>();
        currentOutput = new Dictionary<ResourceType, float>();
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	void Update()
	{
		
	}
	
	public void updatePollution()
	{
	}
	
	public float[] updateEfficiency()
	{
		float[] Efficiency = new float[3]; //Effizienz werte 0...2 , Work, Pollution
		
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		Tile currentTile = ma.GetTileFromPosition(Convert.ToInt32(tileRef.Coords.x), Convert.ToInt32(tileRef.Coords.y));
		
		for(int i=0; i<=1; i++)
		{
			if(i == 0) // Berechnung der Power Effizienz
			{
				switch(currentTile.CurrentBuilding.getBuildingType())
				{
					
				case Type.WaterPowerplant:	
					
					switch(currentTile.Type)
					{
					case TileType.Desert:
						break;
							
					case TileType.Grassland:
						break;
						
					case TileType.Mountain:
						break;
						
					case TileType.River:
						break;
						
					case TileType.Sea:
						break;
					}
					
					break;
					
				case Type.WindPowerplant:
					break;
					
				case Type.BioPowerplant:
					break;
					
				case Type.SolarPowerplant:
					break;
						
				}
				
			}
			else if(i == 1) // Berechnung der Work Effizienz
			{
				
			}
		}
		
		return Efficiency;
	}
	
	public Dictionary<ResourceType, float> updateOutput()
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
	}
	
	public abstract Type getBuildingType();
}
