using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexMapTile : MonoBehaviour {

    private MeshFilter tileMesh;
    private float _tileWidth = 2;
    private float _tileHeight = 2;
	private bool _isSelected = false;
	private Vector3 _tileCoords = new Vector2();
	private Color defaultColor;
	public Text coordText;
	public Text posText;

    public float TileWidth
    {
        get { return _tileWidth; }
        set { _tileWidth = value; }
    }

    public float TileHeight
    {
        get { return _tileHeight; }
        set { _tileHeight = value; }
    }

	public bool IsSelected 
	{
		get { return _isSelected; }
		set { _isSelected = value; }
	}
    
	public Vector3 TileCoords 
	{
		get { return _tileCoords; }
		set { _tileCoords = value; }
	}

    // Use this for initialization
	void Start () {
		tileMesh = transform.GetComponentInChildren<MeshFilter> ();
		if (tileMesh == null) {
			Debug.LogError ("tile mesh not found", tileMesh);
			return;
		}
		float randomHeight = Random.Range (0.1f, 1f);
		defaultColor = new Color ();
		defaultColor.r = randomHeight;
		defaultColor.g = randomHeight;
		defaultColor.b = 1f;
		tileMesh.renderer.materials[0].color = defaultColor;
		tileMesh.transform.localScale = new Vector3 (tileMesh.transform.localScale.x, randomHeight, tileMesh.transform.localScale.z);

	}

	// Update is called once per frame
	void Update () {
        //Debug.Log(tileMesh);
	}

	public void SetTilePos(Vector3 pos) {
		transform.position = pos;
		posText.text = Mathf.Round(pos.x) + "," + Mathf.Round(pos.z);
	}

	public void SetTileCoords(Vector3 coords) {
		TileCoords = coords;
		float rowNum = (TileCoords.z < 0) ? -TileCoords.z : TileCoords.z;
		float currX = ((TileWidth * (TileWidth * 0.75f)) * TileCoords.x) + ((rowNum%2!=1) ? (TileWidth*0.75f) : 0);
		float currZ = ((TileWidth / 2.3f) * TileCoords.z);
		SetTilePos (new Vector3 (currX, transform.position.y, currZ));
		coordText.text = TileCoords.x + "," + TileCoords.z;
	}

	void OnMouseDown() {
		Debug.Log ("click");
		IsSelected = !IsSelected;
		Color tempColor = new Color ();
		if (IsSelected) {
			tempColor.r = 1f;
			tempColor.g = 0f;
			tempColor.b = 0f;
		} else {
			tempColor = defaultColor;
		}
		tileMesh.renderer.materials[0].color = tempColor;


	}
}
