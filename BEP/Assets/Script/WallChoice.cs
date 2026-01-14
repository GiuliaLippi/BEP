using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChoice : MonoBehaviour
{
    public bool isCorrectWall;
    public string nextScene;

    private bool active = false;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    void OnEnable()
    {
        GameEvents.OnPlayerLowHealth += Activate;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerLowHealth -= Activate;
    }

    void Activate()
    {
        active = true;
        sr.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!active) return;
        if (!other.CompareTag("Player")) return;

        GameEvents.OnWallImpact?.Invoke();

        if (isCorrectWall)
            StartCoroutine(LoadNextScene());
        else
            GameEvents.OnPlayerDeath?.Invoke();
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(nextScene);
    }
}
