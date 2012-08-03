using UnityEngine;
using System.Collections;

public class WaterPowerplant : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.WaterPowerplant;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
