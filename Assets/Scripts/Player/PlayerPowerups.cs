using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    [SerializeField] [Tooltip("Triple laser prefab ")]
    private GameObject _bulletPrefab;

    [SerializeField] [Tooltip("Shield prefab")]
    private GameObject _shieldPrefab;

    public bool canTripleShoot = false;
    public bool canSpeedUp = false;
    public bool hasShield = false; 

    public void TripleShoot()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
    }

    public void TripleShootPowerupOn()
    {
        StartCoroutine(PowerDownTripleShoot());
    }

    IEnumerator PowerDownTripleShoot()
    {
        canTripleShoot = true;
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }

    public void SpeedUpPowerupOn()
    {
        StartCoroutine(PowerDownSpeedUp());
    }

    IEnumerator PowerDownSpeedUp()
    {
        canSpeedUp = true;
        yield return new WaitForSeconds(10.0f);
        canSpeedUp = false;
    }

    public void ShieldPowerupOn()
    {
        StartCoroutine(PowerDownShield());
    }

    IEnumerator PowerDownShield()
    {
        _shieldPrefab.SetActive(true);
        hasShield = true;
        yield return new WaitForSeconds(15f);
        hasShield = false;
        TurnShieldOff();
    }

    public void TurnShieldOff()
    {
        _shieldPrefab.SetActive(false);
    }
}
