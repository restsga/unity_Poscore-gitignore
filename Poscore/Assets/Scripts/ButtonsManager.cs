using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{

    // Prefabs //
    public GameObject buttonPrefab;

    // Use this for initialization
    void Start()
    {
        // Load layout
        Vector3[] locations = {
            new Vector3(-450, 100, 0), new Vector3(-150, 100, 0),
            new Vector3(150, 100, 0), new Vector3(450, 100, 0),
            new Vector3(-450, -100, 0),new Vector3(-150, -100, 0),
            new Vector3(150, -100, 0),new Vector3(450, -100, 0)};

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
            // Create button
            GameObject button= Instantiate(buttonPrefab, locations[i],Quaternion.Euler(0,0,0));
            // Set Canvas as parent
            button.transform.SetParent(canvas, false);
            // Set EventListener for click this button
            button.transform.GetComponent<Button>().onClick.AddListener(() => OnClickScoreButton(i));
        }
    }

    // EventListener for click score button
    public void OnClickScoreButton(int id)
    {

    }
}
