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
	}
	
	public override Type getBuildingType() 
	{
		return Type.House;
	}
	
	public override void applyUpgrade()
	{
		
	}
}
