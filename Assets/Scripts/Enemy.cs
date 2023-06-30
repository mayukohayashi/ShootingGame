using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log($"I'm {this.name}. Hit by {other.gameObject.name}");
    }

    private void OnDestroy()
    {
        //
    }
}
