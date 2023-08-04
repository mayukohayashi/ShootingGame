using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject explosionVFX;

    [SerializeField]
    Transform parent;

    void OnParticleCollision(GameObject other)
    {
        // Debug.Log($"I'm {this.name}. Hit by {other.gameObject.name}");
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
