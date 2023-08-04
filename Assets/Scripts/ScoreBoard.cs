using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Score is now: {score}");
    }
}
