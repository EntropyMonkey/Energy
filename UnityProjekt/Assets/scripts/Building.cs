using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A building placed by the user.
/// </summary>
public class Building : MonoBehaviour
{

    #region Vars

    protected Tile tileRef;
	protected bool enabled;
	/*
    protected Dictionary<ResourceType, float> Input = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> Output = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentInput = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentOutput = 
            new Dictionary<string, float>();
     */
	protected List<Upgrade> Upgrades;

    #endregion
	
	// Use this for initialization
	void Start () {
	}
	
	#region Properties
	
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

}
