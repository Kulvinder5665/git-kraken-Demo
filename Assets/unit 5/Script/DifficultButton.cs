using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultButton : MonoBehaviour
{

    private GameManager gameManager;
    private Button button;


    public int difficulty;

    int test = 10; 
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficult);
    }


    void SetDifficult(){
        gameManager.StartGame(difficulty);
    }
}
