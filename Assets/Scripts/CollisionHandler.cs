using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float timeOfDelay = 1f;

    [SerializeField]
    ParticleSystem explodedParticles;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"{this.name} **Triggered by** {other.gameObject.name}");
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        explodedParticles.Play();

        GetComponent<PlayerController>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Invoke("ReloadLevel", timeOfDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
