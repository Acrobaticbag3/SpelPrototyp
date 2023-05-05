using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BriochBoss : MonoBehaviour
{
    public EnemyManager brioch;
    public GameObject lastDialog;


    private void Start() 
    {
        lastDialog.SetActive(false);
    }

    private void Update() 
    {

        if(brioch.Enemy.Health <= 0)
        {
            EndsGame();
        }
    }
    public void EndsGame()
    {       
        lastDialog.SetActive(true);
        Time.timeScale = 0;    
    }


    
}
