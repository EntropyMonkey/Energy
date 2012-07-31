using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Tile[,] Tiles = new Tile[50,50];
	public GameObject prefab;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void CreateMap() {
		for (int i = 0; i < Tiles.Length; i++) {
			for (int j = 0; j < Tiles.Length; j++) {
				GameObject buffer = Instantiate(prefab, new Vector3(i, 0, j), Quaternion.identity);
				Tile t = buffer.GetComponent<Tile>();
				t.Coords = new Vector2(i, j);
				t.Type = TileType.Mountain;
				this.Tiles[i, j] = t;
			}
		}
	}
	
	public List<Tile> GetEnvironmentTiles(Tile t) {
	
	}
	
}
