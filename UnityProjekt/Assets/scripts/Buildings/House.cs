using UnityEngine;
using System.Collections;

public class House : Building {
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.Update();
	}
	
	public override Type getBuildingType() 
	{
		return Type.House;
	}
}
