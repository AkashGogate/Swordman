using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Automatically sorts all SpriteRenderers found in children GOs.
 * Sorting is based on current Y position. 
 * GOs with higher Y are considered behind those with lower Y position.
 */
public class YSorter : MonoBehaviour {

	public float maxY = 2f;
	public float minY = -5f;
	private float sortingOrderMin = short.MinValue + 200;
	private float sortingOrderMax = short.MaxValue - 200;

	private Dictionary<SpriteRenderer, int> originalSortingOrder;
	private Transform myTr;

	// Use this for initialization
	void Start () {
		myTr = transform;
		FillOriginalSortingOrder();

		StartCoroutine( AutoSortingCoroutine() );
	}

	private void FillOriginalSortingOrder() {
		originalSortingOrder = new Dictionary<SpriteRenderer, int>();
		foreach(SpriteRenderer sRen in GetComponentsInChildren<SpriteRenderer>()) {
			originalSortingOrder.Add(sRen, sRen.sortingOrder);
		}
	}


	private IEnumerator AutoSortingCoroutine() {
		while (true) {
			AutoSort();
			yield return new WaitForSeconds(.1f);//let's say that 10x per second is enough
		}
	}

	private void AutoSort() {
		int sortingOffset = GetSortingOffset( myTr.position.y );
		foreach(SpriteRenderer sRen in originalSortingOrder.Keys) {
			sRen.sortingOrder = originalSortingOrder[sRen] + sortingOffset;
		}
	}

	private int GetSortingOffset(float currentY) {
		float clampedY = Mathf.Clamp(currentY, minY, maxY);
		float t = (clampedY - minY) / (maxY - minY);
		float sortingOffset = (t * (sortingOrderMax - sortingOrderMin)) + sortingOrderMin ;
		return Mathf.RoundToInt( -sortingOffset );
	}
}
