//// C#
//using UnityEngine;
//using System.Collections;

//public class test : MonoBehaviour {
//    //private int maxHealth=100;
//    //private int curHealth=100;   
//    private string workmin = "10";
//    private string workmax = "15";
//    private string energy = "-5";
//    private string pollution = "+1";
//    private bool mouseButtonDown;
//    private Rect menuBox, menubox_a, menubox_b;
//    //public Texture[] texture;
//    void down(){
//        print("down");
//    }
//    void up(){
//        print("up");
//    }
//    void disablebuilding(){
//        print("Das Gebaeude wurde deaktiviert!");
//    }
//    void destroybuilding(){
//        print("Das Gebaeude wurde abgerissen!");
//    }
//    private bool isInMenuBox(Rect box, Vector3 mouse){
//        if(box.Contains(mouse)){
//            return true;
//        }
//        else{
//            return false;
//        }
//    }
	
//    void Start() {
//        menuBox = new Rect(0, 30, 120, 60);
//        menubox_a = new Rect(0, 0, 30, 30);
//        menubox_b = new Rect(50, 0, 30,30);
//    }
	
//    void OnGUI(){
//        Vector3 mouse = Input.mousePosition;
//        mouse.y = Screen.height - mouse.y;
//        if (Input.GetMouseButtonUp(0) && mouseButtonDown && !isInMenuBox(menuBox, mouse) && !isInMenuBox(menubox_a ,mouse) && !isInMenuBox(menubox_b ,mouse)){
//            menuBox = new Rect(mouse.x, mouse.y, 120, 60);
//            menubox_a = new Rect((mouse.x + 20), (mouse.y - 30), 30, 30);
//            menubox_b = new Rect((mouse.x + 70), (mouse.y - 30), 30,30);
//        }
//        if(Input.GetMouseButtonUp(0)){
//            mouseButtonDown = false;
//        }
//        if(Input.GetMouseButtonDown(0)){
//            mouseButtonDown = true;
//        }
		
//        GUI.Box (menuBox, "Work:" + workmin + "/" + workmax + "\n" + "Energy:" + energy + "\n" + "Pollution:" + pollution);
//        if (GUI.Button(new Rect (menuBox.x, menuBox.y, 20, 20), "-")) {
//            down();
//        }
//        if (GUI.Button(new Rect ((menuBox.x + 100), (menuBox.y), 20, 20), "+")){
//            up();
//        }
//        if (GUI.Button(new Rect ((menuBox.x + 20), (menuBox.y - 30), 30, 30), "Di")){
//            disablebuilding();
//        }
//        if (GUI.Button(new Rect ((menuBox.x + 70), (menuBox.y - 30), 30, 30), "De")){
//            destroybuilding();
//        }
//        //GUI.Box (new Rect (10,10,Screen.width / 2 / (maxHealth / curHealth),50), curHealth + "/" + maxHealth);
//        //GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
//        //GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
		
//    }

//}