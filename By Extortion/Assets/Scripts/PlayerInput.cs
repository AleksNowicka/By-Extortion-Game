using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

    private const int LOCKPICK_LEFT_INDICATOR = 0;
    private const int LOCKPICK_RIGHT_INDICATOR = 1;
    private const string WRONG_TEXT = "Wrong! Try again...";
    private const string GOOD_TEXT = "Good";
    private const string SUCCESS_TEXT = "Success!";

    public Image lockpickLeft, lockpickRight;
    public GameObject moodle;
    public Text resultText;

    private int counter = -1;

    private ArrayList tab;// = { 1, 0, 1, 1, 1, 0, 0, 0, 1, 0 };
    private int tabSize;// = 10;

    private void Start()
    {
        //Generate table
        System.Random random = new System.Random();
        tab = new ArrayList();
        tabSize = random.Next(6, 11);
        print("Table size " + tabSize);
        for(int i=0; i<tabSize; i++)
        {
            tab.Add(random.Next(0, 2));
            print(tab[i]);
        }
    }

    private void checkClick(int buttonIndicator)
    {
        counter += 1;
        if (Convert.ToInt32(tab[counter]) == buttonIndicator)
        {
            if (counter == tabSize-1)
            {
                resultText.text = SUCCESS_TEXT;
                moodle.SetActive(true);
            }
            else
            {
                resultText.text = GOOD_TEXT;
            }
        }
        else
        {
            counter = -1;
            resultText.text = WRONG_TEXT;
        }
    }

    public void onPickLeftClick()
    {
        lockpickLeft.transform.Rotate(0, 0, 5f);
        StartCoroutine(Wait(lockpickLeft));
        checkClick(LOCKPICK_LEFT_INDICATOR);   
    }

    public void onPickRightClick()
    {
        lockpickRight.transform.Rotate(0, 0, 5f);
        StartCoroutine(Wait(lockpickRight));
        checkClick(LOCKPICK_RIGHT_INDICATOR);
    }

    IEnumerator Wait(Image imageForEdit)
    {
        yield return new WaitForSeconds(0.5f);
        imageForEdit.transform.Rotate(0, 0, -5f);
    }

    /*public bool pickLeftLogic, pickRightLogic;
    public int [] Tab = {1,-1,1,1,1,-1,-1,-1,1,-1};
    int TabSize = 10;
    float tmp = 0;
    bool leftPickBack;
    bool rightPickBack;
    int TabIterator;
    string szyfr = "\0";
    // Use this for initialization
    void Start ()
    {
        lockpickLeft = GameObject.Find("PickLockLeft");
        lockpickRight = GameObject.Find("PickLockRight");
        TabIterator = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float hVal = Input.GetAxis("Horizontal");
        if(hVal != tmp)
        {
            if (hVal == 1)
            {
               if(Tab[TabIterator] == 1)
                {
                    szyfr = szyfr + "P";
                    print("Dobrze!\n");
                    TabIterator++;
                }
               else
                {
                    TabIterator = 0;
                    szyfr = "\0";
                    print("Zle!\nZacznij od poczatku!");

                }
               lockpickRight.transform.Rotate(0f, 0f, 5f);
               rightPickBack = true;
            }
            if (rightPickBack && hVal == 0)
            {
                lockpickRight.transform.Rotate(0f, 0f, -5f);
                rightPickBack = false;
            }

            if (hVal == -1)
            {
                if (Tab[TabIterator] == -1)
                {
                    szyfr = szyfr + "L";
                    print("Dobrze!\n");
                    TabIterator++;
                }
                else
                {
                    TabIterator = 0;
                    szyfr = "\0";
                    print("Zle!\nZacznij od poczatku!");

                }

                lockpickLeft.transform.Rotate(0f, 0f, 5f);
                leftPickBack = true;
            }
            if (leftPickBack && hVal == 0)
            {
                lockpickLeft.transform.Rotate(0f, 0f, -5f);
                leftPickBack = false;
            }
        }

        tmp = hVal;

        if(TabIterator == 10)
        {
            print("Brawo! Otworzyles skrzynie!");
            TabIterator = 0;
        }

    }*/
}
