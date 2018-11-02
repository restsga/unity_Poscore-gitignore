using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonsManager : MonoBehaviour
{

    // Prefabs //
    public GameObject buttonPrefab;

    // Constants //
    private readonly string[] ranks = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th" };

    // Use this for initialization
    void Start()
    {
        // Load layout
        Vector3[] locations = {
            new Vector3(-450, 100, 0), new Vector3(-150, 100, 0),
            new Vector3(150, 100, 0), new Vector3(450, 100, 0),
            new Vector3(-450, -100, 0),new Vector3(-150, -100, 0),
            new Vector3(150, -100, 0),new Vector3(450, -100, 0)};

        // Initialize Statics
        Statics.Initialize();

        // Arrange buttons
        ButtonsLayout(locations);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Arrange buttons
    private void ButtonsLayout(Vector3[] locations)
    {
        // Load Canvas
        RectTransform canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        for (int i = 0; i < locations.Length; i++)
        {
            // Prevent pass by reference
            int id = i;

            if (Statics.active[id])
            {
                // Create button
                GameObject button = Instantiate(buttonPrefab, locations[id], Quaternion.Euler(0, 0, 0));
                // Set Canvas as parent
                button.transform.SetParent(canvas, false);
                // Set button text
                button.transform.GetComponentInChildren<Text>().text =
                    Statics.GetScore(id) + "/" + Statics.GetMaxScore() +
                    Environment.NewLine + ranks[Statics.GetRank(id)];
                // Set EventListener for click this button
                button.transform.GetComponent<Button>().onClick.AddListener(() => OnClickScoreButton(id));
            }
        }
    }

    // EventListener for click score button
    public void OnClickScoreButton(int id)
    {
        // Save id of this button
        Statics.SetId(id);
        // Call and move scene for input
        SceneManager.LoadScene("Input");
    }
}
