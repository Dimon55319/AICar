using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

	[SerializeField]
	private WayPoint _next;
	[SerializeField]
	private bool _isStart = false;


	private const int MAX_DISTANCE = 6;
	private static WayPoint _start;
	
	private void Awake () {
		if (!_next)
			Debug.Log ("This waypoint is not connected,you need to set the next waypoint!", this);
		if (_isStart)
			_start = this;
	}
	
	// Returns where the AI should drive towards position is the current position of the car.
	private Vector3 CalculateTargetPosition (Vector3 position) {
		// If we are getting close to the waypoint, we return the next waypoint.
		// This gives us better car behaviour when cars don’t exactly hit the waypoint
		if (Vector3.Distance (transform.position, position) < MAX_DISTANCE) {
			return _next.transform.position;
		}
		// We are still far away from the next waypoint, just return the waypoints position
		else {
			return transform.position;
		}
	}

	// Draw the waypoint lines 
	private void OnDrawGizmos() {
		if(_isStart) {
			Gizmos.color = new Color (1f ,0f ,0f ,0.5f);
		} else {
			Gizmos.color = new Color (1f ,1f ,0f ,0.5f);
		}
		Gizmos.DrawCube (transform.position, new Vector3 (1f, 1f, 1f));
		
		if (_next) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine (transform.position, _next.transform.position);
			
		}
	}
}
