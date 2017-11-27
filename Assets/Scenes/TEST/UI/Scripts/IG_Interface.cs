using UnityEngine;
using System.Collections;

public class IG_Interface : MonoBehaviour {
    private bool _menuOpen = false;
    public GameObject _PauseMenu;

	// Use this for initialization
	void Start () {
        isOpenMenu = false;
	}
	
    public bool isOpenMenu
    {
        get { return _menuOpen; }

        set
        {
            _menuOpen = value;
            Time.timeScale = (_menuOpen) ? 0 : 1;
            _PauseMenu.SetActive(_menuOpen);
        }
    }


    // Called by Cross_button and Play_Button
    public void onClickCloseMenu()
    {
        isOpenMenu = !isOpenMenu;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpenMenu = !isOpenMenu;
        }
	}
}
