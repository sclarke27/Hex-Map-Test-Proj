using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HexMapTile : MonoBehaviour {

    private MeshFilter tileMesh;
    private float _tileWidth = 0;
    private float _tileHeight = 0;
	private bool _isSelected = false;
	private Color defaultColor;
	public Text coordText;

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
    
    // Use this for initialization
	void Start () {
		tileMesh = transform.GetComponentInChildren<MeshFilter> ();
		if (tileMesh == null) {
			Debug.LogError ("tile mesh not found", tileMesh);
			return;
		}
		float randomHeight = Random.Range (0.1f, 1f);
		TileWidth = tileMesh.mesh.bounds.extents.x * 2;
		TileHeight = tileMesh.mesh.bounds.extents.y * 2;
		defaultColor = new Color ();
		defaultColor.r = randomHeight;
		defaultColor.g = randomHeight;
		defaultColor.b = 1f;
		tileMesh.renderer.materials[0].color = defaultColor;
		tileMesh.transform.localScale = new Vector3 (tileMesh.transform.localScale.x, randomHeight, tileMesh.transform.localScale.z);
		coordText.text = tileMesh.transform.localScale.x + "," + tileMesh.transform.localScale.y;
	}

	// Update is called once per frame
	void Update () {
        //Debug.Log(tileMesh);
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
