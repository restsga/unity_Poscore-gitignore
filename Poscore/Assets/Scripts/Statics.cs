using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{

    // Constants //
    private static int MAX_MEMBERS = 8;
    private static int NULL_NUMBER_FOR_ID = -1;

    // Variable //
    private static int id = NULL_NUMBER_FOR_ID;
    private static bool initialized = false;
    public static int maxScore = 1000;
    public static int[] scores = new int[MAX_MEMBERS];


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Initialize()
    {
        if (initialized)
        {
            return;
        }

        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = maxScore;
        }

        initialized = true;
    }

    public static int GetMaxMembers()
    {
        return MAX_MEMBERS;
    }

    public static void SetId(int id)
    {
        Statics.id = id;
    }

    public static int GetAndResetId()
    {
        int sendedId = id;
        id = NULL_NUMBER_FOR_ID;

        return sendedId;
    }
}
