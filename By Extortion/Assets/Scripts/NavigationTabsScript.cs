using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationTabsScript : MonoBehaviour {

    public Button achievementsTabButton;
    public Button badgesTabButton;

    public GameObject achievementsList;
    public GameObject badgesList;

    public void onAchievementsTabButtonClick() {
        badgesList.SetActive(false);
        achievementsList.SetActive(true);
    }

    public void onBadgesTabButtonClick() {
        achievementsList.SetActive(false);
        badgesList.SetActive(true);
    }

}
