using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzleScript : MonoBehaviour {

    public GameObject winningDialog;

    public GameObject[] puzzleImages;
    public Sprite[] puzzleInCorrectOrder;
    
    private Sprite[] puzzleActualState;

    private int emptyPuzzleIndex;

	void Start () {
        System.Random random = new System.Random();
        emptyPuzzleIndex = 15;
        puzzleActualState = new Sprite[puzzleInCorrectOrder.Length];
        int mixedPuzzleIndex;

        for (int i = 0; i < puzzleInCorrectOrder.Length; i++){
            mixedPuzzleIndex = random.Next(0, puzzleInCorrectOrder.Length);
            while (puzzleActualState[mixedPuzzleIndex] != null){
                mixedPuzzleIndex = random.Next(0, puzzleInCorrectOrder.Length);
            }
            puzzleActualState[mixedPuzzleIndex] = puzzleInCorrectOrder[i];
            if (puzzleInCorrectOrder[i] == null){
                emptyPuzzleIndex = mixedPuzzleIndex;
            }
            else{
                puzzleImages[mixedPuzzleIndex].GetComponent<Image>().sprite = puzzleActualState[mixedPuzzleIndex];
            }
        }
        winningDialog.SetActive(true);
	}

    public bool areElementsInCorrectOrder() {
        for (int i = 0; i < puzzleInCorrectOrder.Length; i++){
            if (puzzleInCorrectOrder[i] != puzzleActualState[i]){
                return false;
            }
        }
        return true;
    }

    public bool canMoveThisElement(int elementIndex) {
        if(elementIndex == emptyPuzzleIndex-4 ||
           elementIndex == emptyPuzzleIndex+4 ||
           elementIndex == emptyPuzzleIndex-1 ||
           elementIndex == emptyPuzzleIndex+1){
            return true;
        }
        return false;
    }

    public void onPuzzleElementClick(int elementIndex) {
        if (canMoveThisElement(elementIndex)){
            puzzleActualState[emptyPuzzleIndex] = puzzleActualState[elementIndex];
            puzzleActualState[elementIndex] = null;
            puzzleImages[emptyPuzzleIndex].GetComponent<Image>().sprite = puzzleActualState[emptyPuzzleIndex];
            puzzleImages[elementIndex].GetComponent<Image>().sprite = null;
            emptyPuzzleIndex = elementIndex;
        }
        if (areElementsInCorrectOrder()){
            winningDialog.SetActive(true);
        }
    }

}
