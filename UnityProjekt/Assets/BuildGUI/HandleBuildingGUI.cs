using UnityEngine;
using System.Collections;
public class HandleBuildingGUI : MonoBehaviour 
{
	#region PUBLIC_AND_PRIVATE_DECLARATION
	public Texture powerPlantsTexture, pollutionReducerTexture, storagesTexture, menuBackground, menuItemBG;
	public Texture[] ppbTextures;
	public Texture[] prbTextures;
	public Texture[] sbTextures;
	public Texture hbTexture;
	public string[] labels; 
	public Rect menuPosition;
	
	private Rect[] ppbPositions, prbPositions, sbPositions;
	private Rect hbPosition;
	private bool mouseButtonDown, ppbMenuOn, prbMenuOn, sbMenuOn;
	private float scaleFactorX, scaleFactorY, rad_max;
	private int rad_action, rad_factor;
	private const int ppbIdStart = 1, prbIdStart = 11, sbIdStart = 8, hbIdStart = 0;
	private GUIStyle labelStyle;
	void Start()
	{
		ppbPositions = new Rect[ppbTextures.Length];
		prbPositions = new Rect[prbTextures.Length];
		sbPositions = new Rect[sbTextures.Length];
		if(labels == null)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		else if(labels.Length != ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		labelStyle = new GUIStyle();
		labelStyle.font.material.color = Color.white;
		labelStyle.fontStyle = FontStyle.Bold;
	}
	#endregion
	//GUI-Update-Function
	void OnGUI()
	{
		#region ALL_ROUND_COMMANDS
		//Calculate scale factors. If the menu has half size all values have half values too.
		scaleFactorX = ((float)menuPosition.width) / ((float)500);
		scaleFactorY = ((float)menuPosition.height) / ((float)500);
		//Declaration of Positions
		/*  
		 * Positions of menu itmes(unscaled[500;500]):
		 * pp: x = 73,  y = 355
		 * h: x = 215,  y = 12
		 * s: x = 355, y = 358
		 * Size: 73
		 */
		Rect powerPlantsPosition = new Rect((int)(73F * scaleFactorX) + menuPosition.x, 
			(int)(355F * scaleFactorY) + menuPosition.y, 
			(int)(73F * scaleFactorX), 
			(int)(73F * scaleFactorY));
		Rect pollutionReducerPosition = new Rect((int)(215F * scaleFactorX)  + menuPosition.x, 
			(int)(12F * scaleFactorY) + menuPosition.y, 
			(int)(73F * scaleFactorX), 
			(int)(73F * scaleFactorY));
		Rect storagesPosition = new Rect((int)(355F * scaleFactorX)  + menuPosition.x, 
			(int)(358F * scaleFactorY) + menuPosition.y, 
			(int)(73F * scaleFactorX),
			(int)(73F * scaleFactorY));
		Rect menuBGPosition = menuPosition;
		Rect hbPosition = new Rect((250F - 25F) * scaleFactorX, 
			(250F - 25F)  * scaleFactorY, 
			50F * scaleFactorX, 
			50F * scaleFactorY);
		//Drawing Textures
		GUI.DrawTexture(menuBGPosition, menuBackground, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(powerPlantsPosition, powerPlantsTexture, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(pollutionReducerPosition, pollutionReducerTexture, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(storagesPosition, storagesTexture, ScaleMode.StretchToFill, true, 10.0F);
		//Get mouse position
		Vector3 mousePosition = Input.mousePosition;
		//Transform mousePosition y value
		mousePosition.y = Screen.height - mousePosition.y;
		#endregion
		#region MENU_ACTION
		//If the mouse clicked on the texture power plants
		if (Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, powerPlantsPosition) && mouseButtonDown)
		{
			ppbMenuOn = !ppbMenuOn;
			prbMenuOn = false;
			sbMenuOn = false;
			mouseButtonDown = false;
			if(ppbMenuOn)
			{
				rad_action = 1;
				rad_factor = (int)(2.5 * 200);
				rad_max = 2.5f;
			}
		}
		
		//If the mouse clicked on the texture pollutionReducer
		else if (Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, pollutionReducerPosition) && mouseButtonDown) 
		{
			prbMenuOn = !prbMenuOn;
			ppbMenuOn = false;
			sbMenuOn = false;
			mouseButtonDown = false;
			if(prbMenuOn)
			{
				rad_action = 1;
				rad_factor = 3 * 70;
				rad_max = 3;
			}
		}
		
		//If the mouse clicked on the texture storage
		else if (Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, storagesPosition) && mouseButtonDown)
		{
			sbMenuOn = !sbMenuOn;
			ppbMenuOn = false;
			prbMenuOn = false;
			mouseButtonDown = false;
			if(sbMenuOn)
			{
				rad_action = 1;
				rad_factor = 3 * 70;
				rad_max = 3;
			}
		}
		#endregion
		#region STORAGE_ITEMS_ACTION
		//Draw menu of last clicked item
		if(sbMenuOn)
		{
			//Draw menu items
			clickedOnStorage(storagesPosition, (float)rad_factor / (float)rad_action, -3.9f, 140);
			//for each item of positions
			for(int i = sbIdStart; i < sbPositions.Length + sbIdStart; i++)
			{
				//Fill empty labels with 'UNNAMED'
				if(labels[i] == null)
					labels[i] = "UNNAMED";
				//<MouseOverAction>
				if(overItem(mousePosition.x, mousePosition.y, sbPositions[i - sbIdStart]))
				{
					//Drawing box with label
					GUI.backgroundColor = Color.black;
					GUI.contentColor = Color.white;
					GUI.Button(new Rect(sbPositions[i - sbIdStart].x - labels[i].Length * 11,
						sbPositions[i - sbIdStart].y - 22,
						labels[i].Length * 11, 22 )
						, new GUIContent(labels[i]));
				}
				else if(Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, sbPositions[i - sbIdStart]) && mouseButtonDown)
				{
					//BUILD HB
				}
			}
		}
		#endregion
		#region POWER_PLANTS_ITEMS_ACTION
		else if(ppbMenuOn)
		{
			clickedOnPowerPlants(powerPlantsPosition, (float)rad_factor / (float)rad_action, -25, 180);
			//for each item of positions
			for(int i = ppbIdStart; i < ppbPositions.Length + ppbIdStart; i++)
			{
				//Fill empty labels with 'UNNAMED'
				if(labels[i] == null)
					labels[i] = "UNNAMED";
				//<MouseOverAction>
				if(overItem(mousePosition.x, mousePosition.y, ppbPositions[i - ppbIdStart]))
				{
					//Drawing box with label
					GUI.backgroundColor = Color.black;
					GUI.contentColor = Color.white;
					GUI.Button(new Rect(ppbPositions[i - ppbIdStart].x + ppbPositions[i - ppbIdStart].width,
						ppbPositions[i - ppbIdStart].y - 22,
						labels[i].Length * 11, 22 )
						, new GUIContent(labels[i]));
				}
				else if(Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, ppbPositions[i - ppbIdStart]) && mouseButtonDown)
				{
					//BUILD HB
				}
			}
		}
		#endregion
		#region POLLUTION_REDUCER_ITEMS_ACTION
		else if(prbMenuOn)
		{
			clickedOnpollutionReducer(pollutionReducerPosition, (float)rad_factor / (float)rad_action, 2.5f, 180);
			//for each item of positions
			for(int i = prbIdStart; i < prbPositions.Length + prbIdStart; i++)
			{
				//Fill empty labels with 'UNNAMED'
				if(labels[i] == null)
					labels[i] = "UNNAMED";
				//<MouseOverAction>
				if(overItem(mousePosition.x, mousePosition.y, prbPositions[i - prbIdStart]))
				{
					//Drawing box with label
					GUI.backgroundColor = Color.black;
					GUI.contentColor = Color.white;
					GUI.Button(new Rect(prbPositions[i - prbIdStart].x - labels[i].Length * 5,
						prbPositions[i - prbIdStart].y + prbPositions[i - prbIdStart].height,
						labels[i].Length * 11, 22 )
						, new GUIContent(labels[i]));
				}
				else if(Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, prbPositions[i - prbIdStart]) && mouseButtonDown)
				{
					//BUILD HB
				}
			}
		}
		#endregion
		#region HOUSE_ITEM_ACTION
		else{
			GUI.DrawTexture(new Rect((250F - 35F) * scaleFactorX,
				(250F - 35)  * scaleFactorY, 
				70F * scaleFactorX, 70F * scaleFactorY), 
				menuItemBG, ScaleMode.StretchToFill, 
				true, 10.0F);
			GUI.DrawTexture(hbPosition, hbTexture, ScaleMode.StretchToFill, true, 10.0F);
			if(Input.GetMouseButtonUp(0) && overItem(mousePosition.x, mousePosition.y, hbPosition) && mouseButtonDown)
			{
				//BUILD HB
			}
			else if(overItem(mousePosition.x, mousePosition.y, hbPosition))
			{
				//Drawing box with label
				GUI.backgroundColor = Color.black;
				GUI.contentColor = Color.white;
				GUI.Button(new Rect(hbPosition.x - labels[hbIdStart].Length * 5,
					hbPosition.y + hbPosition.height,
					labels[hbIdStart].Length * 11, 22 )
					, new GUIContent(labels[hbIdStart]));
			}
		}
		#endregion
		if(Input.GetMouseButtonDown(0))
			mouseButtonDown = true;
		if((float) rad_factor / (float)rad_action > rad_max)
			rad_action++;
	}
	//If the mouse is over the item, it returns true, else false
	private bool overItem(float mouseX, float mouseY, Rect position)
	{
		if(mouseX >= position.x && mouseX <= position.x + position.width && mouseY >= position.y && mouseY <= position.y + position.height)
			return true;
		return false;
	}
	
	#region  BUILDING_ITEMS
	//Open power plants menu with 6 PP-Items
	private void clickedOnPowerPlants(Rect powerPlantsPosition, float circleDiv, float cirlceStart, float radius)
	{
		//Declaration
		Rect ppbPosition;
		Vector2 coords;
		int lng = ppbTextures.Length;
		float radiant = 2 * Mathf.PI / circleDiv;
		radius = radius * scaleFactorX;
		//Calculate circle start radiant
		cirlceStart = 2 * Mathf.PI / cirlceStart;
		//There it has to be the same number of Positions and Textures of PP-Buildings
		if(ppbPositions.Length != ppbTextures.Length)
			ppbPositions = new Rect[ppbTextures.Length];
		//Give labels correct size
		if(labels == null)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		else if(labels.Length != ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		//For each element in ppbTextures
		for(int i = 0; i < lng; i++)
		{
			//Calculate position values
			coords = getCircelCoordinates(
				(float)((radiant/ lng) * i + cirlceStart),
				(float)radius);
			coords.x += powerPlantsPosition.x + (powerPlantsPosition.width / 2);
			coords.y += powerPlantsPosition.y + (powerPlantsPosition.height / 2);
			coords.x -= (50 / 2 * scaleFactorX);
			coords.y -= (50 / 2 * scaleFactorY);
			ppbPosition = new Rect(coords.x, coords.y, 50 * scaleFactorX, 50 * scaleFactorY);
			//Draw element
			GUI.DrawTexture(new Rect(ppbPosition.x - (10 * scaleFactorX),ppbPosition.y - (10 * scaleFactorY),70 * scaleFactorX, 70 * scaleFactorY), 
				menuItemBG, ScaleMode.StretchToFill, true, 10.0F);
			GUI.DrawTexture(ppbPosition, ppbTextures[i], ScaleMode.StretchToFill, true, 10.0F);
			ppbPositions[i] = ppbPosition;
		}
	}
	//Open pollutionReducer menu with ? H-Items
	private void clickedOnpollutionReducer(Rect pollutionReducerPosition, float circleDiv, float cirlceStart, float radius)
	{
		//Declaration
		Rect prbPosition;
		Vector2 coords;
		int lng = prbTextures.Length;
		float radiant = 2 * Mathf.PI / circleDiv;
		radius = radius * scaleFactorX;
		//Calculate circle start radiant
		cirlceStart = 2 * Mathf.PI / cirlceStart;
		//There it has to be the same number of Positions and Textures of PP-Buildings
		if(prbPositions.Length != prbTextures.Length)
			prbPositions = new Rect[prbTextures.Length];
		//Give labels correct size
		if(labels == null)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		else if(labels.Length != ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		//For each element in ppbTextures
		for(int i = 0; i < lng; i++)
		{
			//Calculate position values
			coords = getCircelCoordinates(
				(float)((radiant/ lng) * i + cirlceStart),
				(float)radius);
			coords.x += pollutionReducerPosition.x + (pollutionReducerPosition.width / 2);
			coords.y += pollutionReducerPosition.y + (pollutionReducerPosition.height / 2);
			coords.x -= (50 / 2 * scaleFactorX);
			coords.y -= (50 / 2 * scaleFactorY);
			prbPosition = new Rect(coords.x, coords.y, 50 * scaleFactorX, 50 * scaleFactorY);
			//Draw element
			GUI.DrawTexture(new Rect(prbPosition.x - (10 * scaleFactorX),prbPosition.y - (10 * scaleFactorY),70 * scaleFactorX, 70 * scaleFactorY), 
				menuItemBG, ScaleMode.StretchToFill, true, 10.0F);
			GUI.DrawTexture(prbPosition, prbTextures[i], ScaleMode.StretchToFill, true, 10.0F);
			prbPositions[i] = prbPosition;
		}
	}
	//Open storage menu with 3 Items
	private void clickedOnStorage(Rect storagesPosition, float circleDiv, float cirlceStart, float radius)
	{
		//Declaration
		Rect sbPosition;
		Vector2 coords;
		int lng = sbTextures.Length;
		float radiant = 2 * Mathf.PI / circleDiv;
		radius = radius * scaleFactorX;
		//Calculate circle start radiant
		cirlceStart = 2 * Mathf.PI / cirlceStart;
		//There it has to be the same number of Positions and Textures of PP-Buildings
		if(sbPositions.Length != sbTextures.Length)
			sbPositions = new Rect[sbTextures.Length];
		//Give labels correct size
		if(labels == null)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		else if(labels.Length != ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1)
			labels = new string[ppbTextures.Length + prbTextures.Length + sbTextures.Length + 1];
		//For each element in ppbTextures
		for(int i = 0; i < lng; i++)
		{
			//Calculate position values
			coords = getCircelCoordinates(
				(float)((radiant/ lng) * i + cirlceStart),
				(float)radius);
			coords.x += storagesPosition.x + (storagesPosition.width / 2);
			coords.y += storagesPosition.y + (storagesPosition.height / 2);
			coords.x -= (50 / 2 * scaleFactorX);
			coords.y -= (50 / 2 * scaleFactorY);
			sbPosition = new Rect(coords.x, coords.y, 50 * scaleFactorX, 50 * scaleFactorY);
			//Draw element
			GUI.DrawTexture(new Rect(sbPosition.x - (10 * scaleFactorX),sbPosition.y - (10 * scaleFactorY),70 * scaleFactorX, 70 * scaleFactorY), 
				menuItemBG, ScaleMode.StretchToFill, true, 10.0F);
			GUI.DrawTexture(sbPosition, sbTextures[i], ScaleMode.StretchToFill, true, 10.0F);
			sbPositions[i] = sbPosition;
		}
	}
	//Calculate circle coordinates
	private Vector2 getCircelCoordinates(float radiant, float radius)
	{
		float sinFactor, cosFactor, x = 0, y = 0;
		bool isRadiantUnderZero = false;
		//If radiant is smaller than zero
		if(radiant < 0)
		{
			radiant *= -1;
			isRadiantUnderZero = true;
		}
		radiant %= 2 * Mathf.PI;
		//Sin and Cos values	
		sinFactor = Mathf.Sin(radiant % (Mathf.PI / 2)) * radius;
		cosFactor = Mathf.Cos(radiant % (Mathf.PI / 2)) * radius;
		//Add sinFactors and cosFactors to x and y
		//0° to 90°
		if(radiant < Mathf.PI / 2)
		{
			x += sinFactor;
			y -= cosFactor;
		}
		//91° to 180°
		else if(radiant < Mathf.PI)
		{
			x += cosFactor;
			y += sinFactor;
		}
		//181° to 270°
		else if(radiant < 1.5 * Mathf.PI)
		{
			x -= sinFactor;
			y += cosFactor;
		}
		//271° to 360°
		else if(radiant < 2 * Mathf.PI)
		{
			x -= cosFactor;
			y += sinFactor;
		}
		else y -= radius;
		//Set zero values
		if(isRadiantUnderZero)
			x *= -1;
		return new Vector2(x, y);
	}
	
	#endregion
}
