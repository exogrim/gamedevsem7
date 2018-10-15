using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour {
	private GameObject nextRoom;
	private Animator panelAnimator; 

	// Use this for initialization
	void Start () {
		panelAnimator = GameObject.FindGameObjectWithTag("Panel").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setRoom(GameObject room)
	{
		nextRoom = room;
	}

	public bool isRoomSet()
	{
		bool isEmpty;
		if (nextRoom == null)
			isEmpty = true;
		else
			isEmpty = false;

		return isEmpty;
	}

	public GameObject getRoom()
	{
			return nextRoom;
	}

	void OnTriggerStay2D(Collider2D col)
	{
		col.transform.position = this.nextRoom.transform.position;
		if (Input.GetKeyDown ("space")) {
			panelAnimator.SetTrigger ("FadeIn");
			//col.transform.position = this.nextRoom.transform.position;
			panelAnimator.ResetTrigger ("FadeIn");
			//panelAnimator.SetBool ("FadeIn", false);
		}
	}


}
