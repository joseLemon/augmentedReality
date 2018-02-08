using UnityEngine;
using Vuforia;

public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler {

	public TrackableBehaviour mTrackableBehaviour;
	public SkinnedMeshRenderer monsterMesh;
	public Color foundMonsterColor;
	private Color initialMonsterColor;
	private bool clickedMonster = false;

	// Use this for initialization
	void Start () {
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);

		initialMonsterColor = monsterMesh.material.color;
	}
	
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			OnTrackingLost();
		}
		else
		{
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			OnTrackingLost();
		}
	}

	void OnTrackingFound () {
		Debug.Log("I've found my monster");
	}

	void OnTrackingLost () {
		Debug.Log("I've lost my monster");
	}

	void OnMouseDown() {
		clickedMonster = !clickedMonster;

		if(clickedMonster)
			monsterMesh.material.color = foundMonsterColor;
		else
			monsterMesh.material.color = initialMonsterColor;
	}

}
