using UnityEngine;
using System.Collections;

public class RandomCharacterController : MonoBehaviour {

	
	private int walkID = Animator.StringToHash("walk");
	private int hitID = Animator.StringToHash("hit");
	private int attackID = Animator.StringToHash("attack");
	private int deathID = Animator.StringToHash("death");
	private int castID = Animator.StringToHash("cast");
	private int attackTypeID = Animator.StringToHash("attackType");
	private int deathTypeID = Animator.StringToHash("deathType");
	private int castTypeID = Animator.StringToHash("castType");

	public Animator anim;
	private bool done;

	private float minRandomDelay = 2f;
	private float maxRandomDelay = 4f;

	// Use this for initialization
	void Start () {
		done = false;

		StartCoroutine( StartRandomAnimations() );
	}

	private IEnumerator StartRandomAnimations() {
		while (!done) {
			yield return new WaitForSeconds( UnityEngine.Random.Range(minRandomDelay, maxRandomDelay) );

			PlayRandomAnim();
		}
	}

	private void PlayRandomAnim() {
		int rHit = UnityEngine.Random.Range(0, 5);
		switch (rHit) {
		case 0 : { PlayWalk(); break; }
		case 1 : { StopWalk(); PlayAttack(); break; }
		case 2 : { StopWalk(); PlayCast(); break; }
		case 3 : { StopWalk(); PlayDeath(); break; }
		case 4 : { StopWalk(); PlayHit(); break; }
		default : { StopWalk(); break; }
		}
	}

	#region Play animations
	private void PlayWalk() {
		anim.SetBool( walkID, true );
	}
	private void StopWalk() {
		anim.SetBool( walkID, false );
	}

	private void PlayAttack() {
		anim.SetFloat( attackTypeID, UnityEngine.Random.Range(0, 2) );
		anim.SetTrigger( attackID );
	}

	private void PlayCast() {
		anim.SetFloat( castTypeID , UnityEngine.Random.Range(0, 2) );
		anim.SetTrigger( castID );
	}
	
	private void PlayDeath() {
		anim.SetFloat( deathTypeID, UnityEngine.Random.Range(0, 2) );
		anim.SetTrigger( deathID );
	}

	private void PlayHit() {
		anim.SetTrigger( hitID );
	}
	#endregion
}
