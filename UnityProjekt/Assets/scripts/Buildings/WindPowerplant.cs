using UnityEngine;
using System.Collections;

public class WindPowerplant : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.WindPowerplant;
	}
	
	public override void applyUpgrade()
	{
		
	}
}
