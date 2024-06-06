using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(Rigidbody), typeof(Player))]
public class AntiTankMineTrigger : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    private string antiTankMineTag = "ATMine";

    [Min(0f)]
    [SerializeField]
    private float minExplosionForce = 3f;

    [Min(0f)]
    [SerializeField]
    private float maxExplosionForce = 5f;

    [Header("Events")]
    [SerializeField]
    private UnityEvent onTriggerMine;

    //private AntiTankMineController antiTankMineController;
    private Rigidbody rb;
    //private Player player;

    private void Awake()
    {
        //antiTankMineController = FindAnyObjectByType<AntiTankMineController>();

        rb = GetComponent<Rigidbody>();
        //player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision other)
    {
        var otherGameObject = other.gameObject;
        if (IsAntiTankMine(otherGameObject))
        {
            AddExplosionForce();
            otherGameObject.SetActive(false);
            Destroy(otherGameObject);
            //player.TakeDamage();
            //antiTankMineController.CreateMine();
            onTriggerMine.Invoke();
        }    
    }

    private bool IsAntiTankMine(GameObject obj)
    {
        return obj.CompareTag(antiTankMineTag);
    }

    private void AddExplosionForce()
    {
        var force = Random.Range(minExplosionForce, maxExplosionForce);
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
