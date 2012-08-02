using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A building placed by the user.
/// </summary>
public abstract class Building : MonoBehaviour
{
    public enum ResourceType { Energy, Work, Pollution };
	public enum Type { House, NuclearPowerplant, CoalPowerplant, WaterPowerplant, 
		SolarPowerplant, BioPowerplant, WindPowerplant, FusionPowerplant,
		PumpedStoragePowerStation, FuelCell, Battery, Forest, Ionizer, NuclearRepository };
	
    #region Vars

    protected Tile tileRef;
	protected bool enabled;
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
		float[] Efficiency = new float[3]; //Effizienz werte 0...2 Energy, Work, Pollution
		
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(uex, uey);
		Tile currentTile = ma.GetTileFromPosition(uex, uey);
		
		for(int i=0; i<=1; i++)
		{
			if(i == 0) // Berechnung der Energy Effizienz
			{
				//switch(currentTile.CurrentBuilding
				
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
			}
			else if(i == 1) // Berechnung der Work Effizienz
			{
				
			}
		}
		
		return Efficiency;
	}
	public void updateOutput(int daniX, int daniY)
	{
        float[] ufreturn;
        float flEnergy;
        float flWork;
        float flPollution;
        double daytime;
		float acttime = (float)gameManager.InGameTime; //In Minutes

        ufreturn = updateEfficiency(daniX, daniY);
        daytime = -0.5 * System.Math.Cos ((double)System.Math.PI / 720 * (acttime - 120)) + 1 + System.Math.Sin (0.01 * acttime);

        flEnergy = Output[ResourceType.Energy] * ufreturn[0];
        flEnergy = flEnergy * (float)daytime;
        flWork = Output[ResourceType.Work] * ufreturn[1];
		flWork = flWork * (float)daytime;
        flPollution =Output[ResourceType.Pollution];
        
        
        CurrentOutput[ResourceType.Energy] = flEnergy;
        CurrentOutput[ResourceType.Work] = flWork;
        CurrentOutput[ResourceType.Pollution] = flPollution;
	}
	
	public void updateInput()
	{
        
	}
	
	public abstract Type getBuildingType();
	
	


}
