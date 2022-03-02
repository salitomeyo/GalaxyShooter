using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    [SerializeField] [Tooltip("Prefab del triple laser")]
    private GameObject _bulletPrefab;

    public bool canTripleShoot = false;
    public bool canSpeedUp = false;

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

    public void SpeedUpPowerupOn()
    {
        canSpeedUp = true;
        StartCoroutine(PowerDownSpeedUp());
    }

    IEnumerator PowerDownSpeedUp()
    {
        yield return new WaitForSeconds(10.0f);
        canSpeedUp = false;
    }
}
