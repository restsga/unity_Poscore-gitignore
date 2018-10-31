﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    // Objects //
    private GameObject inputText;

    // Constants //
    // The number of max digits
    private const int MAX_DIGITS = 4;
    // Null number for inputNumber
    private const int NULL_FOR_INPUTNUMBER = -1;

    // Variable //
    // Input datas
    private int[] inputNumbers = new int[MAX_DIGITS];

    // Use this for initialization
    void Start()
    {
        // Load NumberText as GameObject
        inputText= GameObject.Find("Canvas/NumberText");

        // Initialize
        InitializeInputNumber();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnClickNumberButton(int n)
    {
        // Save input number
        if (inputNumbers[0] != 0)
        {
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (inputNumbers[i] == NULL_FOR_INPUTNUMBER)
                {
                    inputNumbers[i] = n;
                    break;
                }
            }
        }

        // Show input numbers
        ShowInputNumbers();
    }

    public void OnClickAddRemoveButton(bool add)
    {
        // Check inputNumbers is not null
        bool isNull = true;
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            if (inputNumbers[i] != NULL_FOR_INPUTNUMBER)
            {
                isNull = false;
                break;
            }
        }
        if (isNull)
        {
            return;
        }

        // Get id to input
        int id= Statics.GetAndResetId();
        // Get input number as int
        int input = ChangeFromNumbersToInt();
        // Add or remove score
        if (add)
        {
            Statics.scores[id] += input;
        }
        else
        {
            Statics.scores[id] -= input;
        }
        // Call and move main scene
        SceneManager.LoadScene("Main");
    }


    public void OnClickClearButton()
    {
        InitializeInputNumber();
    }

    public void OnClickQuitButton()
    {
        // Reset id to input
        Statics.GetAndResetId();
        // Call and move main scene
        SceneManager.LoadScene("Main");
    }

    // Show input numbers
    private void ShowInputNumbers()
    {
        // Show input numbers
        inputText.GetComponent<Text>().text = ""+ChangeFromNumbersToInt();
    }

    //Initialize inputNumber
    private void InitializeInputNumber()
    {
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            inputNumbers[i] = NULL_FOR_INPUTNUMBER;
        }

        // Show input numbers
        inputText.GetComponent<Text>().text = "";
    }

    private int ChangeFromNumbersToInt()
    {
        // Create numbers data as string
        string numbers = "";
        for (int i = 0; i < inputNumbers.Length && inputNumbers[i] != NULL_FOR_INPUTNUMBER; i++)
        {
            numbers += inputNumbers[i];
        }

        return int.Parse(numbers);
    }
}
