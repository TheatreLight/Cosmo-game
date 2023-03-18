using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject youDead;
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Text lifeLabel;
    public static int life = 3;
    public static int score = 0;
    public static new string name;
    public UnityEngine.UI.Button startButton;
    public static bool isStarted = false;


    // Start is called before the first frame update
    private void Start()
    {
        startButton.onClick.AddListener(delegate
        {
            menu.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = ""+score;
        lifeLabel.text = ""+ life;
        if(name == "---")
        {
            lifeLabel.text = name;
            youDead.SetActive(true);
            isStarted = false;
        }
    }
}
