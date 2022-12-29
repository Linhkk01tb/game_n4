using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadGame()
    {
        Application.LoadLevel("level1");
    }
    public void loadLevel()
    {
        Application.LoadLevel("Level");
    }
    public void loadStart()
    {
        Application.LoadLevel("MenuGame");
    }
    public void exitGame()
    {
        Application.Quit();
        
    }
    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
