using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTankMineController : MonoBehaviour
{
    [SerializeField]
    private GameObject antiTankMine;

    [Min(0)]
    [SerializeField]
    private int count = 3;

    [SerializeField]
    private Vector3 size = new Vector3(16f, 0f, 16f);

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Start()
    {
        for (int i = 0; i <= count ; i++)
        {
            CreateMine();
        }
    }

    public void CreateMine()
    {
        Instantiate(
            antiTankMine,
            GetRandomPosition(),
            antiTankMine.transform.rotation,
            gameObject.transform
        );
    }

    private Vector3 GetRandomPosition()
    {
        var volumePosition = new Vector3(
            Random.Range(0, size.x),
            Random.Range(0, size.y),
            Random.Range(0, size.z)
        );

        return transform.position + volumePosition - size / 2;
    }
}
