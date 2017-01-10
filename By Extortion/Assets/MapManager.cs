using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MapManager : MonoBehaviour {

    public bool isMainMap;

    public Sprite playerIcon;
    public Sprite puzzleIcon;
    public Sprite miniGameIcon;
    public Sprite destinationFieldIcon;
    public Sprite emptyFieldImage;

    public GameObject[] mapRows;

    private int actualPlayerPositionRow, actualPlayerPositionColumn;
    private int destinationFieldRow, destinationFieldColumn;
    private int puzzlePositionRow, puzzlePositionColumn;
    private int miniGamePositionRow, miniGamePositionColumn;

	void Start () {
        System.Random random = new System.Random();

        int numberOfFieldsOnMap;
        if (isMainMap){
            numberOfFieldsOnMap = 3;
        }
        else{
            numberOfFieldsOnMap = 2;
        }

        int[] randomRows = new int[numberOfFieldsOnMap];
        int[] randomColumns = new int[numberOfFieldsOnMap];
        for (int i = 0; i < numberOfFieldsOnMap; i++){
            randomRows[i] = random.Next(0, mapRows.Length);
            randomColumns[i] = random.Next(0, mapRows[0].GetComponentsInChildren<Image>().Length);
        }

        actualPlayerPositionRow = randomRows[0];
        actualPlayerPositionColumn = randomColumns[0];

        if (isMainMap){
            puzzlePositionRow = randomRows[1];
            puzzlePositionColumn = randomColumns[1];
            miniGamePositionRow = randomRows[2];
            miniGamePositionColumn = randomColumns[2];
        }
        else{
            destinationFieldRow = randomRows[1];
            destinationFieldColumn = randomColumns[1];
        }

        setupIcons();
	}
	
	void Update () {
	    //Check from server
	}

    private void setupIcons() {
        mapRows[actualPlayerPositionRow].GetComponentsInChildren<Image>()[actualPlayerPositionColumn].sprite =
                playerIcon;
        mapRows[puzzlePositionRow].GetComponentsInChildren<Image>()[puzzlePositionColumn].sprite =
                puzzleIcon;
        mapRows[miniGamePositionRow].GetComponentsInChildren<Image>()[miniGamePositionColumn].sprite =
                miniGameIcon;
    }

    private void clearIcon(int row, int column) {
        mapRows[row].GetComponentsInChildren<Image>()[column].sprite = emptyFieldImage;
    }

    public void onFieldClick(string position) {
        string[] rowAndColumn = position.Split('_');
        int row = Int32.Parse(rowAndColumn[0]);
        int column = Int32.Parse(rowAndColumn[1]);
        if (Math.Abs(row - actualPlayerPositionRow) <= 1 &&
            Math.Abs(column - actualPlayerPositionColumn) <= 1){
            clearIcon(actualPlayerPositionRow, actualPlayerPositionColumn);
            actualPlayerPositionRow = row;
            actualPlayerPositionColumn = column;
            setupIcons();
 
        }
    }

}
