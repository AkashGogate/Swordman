using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	private VisualController visualController;
	private Walker walker;
	private Fighter fighter;
	private Alive alive;

	private Alive currentTarget = null;
	private Transform myTr;
	private BoxCollider2D bCollider;

	public bool CommandIssued { get; private set; }

	void Start() {
		myTr = transform;
		bCollider = GetComponent<BoxCollider2D>();
		visualController = GetComponent<VisualController>();
		walker = GetComponent<Walker>();
		fighter = GetComponent<Fighter>();
		alive = GetComponent<Alive>();

		CommandIssued = false;
	}

	public void Command_WalkTo(Vector3 position) {
		ClearCommands();
		walker.WalkTo( position );
		CommandIssued = true;
	}

	public void Command_Attack(Alive target) {
		if (target.Equals(currentTarget)) {
			return;
		} 
		ClearCommands();
		currentTarget = target;
		walker.Hunt(target);
		CommandIssued = true;
	}

	public bool IsDead() {
		return alive.IsDead;
	}

	private void ClearCommands() {
		currentTarget = null;
		fighter.StopFight();
		walker.StopHunt();
		walker.StopWalk();
		CommandIssued = false;
	}

	#region SendMessage handlers
	void OnWalkStarted(bool facingLeft) {
		if (!IsDead()) {
			visualController.Face(facingLeft);
			visualController.PlayWalk();
		}
	}

	void OnWalkDone() {
		if (!IsDead()) {
			visualController.StopWalk();
			CommandIssued = false;
		}
	}

	void OnHuntDone(Alive target) {
		if (!IsDead() && (target != null)) {
			visualController.Face( target.transform.position.x < myTr.position.x );
			fighter.Fight( target );
		}
	}

	void OnAttack(Alive target) {
		if (!IsDead() && (target != null)) {
			visualController.Face( target.transform.position.x < myTr.position.x );
			visualController.PlayAttack();
		}
	}

	void OnTargetLost(Alive target) {
		if (!IsDead() && (target != null)) {
			walker.Hunt(target);
		}
	}

	void OnTargetDead(Alive target) {
		CommandIssued = false;
	}

	void OnGotHit(Fighter attacker) {
		if (!IsDead()) {
			visualController.PlayHit();
		}
	}

	void OnDead() {
		ClearCommands();
		bCollider.enabled = false;
		visualController.PlayDeath();
	}
	#endregion
}
