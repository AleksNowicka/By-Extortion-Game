using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainOptionsScript : MonoBehaviour {

    public Button startGameButton;
    public Button achievementsButton;
    public Button leaderBoardButton;

    public int startGameSceneNumber;
    public int achievementsSceneNumber;
    public int leaderBoardSceneNumber;

    public void onStartGameButtonClick(){
        Application.LoadLevel(startGameSceneNumber);
    }

    public void onAchievementsButtopnClick(){
        Application.LoadLevel(achievementsSceneNumber);
    }

    public void onLeaderBoardButtonClick(){
        Application.LoadLevel(leaderBoardSceneNumber);
    }

}
