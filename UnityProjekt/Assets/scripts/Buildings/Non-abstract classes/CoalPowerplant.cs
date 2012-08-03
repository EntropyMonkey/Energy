using UnityEngine;
using System.Collections;

public class CoalPowerplant : Powerplant {

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
		Building result;
		if (upgradeLevel == 1)
		{
			GameObject newBuilding = (GameObject)Instantiate(gameManager.Prefabs[1], transform.position, Quaternion.identity);
			result = newBuilding.GetComponent<Building>();
			result.upgradeLevel = 2;
		}
		else
		{
			GameObject newBuilding = (GameObject)Instantiate(gameManager.Prefabs[2], transform.position, Quaternion.identity);
			result = newBuilding.GetComponent<Building>();
			result.upgradeLevel = 3;
		}
		
		return result;
	}
}