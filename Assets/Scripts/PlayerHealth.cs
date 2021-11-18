using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private Sprite liveEmpty;
    [SerializeField] private Sprite liveComplete;
    private GameObject[] lives;
    private int health = 3;

    private void Start()
    {
        lives = GameObject.FindGameObjectsWithTag(GameTags.Live.ToString());
    }
    public void Hurt()
    {
        health--;
        lives[health].GetComponent<Image>().sprite = liveEmpty;

        if (health == 0)
        {
            Debug.Log("Se murio :( ");
            SceneManager.LoadScene("VidaNatural");
        }
    }
}
