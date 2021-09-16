﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CanvasGroup startGroupe;
    public CanvasGroup playGroupe;
    public CanvasGroup failGroupe;   
    public CanvasGroup headerGroupe;

    [HideInInspector] public bool isGaming;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnCanvasGroupe("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        OnCanvasGroupe("Play");
       
    }
    public void OnCanvasGroupe(string nameCanvas)
    {
        switch (nameCanvas)
        {
            case "Start":
                LockRestCanvases(startGroupe);

                break;
            case "Play":
                isGaming = true;
                LockRestCanvases(playGroupe);
                break;
            case "Fail":
                isGaming = false;
                LockRestCanvases(failGroupe);
                break;
           
        }
    }
    void LockRestCanvases(CanvasGroup canvasgr)
    {
        CanvasGroup[] canvasGroupes = GameObject.FindObjectsOfType<CanvasGroup>();
        foreach (CanvasGroup cGr in canvasGroupes)
        {
           
                cGr.alpha = 0;
                cGr.interactable = false;
                cGr.blocksRaycasts = false;
            
        }
        canvasgr.alpha = 1;
        canvasgr.interactable = true;
        canvasgr.blocksRaycasts = true;
        headerGroupe.alpha = 1;
        headerGroupe.interactable = true;
        headerGroupe.blocksRaycasts = true;

    }
    public void FailGame()
    {
        OnCanvasGroupe("Fail");
       
    }
    public void RestartGame()
    {
        PlayerController.Instance.RestartPiggie();
        OnCanvasGroupe("Play");
      
    }
}
