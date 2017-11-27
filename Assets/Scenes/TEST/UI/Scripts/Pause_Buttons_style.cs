using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Buttons_style : MonoBehaviour {
	private Component[] button_tab;


	// Use this for initialization
	void Start () {
		button_tab = GetComponentsInChildren<Button> ();
		allButtonsStyle (button_tab);
		setButtonsText (button_tab);	 
	}

	void allButtonsStyle(Component[] button_tab)
	{
		foreach (Button m_button in button_tab) 
		{
			// Insert buttons style here
			// Each button of the menu will have this style
			m_button.GetComponentInChildren<Text>().color = Color.black;

        }
    }

	void setButtonsText(Component[] button_tab)
	{
		// Just add a line to add a new text to a button
		button_tab [0].GetComponentInChildren<Text> ().text = "Reprendre";
		button_tab [1].GetComponentInChildren<Text> ().text = "Sauvegarder"; 
		button_tab [2].GetComponentInChildren<Text> ().text = "Options"; 
		button_tab [3].GetComponentInChildren<Text> ().text = "Retour au menu"; 

	}

}
