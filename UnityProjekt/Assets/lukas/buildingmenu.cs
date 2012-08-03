// C#
using UnityEngine;
using System.Collections;

public class buildingmenu : MonoBehaviour {
	//private int maxHealth=100;
	//private int curHealth=100;   
	private string workmin = "10";
	private string workmax = "15";
	private string energy = "-5";
	private string pollution = "+1";
	private bool mouseButtonDown;
	private Rect menuBox, menubox_a, menubox_b, menubox_c, menubox_d, menubox_e, menubox_f;
	public Texture[] tex;
	void down(){
		print("down");
	}
	void up(){
		print("up");
	}
	void disablebuilding(){
		print("Das Gebaeude wurde deaktiviert!");
	}
	void destroybuilding(){
		print("Das Gebaeude wurde abgerissen!");
	}
	private bool isInMenuBox(Rect box, Vector3 mouse){
		if(box.Contains(mouse)){
			return true;
		}
		else{
			return false;
		}
	}
	
	void Start() {
		menuBox = new Rect(-10, -10, 0, 0);
		menubox_a = new Rect(-10, -10, 0, 0);
		menubox_b = new Rect(-10, -10, 0,0);
		menubox_c = new Rect(-10,-10,0,0);
		menubox_d = new Rect(-10,-10,0,0);
		menubox_e = new Rect(-10,-10,0,0);
		menubox_f = new Rect(-10,-10,0,0);
	}
	
	void OnGUI(){
		Vector3 mouse = Input.mousePosition;
		mouse.y = Screen.height - mouse.y;
		if (Input.GetMouseButtonUp(0) && mouseButtonDown && !isInMenuBox(menuBox, mouse) && !isInMenuBox(menubox_a ,mouse) && !isInMenuBox(menubox_b ,mouse)){
			menuBox = new Rect(mouse.x, mouse.y, 120, 60);
			menubox_a = new Rect((mouse.x + 20), (mouse.y - 30), 30, 30);
			menubox_b = new Rect((mouse.x + 70), (mouse.y - 30), 30,30);
			menubox_c = new Rect (menuBox.x, menuBox.y, 20, 20);
			menubox_d = new Rect ((menuBox.x + 100), (menuBox.y), 20, 20);
			menubox_e = new Rect ((menuBox.x + 20), (menuBox.y - 30), 30, 30);
			menubox_f = new Rect ((menuBox.x + 70), (menuBox.y - 30), 30, 30);
		}
		if(Input.GetMouseButtonUp(0)){
			mouseButtonDown = false;
		}
		if(Input.GetMouseButtonDown(0)){
			mouseButtonDown = true;
		}
		
		GUI.Box (menuBox, "Work:" + workmin + "/" + workmax + "\n" + "Energy:" + energy + "\n" + "Pollution:" + pollution);
		if (GUI.Button(menubox_c, "-")) {
			down();
		}
		if (GUI.Button(menubox_d, "+")){
			up();
		}
		if (GUI.Button(menubox_e, "Di")){
			disablebuilding();
		}
		if (GUI.Button(menubox_f, "De")){
			destroybuilding();
		}
		//GUI.Box (new Rect (10,10,Screen.width / 2 / (maxHealth / curHealth),50), curHealth + "/" + maxHealth);
		//GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		
	}

}