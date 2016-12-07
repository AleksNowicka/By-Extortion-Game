using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ListBehaviourScript : MonoBehaviour {

    public Button deleteElementButton;

    public GameObject element;

    public void onDeleteElementButtonClick() {
        Destroy(element);
    }

}
