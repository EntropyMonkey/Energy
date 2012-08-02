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
    protected Dictionary<ResourceType, float> Input;
    protected Dictionary<ResourceType, float> Output;
    protected Dictionary<ResourceType, float> CurrentInput;
    protected Dictionary<ResourceType, float> CurrentOutput;
     
	public List<Upgrade> Upgrades;

    #endregion
	
	// Use this for initialization
	void Start () 
    {
        Input = new Dictionary<ResourceType, float>();
        Output = new Dictionary<ResourceType, float>();
        CurrentInput = new Dictionary<ResourceType, float>();
        CurrentOutput = new Dictionary<ResourceType, float>();
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
	}
	
	void Update()
	{
		
	}
	
	public void updatePollution()
	{
	}
	
	public float[] updateEfficiency(int uex, int uey)
	{
		float[] Efficiency = new float[3]; //Effizienz werte 0...2 , Work, Pollution
		
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(uex, uey);
		Tile currentTile = ma.GetTileFromPosition(uex, uey);
		
		for(int i=0; i<=1; i++)
		{
			if(i == 0) // Berechnung der Power Effizienz
			{
				switch(currentTile.CurrentBuilding.Type)
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
	
	public void updateOutput(int inX, int inY)
	{
        float[] ufreturn = updateEfficiency(inX, inY);
        float flPower = Output[ResourceType.Power] * ufreturn[0];
        float flWork = Output[ResourceType.Work] * ufreturn[1];
        float flPollution = Output[ResourceType.Pollution];
        //double daytime = -0.5 * System.Math.Cos (Math.PI / 720.0 * (Convert.ToDouble(gameManager.InGameTime) - 120)) + 1 + System.Math.Sin (0.01 * Convert.ToDouble(gameManager.InGameTime));
        
        CurrentOutput[ResourceType.Power] = flPower;
        CurrentOutput[ResourceType.Work] = flWork;
        CurrentOutput[ResourceType.Pollution] = flPollution;
	}
	
	public void updateInput(int inX, int inY)
	{
        float[] ufreturn = updateEfficiency(inX, inY);
        float flPower = Input[ResourceType.Power] * ufreturn[0];
        float flWork = Input[ResourceType.Work] * ufreturn[1];
        float flPollution = Output[ResourceType.Pollution];
        
        
        CurrentInput[ResourceType.Power] = flPower;
        CurrentInput[ResourceType.Work] = flWork;
        CurrentInput[ResourceType.Pollution] = flPollution;
	}
	
	public abstract Type getBuildingType();
}
