using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour {
    GameObject MainObj = GameObject.Find("MainObj");
    GameObject PlayObj = GameObject.Find("PlayObj");
    GameObject current;
    int[] maxvalues = {3, 4, 1};
    float oldY = 0f;
    int selected = 0, currentval = 0;

	void Start () {
        current = MainObj;
        current.SetActive(true);
        current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Select();
	}
	
	void Update () {
        float currYVal = Input.GetAxis("Vertical");
		if (oldY < currYVal && selected < maxvalues[currentval]-1)
        {
            current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Deselect();
            selected++;
            current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Select();
        }
        if(oldY > currYVal && selected > 0)
        {
            current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Deselect();
            selected--;
            current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Select();
        }
        oldY = currYVal;

        if(Input.GetAxis("Fire1") != 0)
        {
            switch(current.transform.GetChild(selected).name)
            {
                case "PLAY":
                    current.SetActive(false);
                    current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Deselect();
                    selected = 0;
                    currentval = 1;
                    current = PlayObj;
                    current.SetActive(true);
                    current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Select();
                    break;
                case "OK":
                    current.SetActive(false);
                    current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Deselect();
                    selected = 0;
                    currentval = 1;
                    current = PlayObj;
                    current.SetActive(true);
                    current.transform.GetChild(selected).gameObject.GetComponent<TextOptionManager>().Select();
                    break;
                case "Crabii misuna pe insula":
                    SceneManager.LoadScene("Insula");
                    break;
                case "EXIT":
                    Application.Quit();
                    break;
            }
        }
	}
}
