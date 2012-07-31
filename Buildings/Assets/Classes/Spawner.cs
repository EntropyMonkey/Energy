using UnityEngine;
using System.Collections;

/// <summary>
/// The spawner class acts as the frontend to the building class.
/// It provides mechanics to display the buildings that are linked here.
/// </summary>
public class Spawner : MonoBehaviour {
	
	
	// Source prefabs for the buildings. Prefabs are set using the Unity GUI.
	public Transform[] meshes = new Transform[4];
	
	
	/// <summary>
	/// Spawn the specified building at a specified position.
	/// </summary>
	/// <param name='buildingID'>
	/// The ID of the building.
	/// </param>
	/// <param name='position'>
	/// The position of the building on the map in the form (x,z)
	/// </param>
	public Transform spawn(int buildingID, Vector2 position)
	{
		return (Transform)Instantiate(meshes[buildingID], new Vector3(position.x, 0, position.y), Quaternion.identity);
	}
	
	
	
	
	
	
}
