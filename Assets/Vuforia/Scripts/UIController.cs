using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject colorsPanel;
	public GameObject openBtnColorsPanel;
	public GameObject closeBtnColorsPanel;
	public Animator animColorsPanel;

	public GameObject animsPanel;
	public GameObject openBtnAnimsPanel;
	public GameObject closeBtnAnimsPanel;
	public Animator animAnimsPanel;


	// Use this for initialization
	void Start () {
		/*Button closeBtn = closeBtnColorsPanel.GetComponent<Button>();
		closeBtn.onClick.AddListener (OpenPanel);

		Button openBtn = openBtnColorsPanel.GetComponent<Button>();
		openBtn.onClick.AddListener (ClosePanel);*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenPanelColors() {
		openBtnColorsPanel.SetActive (false);
		closeBtnColorsPanel.SetActive (true);
		animColorsPanel.SetTrigger ("openPanel");
	}

	public void ClosePanelColors() {
		openBtnColorsPanel.SetActive (true);
		closeBtnColorsPanel.SetActive (false);
		animColorsPanel.SetTrigger ("closePanel");
	}

	public void OpenPanelAnims() {
		openBtnAnimsPanel.SetActive (false);
		closeBtnAnimsPanel.SetActive (true);
		animAnimsPanel.SetTrigger ("openPanel");
	}

	public void ClosePanelAnims() {
		openBtnAnimsPanel.SetActive (true);
		closeBtnAnimsPanel.SetActive (false);
		animAnimsPanel.SetTrigger ("closePanel");
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
