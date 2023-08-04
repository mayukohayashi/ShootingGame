using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    Transform parent;

    [SerializeField]
    int scorePerHit = 11;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        scoreBoard.IncreaseScore(scorePerHit);

        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
