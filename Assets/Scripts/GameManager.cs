using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float wordScrollingSpeed = 0.2f;
    public Text scoreText;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        score += wordScrollingSpeed;
        scoreText.text = score.ToString("0");
    }
}
