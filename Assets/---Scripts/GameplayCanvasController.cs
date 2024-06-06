using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvasController : MonoBehaviour
{
    [Header("Collectibles")]
    [SerializeField]
    private RectTransform heartContainer;

    [SerializeField]
    private RectTransform ammoContainer;

    [SerializeField]
    private GameObject heartPrefab;

    [SerializeField]
    private GameObject ammoPrefab;

    [Header("Menus")]
    [SerializeField]
    private RectTransform pausedMenu;

    [SerializeField]
    private RectTransform gameOverMenu;

    private void Start()
    {
        Hide(pausedMenu);
        Hide(gameOverMenu);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void UpdateHeartsUI(int newLives)
    {
        UpdateChildCount(heartContainer, heartPrefab, newLives);
    }

    public void UpdateAmmoUI(int newAmmo)
    {
        UpdateChildCount(ammoContainer, ammoPrefab, newAmmo);
    }

    public void ShowGameOverMenu()
    {
        Hide(pausedMenu);
        Show(gameOverMenu);
    }

    public void ResumeGame()
    {
        Hide(pausedMenu);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Scenes.RestartScene();
    }

    public void ExitGame()
    {
        Scenes.LoadPreviousScene();
    }

    private void TogglePauseGame()
    {
        if (IsGameOver())
        {
            return;
        }

        if (IsGamePaused())
        {
            ResumeGame();
        }    
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Show(pausedMenu);
        Time.timeScale = 0;
    }

    private bool IsGameOver()
    {
        return gameOverMenu.gameObject.activeInHierarchy;
    }

    private bool IsGamePaused()
    {
        return pausedMenu.gameObject.activeInHierarchy;
    }

    // These functions are responsible for adding and removing child elements from a Transform component. In our
    // case, this will be Heart and Ammo prefabs being added and removed as the player health and ammo values change

    private static void UpdateChildCount(Transform container, GameObject prefab, int newCount)
    {
        var childCount = container.childCount;
        var change = Mathf.Min(Mathf.Abs(childCount - newCount), childCount);

        if (childCount < newCount)
        {
            AddChildren(container, prefab, change);
        }
        else
        {
            RemoveChildren(container, change);
        }
    }

    private static void AddChildren(Transform container, GameObject prefab, int count)
    {
        for (var i = 0; i < count; i++)
        {
            Instantiate(prefab, container);
        }
    }

    private static void RemoveChildren(Transform container, int count)
    {
        for (var i = 0; i < count; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    private static void Show(Component component)
    {
        component.gameObject.SetActive(true);
    }

    private static void Hide(Component component)
    {
        component.gameObject.SetActive(false);
    }
}
