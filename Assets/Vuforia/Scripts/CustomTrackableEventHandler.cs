using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler {

	public TrackableBehaviour mTrackableBehaviour;
	public SkinnedMeshRenderer monsterMesh;
	//public Color foundMonsterColor;
	public Animator monsterAnim;

	public Button[] colorButtons;
	public Button[] animButtons;

	private Color initialMonsterColor;
	private bool clickedMonster = false;

	public GameObject colorsPanel;
	public GameObject animsPanel;

	// Use this for initialization
	void Start () {
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);

		initialMonsterColor = monsterMesh.material.color;

		foreach(Button button in colorButtons) {
			button.onClick.AddListener (delegate{
				ChangeMonsterColor(button);
			});
		}

		foreach(Button button in animButtons) {
			button.onClick.AddListener (delegate{
				ChangeMonsterAnimation(button.name);
			});
		}
			
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
		ShowPanels();
		Debug.Log("I've found my monster");
	}

	void OnTrackingLost () {
		HidePanels();
		Debug.Log("I've lost my monster");
	}

	/*void OnMouseDown() {
		clickedMonster = !clickedMonster;

		if (clickedMonster) {
			monsterMesh.material.color = foundMonsterColor;
			monsterAnim.SetTrigger("roar");
		} else {
			monsterMesh.material.color = initialMonsterColor;
		}
	}*/

	void ChangeMonsterColor(Button button) {
		switch (button.name) {
		case "Initial":
			monsterMesh.material.color = initialMonsterColor;
			break;
		/*case "Open":
			// something
			break;
		case "Close":
			// something
			break;*/
		default:
			monsterMesh.material.color = button.image.color;
			break;
		}
	}

	void ChangeMonsterAnimation(string buttonName) {
		Debug.Log ("Change anim index: " + buttonName);

		switch (buttonName) {
		case "Anim1":
			monsterAnim.SetTrigger ("jump");
			break;
		case "Anim2":
			monsterAnim.SetTrigger ("taunt");
			break;
		case "Anim3":
			monsterAnim.SetTrigger ("die");
			break;
		}
	}

	public void HidePanels() {
		colorsPanel.SetActive (false);
		animsPanel.SetActive (false);
	}

	public void ShowPanels() {
		colorsPanel.SetActive (true);
		animsPanel.SetActive (true);
	}

}


