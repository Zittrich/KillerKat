using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [SerializeField] public List<Weapon> WeaponList;
    internal int _selectedWeapon;
    private GameObject Hand;

    void Start()
    {
        try
        {
            Hand = GetComponentInChildren<HandScript>().gameObject;
        }
        catch (Exception handDoesNotExist)
        {
            Console.WriteLine(handDoesNotExist);
            throw;
        }

        foreach (Weapon weapon in WeaponList)
        {
            weapon.gameObject.SetActive(false);
        }
        WeaponList[_selectedWeapon].gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            WeaponList[_selectedWeapon].SimpleAttack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            WeaponList[_selectedWeapon].HardAttack();
        }

        if (Input.GetButtonDown("Switch"))
        {
            SwitchWeapon();
        }
    }

    private void SwitchWeapon()
    {
        WeaponList[_selectedWeapon].gameObject.SetActive(false);
        _selectedWeapon = (_selectedWeapon + 1) % WeaponList.Count;
        WeaponList[_selectedWeapon].gameObject.SetActive(true);
    }
}
