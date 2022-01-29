using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject configPanel, creditsPanel;

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        configPanel.SetActive(false);
        creditsPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (configPanel.activeSelf) {
            toggleConfigPanel();

            }
            else if (creditsPanel.activeSelf) {
                toggleCreditsPanel();
            }
        }
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

    public void toggleConfigPanel() {
        configPanel.SetActive(!configPanel.activeSelf);
    }

    public void toggleCreditsPanel() {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
}
