using UnityEngine;
using System.Collections;

public class MovingWallScript : MonoBehaviour {
	private float wallSpeed = 0.5f;
	private float tileTransition = 0.0f;
	private const float BOUNDS_SIZE = 9.5f;
	public GameObject EndPanel;
	// Use this for initialization
	void Start () 
	{
		//Renderer rend = GetComponent<Renderer> ();
		//rend.material.SetColor ("", Color.red);
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveTile ();
	}
	void MoveTile()
	{
		if (EndPanel.activeInHierarchy == true) {
			this.transform.position = new Vector3 (0, 0, 0);
		} 
		else 
		{
			tileTransition += Time.deltaTime * wallSpeed; 
			transform.position += new Vector3(Mathf.Sin(tileTransition*BOUNDS_SIZE), 0.0f, 0.0f);
		}
	}
}
