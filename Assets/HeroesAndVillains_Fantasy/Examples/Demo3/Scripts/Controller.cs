using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float minY = -5;
	public float maxY = 2;

	private CharController selectedCharacter;

	public Camera cam;

	private bool currentlySelectedChar = false;
	private bool currentlyTargetedChar = false;


	public static Controller Instance { get; private set; }

	void Awake () {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}
	void OnDestroy() {
		Instance = null;
	}

	public void SetSelectedChar(CharController selectedChar) {
		if (!selectedChar.Equals(selectedCharacter)) {
			selectedCharacter = selectedChar;
			selectedChar.SendMessage("OnSelected", SendMessageOptions.DontRequireReceiver);
			currentlySelectedChar = true;
		}
	}

	public void SetTarget(Alive target) {
		if (selectedCharacter != null) {
			selectedCharacter.Command_Attack( target );
			target.SendMessage("OnTargeted", SendMessageOptions.DontRequireReceiver);
			currentlyTargetedChar = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (selectedCharacter == null) {
			return;
		}

		if (selectedCharacter.IsDead()) {
			selectedCharacter = null;
		}

		//Right click deselect character
		if (Input.GetMouseButtonDown(1)) {
			selectedCharacter = null;
		}

		if (!currentlySelectedChar && !currentlyTargetedChar && Input.GetMouseButtonDown(0)) {
			selectedCharacter.Command_WalkTo( GetWorldClickPosition() );
		}

		currentlySelectedChar = false;
		currentlyTargetedChar = false;
	}

	private Vector3 GetWorldClickPosition() {
		Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
		return new Vector3(worldPos.x, Mathf.Clamp(worldPos.y, minY, maxY), worldPos.z);
	}


}
