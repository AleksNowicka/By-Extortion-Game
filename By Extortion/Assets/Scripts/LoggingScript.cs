using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoggingScript : MonoBehaviour {

    public Button loginButton;
    public int nextSceneNumber;

    public void onLoginButtonClick(){
        Application.LoadLevel(nextSceneNumber);
    }

}
