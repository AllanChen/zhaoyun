using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour {
	public GameObject cameraObject;
	public GameObject characterObject;

	void Start () {
	
	}

	void Update () {
			
		cameraObject.transform.position = new Vector3(characterObject.transform.position.x,-1.05f, -10);
	}
}
