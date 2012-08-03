using UnityEngine;
using System.Collections;

public class CoalPowerplant : Building 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonUp(0))
			applyUpgrade();
	}
	
	public override Type getBuildingType() 
	{
		return Type.CoalPowerplant;
	}
	
	public override void applyUpgrade()
	{
		Debug.Log(gameObject.GetComponent<MeshFilter>().mesh);
	}
}
