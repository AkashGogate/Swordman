using UnityEngine;
using System.Collections;


public class SelectableByMouse : MonoBehaviour {

	void OnMouseDown() {
		Controller.Instance.SetSelectedChar( GetComponent<CharController>() );
	}
}
