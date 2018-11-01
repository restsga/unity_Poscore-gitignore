using System;
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
    private static int[] scores = new int[MAX_MEMBERS];
    public static bool ascending = false;
    private static int[] ranks = new int[MAX_MEMBERS];


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
        for(int i = 0; i < ranks.Length; i++)
        {
            ranks[i] = 0;
        }

        initialized = true;
    }

    public static void AddOrRemoveScore(int amount, bool add)
    {
        if (add)
        {
            scores[id] += amount;
        }
        else
        {
            scores[id] -= amount;
        }

        CreateRanks();
        ResetId();
    }

    private static void CreateRanks()
    {
        // Copy scores
        int[] rankedScores = new int[scores.Length];
        for (int i = 0; i < scores.Length; i++)
        {
            rankedScores[i] = scores[i];
        }

        // Sort scores
        Array.Sort(rankedScores);
        if (ascending == false)
        {
            Array.Reverse(rankedScores);
        }

        for (int r = rankedScores.Length - 1; 0 <= r; r--)
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (rankedScores[r] == scores[i])
                {
                    ranks[i] = r;
                }
            }
        }
    }

    // Getters and Setters //

    public static int GetMaxMembers()
    {
        return MAX_MEMBERS;
    }

    public static void SetId(int id)
    {
        Statics.id = id;
    }

    public static void ResetId()
    {
        id = NULL_NUMBER_FOR_ID;
    }

    public static int GetScore(int index)
    {
        return scores[index];
    }

    public static int GetRank(int index)
    {
        return ranks[index];
    }
}
