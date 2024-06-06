using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    [Header("Player state")]
    [Min(0)]
    [SerializeField]
    private int lives = 3;

    [Min(0)]
    [SerializeField]
    private int ammo = 5;

    [Header("Events")]
    [SerializeField]
    private IntUnityEvent onUpdateLives;

    [SerializeField]
    private IntUnityEvent onUpdateAmmo;

    [SerializeField]
    private UnityEvent onStopGame;

    //[Header("UI")]
    //[SerializeField]
    //private TextMeshProUGUI livesText;

    //[SerializeField]
    //private TextMeshProUGUI ammoText;

    //[SerializeField]
    //private TextMeshProUGUI finalText;

    //private PlayerController playerController;

    //private void Awake()
    //{
    //    playerController = GetComponent<PlayerController>();
    //}

    private void Start()
    {
        //UpdateLivesText();
        //UpdateAmmoText();
        InvokeOnUpdateLives();
        InvokeOnUpdateAmmo();
    }

    //private void UpdateLivesText()
    //{
    //    livesText.text = $"Lives: {lives}";
    //}

    //private void UpdateAmmoText()
    //{
    //    ammoText.text = $"Ammo: {ammo}";
    //}

    public void TakeDamage()
    {
        //lives--;
        //UpdateLivesText();
        AddLives(-1);

        if (lives <= 0)
        {
            //StopGame();
            onStopGame.Invoke();
        }
    }

    //private void StopGame()
    //{
    //    playerController.enabled = false;
    //    finalText.gameObject.SetActive(true);
    //}

    public void AddLives(int value)
    {
        lives += value;
        //UpdateLivesText();
        InvokeOnUpdateLives();
    }

    public void AddAmmo(int value)
    {
        ammo += value;
        //UpdateAmmoText();
        InvokeOnUpdateAmmo();
    }

    public void InvokeOnUpdateLives()
    {
        onUpdateLives.Invoke(lives);
    }

    public void InvokeOnUpdateAmmo()
    {
        onUpdateAmmo.Invoke(ammo);
    }
}