using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Button playAgain;


    void Awake()
    {
        instance = this;
        playAgain.onClick.AddListener(OnClick);

    
    }

    private void OnClick()
    {
        Debug.Log("pressionado");
    }
}
