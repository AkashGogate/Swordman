using UnityEngine;
using System.Collections;

public class DemoHeroController : MonoBehaviour {

	public Animator anim;
	
	private int walkID = Animator.StringToHash("walk");
	private int hitID = Animator.StringToHash("hit");
	private int attackID = Animator.StringToHash("attack");
	private int deathID = Animator.StringToHash("death");
	private int castID = Animator.StringToHash("cast");
	private int attackTypeID = Animator.StringToHash("attackType");
	private int deathTypeID = Animator.StringToHash("deathType");
	private int castTypeID = Animator.StringToHash("castType");

	
	public void Idle() {
		anim.SetBool( walkID, false );
	}

	public void Walk() {
		anim.SetBool( walkID, true );
	}

	public void Attack1() {
		anim.SetFloat(attackTypeID, 0);
		anim.SetTrigger( attackID );
	}
	public void Attack2() {
		anim.SetFloat(attackTypeID, 1);
		anim.SetTrigger( attackID );
	}

	public void Cast1() {
		anim.SetFloat( castTypeID , 0);
		anim.SetTrigger( castID );
	}
	public void Cast2() {
		anim.SetFloat( castTypeID , 1);
		anim.SetTrigger( castID );
	}


	public void Die1() {
		anim.SetFloat(deathTypeID, 0);
		anim.SetTrigger( deathID );
	}
	public void Die2() {
		anim.SetFloat(deathTypeID, 1);
		anim.SetTrigger( deathID );
	}

	public void GotHit() {
		anim.SetTrigger( hitID );
	}

}
