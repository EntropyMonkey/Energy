using UnityEngine;
using System.Collections;

public class FuelCell : Storage {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.FuelCell;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
