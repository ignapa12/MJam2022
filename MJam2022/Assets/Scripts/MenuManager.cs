using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject configPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame() {
        SceneManager.LoadScene(1);
    }
    public void GoStartMenu() {
        SceneManager.LoadScene(0);
    }

    public void exitGame() {
        Application.Quit();
    }

    public void toggleConfigPanel(bool showing) {
        if (configPanel) {
            this.configPanel.SetActive(showing);
        }
    }
}
