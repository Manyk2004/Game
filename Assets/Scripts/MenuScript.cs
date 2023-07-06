using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject optionsCamera;
    [SerializeField] private GameObject levelCamera;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelPanel;

    public void LevelSelection()
    {
        mainCamera.SetActive(false);
        menuPanel.SetActive(false);
        optionsCamera.SetActive(false);
        optionsPanel.SetActive(false);

        levelCamera.SetActive(true);
        levelPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log(message: "Quit Game");
    }

    public void Options()
    {
        mainCamera.SetActive(false);
        menuPanel.SetActive(false);
        levelCamera.SetActive(false);
        levelPanel.SetActive(false);

        optionsCamera.SetActive(true);
        optionsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        optionsCamera.SetActive(false);
        optionsPanel.SetActive(false);
        levelCamera.SetActive(false);
        levelPanel.SetActive(false);

        mainCamera.SetActive(true);
        menuPanel.SetActive(true);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(0);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(3);
    }

}
