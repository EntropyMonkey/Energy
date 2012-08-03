using UnityEngine;
using System.Collections;

public class SolarPowerplant : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.SolarPowerplant;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
