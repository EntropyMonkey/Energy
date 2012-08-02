using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A building placed by the user.
/// </summary>
public class Building : MonoBehaviour
{
    public enum ResourceType { Energy, Work, Pollution };
    #region Vars

    protected Tile tileRef;
	protected bool enabled;

    protected Dictionary<ResourceType, float> Input;
    protected Dictionary<ResourceType, float> Output;
    protected Dictionary<ResourceType, float> CurrentInput;
    protected Dictionary<ResourceType, float> CurrentOutput;
     
	protected List<Upgrade> Upgrades;

    #endregion
	
	// Use this for initialization
	void Start () 
    {
        Input = new Dictionary<ResourceType, float>();
        Output = new Dictionary<ResourceType, float>();
        CurrentInput = new Dictionary<ResourceType, float>();
        CurrentOutput = new Dictionary<ResourceType, float>();
	}
	
	#region Properties
	
	public bool IsEnabled
	{
		get;
		set;
	}	
	
	void Update()
	{
		
	}
	
	public void updatePollution()
	{
	}
	
	public float[] updateEfficiency(int uex, int uey)
	{
		int[] Efficiency = new int[3]; //Effizienz werte 0...2 Energy, Work, Pollution
		Map ma = GameObject.Find("Map").GetComponent<Map>();
		List<Tile> tilelist = ma.GetEnvironmentTiles(uex, uey);
		Tile currenttile = ma.GetTileFromPosition(uex, uey);
		int currentTileType
		
		for(int i=0; i<=1; i++)
		{
			if(i == 0) // Berechnung der Energy Effizienz
			{
				
			}
			else if(i == 1) // Berechnung der Work Effizienz
			{
				
			}
		}
		
		return Efficiency;
	}
	public void updateOutput(int daniX, int daniY)
	{
        float flEnergy;
        float flWork;
        float flPollution;
        /*****I don't know if this function exists*****
        flEnergy = XMLParser.XMLValueGroup.getProperty("energy") * UpdateEfficiency(daniX, daniY);
        flWork = XMLParser.XMLValueGroup.getProperty("work") * UpdateEfficiency(daniX, daniY);
        flPollution = XMLParser.XMLValueGroup.getProperty("pollution");
        */
        
        Output.Add(ResourceType.Energy, flEnergy);
        Output.Add(ResourceType.Work, flWork);
        Output.Add(ResourceType.Pollution, flPollution);
	}
	
	public void updateInput()
	{
        
	}
	
	#endregion

}
