using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
	Camera mainCamera;
	GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;

			if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
			{
				HandleMouseClick(hit);
			}
		}
	}

	void HandleMouseClick(RaycastHit hit)
	{
		Building building = hit.collider.gameObject.GetComponent<Building>();

		if (building)
		{
			CreateBuildingMenu(building.getBuildingType(), 
				mainCamera.WorldToScreenPoint(building.transform.position));
		}

		Tile tile = hit.collider.gameObject.GetComponent<Tile>();
		if (tile)
		{
			CreateTileMenu(mainCamera.WorldToScreenPoint(tile.transform.position));
			tile.Build(0);
		}
	}

	void CreateBuildingMenu(Building.Type type, Vector3 position)
	{
		Debug.Log("created building menu " + type + " at " + position);
	}

	void CreateTileMenu(Vector3 position)
	{
		Debug.Log("created tile menu at " + position);
	}
};