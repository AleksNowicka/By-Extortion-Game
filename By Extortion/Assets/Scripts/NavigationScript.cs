using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationScript : MonoBehaviour {

    public Button backButton;
    public Button nextButton;

    public int previousSceneNumber;
    public int nextSceneNumber;

    public void onBackButtonClick() {
        Application.LoadLevel(previousSceneNumber);
    }

    public void onNextButtonClick() {
        Application.LoadLevel(nextSceneNumber);
    }

}
