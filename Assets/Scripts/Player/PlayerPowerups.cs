using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    [SerializeField] [Tooltip("Prefab del triple laser")]
    private GameObject _bulletPrefab;

    public bool canTripleShoot = false;

    public void TripleShoot()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }

    public void TripleShootPowerupOn()
    {
        canTripleShoot = true;
        StartCoroutine(PowerDownTripleShoot());
    }

    IEnumerator PowerDownTripleShoot()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
}
