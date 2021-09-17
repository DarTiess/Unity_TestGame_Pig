using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CanvasGroup startGroupe;
    public CanvasGroup playGroupe;
    public CanvasGroup failGroupe;   
    public CanvasGroup headerGroupe;

    public TextMeshProUGUI countApple;
    public TextMeshProUGUI finalCountApple;
    int countApp;

    [HideInInspector] public bool isGaming;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnCanvasGroupe("Start");
        countApp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        countApple.text = countApp.ToString();
    }
    public void StartGame()
    {
        OnCanvasGroupe("Play");
       
    }

    public void AddApple()
    {
        countApp++;
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
        finalCountApple.text ="apples: "+ countApp.ToString();
        OnCanvasGroupe("Fail");
       
    }
    public void RestartGame()
    {
        countApp = 0;
        PlayerController.Instance.RestartPiggie();
        CleanLevel();
        OnCanvasGroupe("Play");
      
    }
    public void CleanLevel()
    {
        GameObject[] dogs = GameObject.FindGameObjectsWithTag("Dog");
        foreach (GameObject gb in dogs)
        {
            Destroy(gb.gameObject);
        }
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject gb in apples)
        {
            Destroy(gb.gameObject);
        }

    }

    public void QuiteGame()
    {
        Application.Quit();
    }
}
