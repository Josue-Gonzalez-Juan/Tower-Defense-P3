using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour
{

    public AudioSource death;
    public int health;
    public GameObject gameEndUI;

    // Start is called before the first frame update
    void Start()
    {
        health = 90;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<Enemy>().Death();
        health -= 15;
        if (health <= 0)
        {
            Lose();
        }
    }

    void Lose()
    {
        death.Play();
        gameEndUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameRestart()
    {
        Debug.Log("Game Restart");
        SceneManager.LoadScene(0);
    }
}
