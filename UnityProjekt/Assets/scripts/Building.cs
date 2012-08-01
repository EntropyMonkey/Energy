using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {
	
	protected Tile tileRef;
	protected bool enabled;
	protected Dictionary<ResourceType, float> Input = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> Output = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentInput = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentOutput = 
            new Dictionary<string, float>();
	protected List<Upgrade> Upgrades;
	
	// Use this for initialization
	void Start () {
	}
	
	#region Properties
	
	protected bool isEnabled;
	public bool IsEnabled
	{
		get;
		set;
	}	
	
	public void updatePollution(){
	}
	public float updateEfficiency(){
	}
	public void updateOutput(){
		Output = Output * Efficiency;
	}
	public void updateInput(){
	}
	
	#endregion
	
	public Building(int ID, Vector2 tile)
	{
		
	}
}
