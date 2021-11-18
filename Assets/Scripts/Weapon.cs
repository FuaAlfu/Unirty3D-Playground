using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.11.16
/// </summary>
public class Weapon : MonoBehaviour
{
    [SerializeField]
    private WeaponType weaponType;

    private void OnTriggerEnter(Collider c)
    {
        WeaponManager weaponManager = c.GetComponent<WeaponManager>();
        if (weaponManager != null)
            //  weaponManager.EquipWeapon(weaponType);
            Destroy(gameObject);
    }
}

public enum WeaponType
{
    Gun,
    Sword
}
