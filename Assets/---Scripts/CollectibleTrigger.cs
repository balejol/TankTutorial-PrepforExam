using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Player))]
public class CollectibleTrigger : MonoBehaviour
{
    [Header("Collectibles")]
    [SerializeField]
    private string medicalPillTag = "MedicalPill";

    [SerializeField]
    private string ammoTag = "Ammo";

    [Min(0)]
    [SerializeField]
    private int pillValue = 1;

    [Min(0)]
    [SerializeField]
    private int ammoValue = 2;

    [Header("Events")]
    [SerializeField]
    private IntUnityEvent onCollectLives;

    [SerializeField]
    private IntUnityEvent onCollectAmmo;

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        var collected = false;

        if (IsMedicalPill(otherGameObject))
        {
            //player.AddLives(pillValue);
            onCollectLives.Invoke(pillValue);
            collected = true;
        }
        else if (IsAmmo(otherGameObject))
        {
            //player.AddAmmo(ammoValue);
            onCollectAmmo.Invoke(ammoValue);
            collected = true;
        }

        if (collected)
        {
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            //collectibleController.CreateCollectible();
        }
    }

    private bool IsMedicalPill(GameObject obj)
    {
        return obj.CompareTag(medicalPillTag);
    }

    private bool IsAmmo(GameObject obj)
    {
        return obj.CompareTag(ammoTag);
    }

    //private CollectibleController collectibleController;
    //private Player player;

    //private void Awake()
    //{
    //    collectibleController =
    //        FindObjectOfType<CollectibleController>();

    //    player = GetComponent<Player>();
    //}
}