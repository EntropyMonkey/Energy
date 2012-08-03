using UnityEngine;
using System.Collections;

public class CoalPowerplant : Building {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public override Type getBuildingType() 
	{
		return Type.CoalPowerplant;
	}
	
	public override Building applyUpgrade()
	{
		if (updateLevel == 1)
		{
			GameObject newBuilding = (GameObject)Instantiate(gameManager.Prefabs[1], transform.position, Quaternion.identity);
		}
		return null;
	}
}