using UnityEngine;
using System.Collections;

public class Ionizer : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.Ionizer;
	}
}
