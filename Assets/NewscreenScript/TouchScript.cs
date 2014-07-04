using UnityEngine;
using System.Collections;

public class TouchScript : MonoBehaviour 
{
	public GUITexture leftController;
	public GUITexture rightController;

	public MPJoystick moveJoystick;
	bool faceingRight;
	public float moveSpeed ;

	Animator anim;
	
	void Start () {
		faceingRight = true;
		moveSpeed = 3.0f;
		anim = GetComponent<Animator>();
	}

	void Update () 
	{

#if UNITY_IOS
		PhoneInput();
#endif
#if UNITY_4_5_1
		//ControllerSaySomething();
#endif
		//OnMouseDown();
	}

	void PhoneInput()
	{



			int fingerCount = 0;
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
					fingerCount ++;
			}
			if(fingerCount > 0){}
				//print("User has" + fingerCount + "finger(s) touching the screen");
			Walk();
	}
	
	void ControllerSaySomething()
	{

		if(Input.GetButtonDown("Fire1"))
		{

			if(leftController.HitTest(Input.mousePosition))
			{
				Debug.Log(leftController.pixelInset.x);
				Debug.Log("i am leftconteroller");
			}
		}

	}	

	void Walk()
	{
		float touchMoveX = moveJoystick.position.x;
		float touchMoveY = moveJoystick.position.y;
		//Debug.Log("touchMoveX----"+touchMoveX);
		Flip(touchMoveX);
		anim.SetFloat("Speed",Mathf.Abs(touchMoveX));
		//rigidbody2D.velocity = new Vector2(touchMoveX*moveSpeed,rigidbody2D.velocity.y);	
	}


	void Flip(float touchMoveX)
	{
		if(touchMoveX<0 && faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,180,0);
			faceingRight = false;
			Debug.Log("1");
		}
		else if(touchMoveX>0 && !faceingRight)
		{
			transform.localRotation = Quaternion.Euler(0,0,0);
			faceingRight = true;
			Debug.Log("2");
		}
	}
}


