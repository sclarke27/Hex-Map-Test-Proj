using UnityEngine;
using System.Collections;

public class HexMapTile : MonoBehaviour {

    private MeshFilter tileMesh;
    private float tileWidth = 0;
    private float tileHeight = 0;

    public float TileWidth
    {
        get { return tileWidth; }
        set { tileWidth = value; }
    }

    public float TileHeight
    {
        get { return tileHeight; }
        set { tileHeight = value; }
    }
    
    // Use this for initialization
	void Start () {
        tileMesh = transform.GetComponent("Tile_Mesh") as MeshFilter; ;//transform.GetComponent<MeshFilter>("Tile_Mesh");
        tileWidth = tileMesh.mesh.bounds.extents.x * 2;
        tileHeight = tileMesh.mesh.bounds.extents.y * 2;
	}

	// Update is called once per frame
	void Update () {
        Debug.Log(tileMesh);
	}
}
