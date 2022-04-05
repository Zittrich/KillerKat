using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [SerializeField] public List<Weapon> WeaponList;

    [SerializeField] internal string json;

    internal int _selectedWeapon;
    private GameObject _hand;

    void Start()
    {
        try
        {
            _selectedWeapon = FindObjectOfType<GameHandler>().selectedLoadout;
        }
        catch
        {
            _selectedWeapon = 0;
        }

        try
        {
            _hand = GetComponentInChildren<HandScript>().gameObject;
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
            WeaponList[_selectedWeapon].PrimaryAttack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            WeaponList[_selectedWeapon].SecondaryAttack();
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
