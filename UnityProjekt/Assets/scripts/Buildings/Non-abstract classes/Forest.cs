using UnityEngine;
using System.Collections;

public class Forest : PollutionReducer {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.Forest;
	}
	
	public override Building applyUpgrade()
	{
		return null;
	}
}
