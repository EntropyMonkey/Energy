using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	protected Tile tileRef;
	protected bool enabled;
	protected Dictionary<ResourceType, float> Input = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> Output = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentInput = 
            new Dictionary<string, float>();
	protected Dictionary<ResourceType, float> CurrentOutput = 
            new Dictionary<string, float>();
	protected List<Upgrade> Upgrades;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	
	public void updatePollution(){
	}
	public float updateEfficiency(){
	}
	public void updateOutput(){
		Output = Output * Efficiency;
	}
	public void updateInput(){
	}
}
