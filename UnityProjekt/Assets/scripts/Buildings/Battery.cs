using UnityEngine;
using System.Collections;

public class Battery : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.Battery;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
