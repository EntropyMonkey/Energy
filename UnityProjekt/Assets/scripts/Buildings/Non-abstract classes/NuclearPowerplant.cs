using UnityEngine;
using System.Collections;

public class NuclearPowerplant : Powerplant {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.NuclearPowerplant;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
