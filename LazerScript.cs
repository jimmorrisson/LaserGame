using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LazerScript : MonoBehaviour {
	float dist = 1000.0f; //max distance for beam to travel
	LineRenderer lr;
	string reftag = "reflect"; //tag it can reflect off
	int limit = 100; //max reflection
	int verti = 1; //segment handler
	bool iactive;
	Vector3 currot;
	Vector3 curpos;
	public GameObject endPanel; //UI panel that shows while end
	public GameObject turret;
	public GameObject wall;

	void Start () 
	{
		endPanel.SetActive (false);
		lr = gameObject.GetComponent<LineRenderer> ();
	}
		
	void Update () 
	{
		lr.enabled = Input.GetMouseButton (0);
		if(Input.GetMouseButton(0))
		{
			DrawLaser();
		}
	}

	void DrawLaser(){
		verti = 1;
		iactive = true;
		curpos = transform.position;
		currot = transform.forward;
		lr.SetVertexCount (1);
		lr.SetPosition (0, transform.position);

		while (iactive) 
		{
			verti++;
			RaycastHit hit;
			lr.SetVertexCount (verti);
			if (Physics.Raycast (curpos, currot, out hit, dist)) 
			{
				//verti++
				curpos = hit.point;
				currot = Vector3.Reflect (currot, hit.normal);
				lr.SetPosition (verti - 1, hit.point);
				if(hit.collider.name == "EndGameTrigger")
				{
					EndGame ();
				}
				else if (hit.transform.gameObject.tag != reftag)
				{
					iactive = false;
				}
			} 
			else
			{
				iactive = false;
				lr.SetPosition (verti - 1, curpos + 100 * currot);
			}
			if (verti > limit) 
			{
				iactive = false;
			}
		}
	}
	public void EndGame()
	{
		GameObject.DestroyObject (turret);
		wall.isStatic = true;
		//wall.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		endPanel.SetActive (true);
		//SceneManager.LoadScene ("EndScene");
	}
	public void OnButtonClick(string sceneName)
	{
		
	}
}
