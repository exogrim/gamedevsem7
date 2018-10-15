using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetails : MonoBehaviour {
	[System.Serializable]
	public enum RoomType
	{
		Entry, L,R,T,B
	}

	public RoomType roomType;
	public GameObject Left,Right,Top,Bottom;

	private PCG pcg;
	private RoomTemplate roomTemplate;
	private DoorController doorController;
	// Use this for initialization
	void Start () {
		pcg = GameObject.FindGameObjectWithTag("LevelGenerator").GetComponent<PCG> ();
		roomTemplate = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplate>();
		Invoke ("GenerateRoom", 0.1f);
	}

	void GenerateRoom()
	{
		if (roomType.Equals (RoomType.Entry)) {
			GenerateLeft ();
			GenerateRight ();
			GenerateTop ();
			GenerateBottom ();
		}

	}

	void GenerateLeft()
	{
		Vector3 newpos;
		RoomDetails newRoomDetails;

		doorController = Left.GetComponent<DoorController> ();
		if (doorController.isRoomSet ()) {
			newpos = transform.position;
			newpos.x -= 30;
			GameObject newRoom = GameObject.Instantiate (roomTemplate.leftRooms [0]);
			newRoom.transform.position = newpos;
			doorController.setRoom (newRoom);

			newRoomDetails = newRoom.GetComponent<RoomDetails> ();
			doorController = newRoomDetails.Right.GetComponent<DoorController> ();
			doorController.setRoom (this.gameObject);
		}
	}

	void GenerateRight()
	{
		Vector3 newpos;
		RoomDetails newRoomDetails;

		doorController = Right.GetComponent<DoorController> ();
		if (doorController.isRoomSet ()) {
			newpos = transform.position;
			newpos.x += 30;
			GameObject newRoom = GameObject.Instantiate (roomTemplate.rightRooms [0]);
			newRoom.transform.position = newpos;
			doorController.setRoom (newRoom);

			newRoomDetails = newRoom.GetComponent<RoomDetails> ();
			doorController = newRoomDetails.Left.GetComponent<DoorController> ();
			doorController.setRoom (this.gameObject);
		}
	}

	void GenerateTop()
	{
			Vector3 newpos;
			RoomDetails newRoomDetails;

			doorController = Top.GetComponent<DoorController> ();
			if (doorController.isRoomSet ()) {
				newpos = transform.position;
				newpos.y += 30;
				GameObject newRoom = GameObject.Instantiate (roomTemplate.topRooms [0]);
				newRoom.transform.position = newpos;
				doorController.setRoom (newRoom);

				newRoomDetails = newRoom.GetComponent<RoomDetails> ();
				doorController = newRoomDetails.Bottom.GetComponent<DoorController> ();
				doorController.setRoom (this.gameObject);
			}
		
	}

	void GenerateBottom()
	{
		Vector3 newpos;
		RoomDetails newRoomDetails;

		doorController = Bottom.GetComponent<DoorController> ();
		if (doorController.isRoomSet ()) {
			newpos = transform.position;
			newpos.y -= 30;
			GameObject newRoom = GameObject.Instantiate (roomTemplate.bottomRooms [0]);
			newRoom.transform.position = newpos;
			doorController.setRoom (newRoom);

			newRoomDetails = newRoom.GetComponent<RoomDetails> ();
			doorController = newRoomDetails.Top.GetComponent<DoorController> ();
			doorController.setRoom (this.gameObject);
		}

	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 newpos;
		if (Left == null) {
			newpos = transform.position;
			newpos.x -= 30;
			Instantiate (roomTemplate.leftRooms [0],newpos,Quaternion.identity);
		}
		if (Right == null) {

			Instantiate (roomTemplate.leftRooms [0]);
		}
		if (Top == null) {

			Instantiate (roomTemplate.leftRooms [0]);
		}
		if (Bottom == null) {

			Instantiate (roomTemplate.leftRooms [0]);
		}*/
	}
}
