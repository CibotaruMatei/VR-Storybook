using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOptionManager : MonoBehaviour {
    public void Select () {
        GetComponent<Text>().fontSize += 25;
	}

    public void Deselect()
    {
        GetComponent<Text>().fontSize -= 25;
    }
}
