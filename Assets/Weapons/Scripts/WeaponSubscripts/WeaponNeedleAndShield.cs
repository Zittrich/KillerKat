using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNeedleAndShield : Weapon
{
    [Range(0, 1)] public float BlockFactor;
    public float BlockTime;
    internal PlayerVitality _playerVitality;
    internal AudioSource _audioSource;

    void Start()
    {
        _playerVitality = FindObjectOfType<PlayerVitality>();
        _audioSource = GetComponent<AudioSource>();
        _playerVitality.blockingFactor = BlockFactor;
        base.Start();
    }
    
    public override void SecondaryAttack()
    {
        Block();

        Invoke("UnBlock", BlockTime);
    }

    internal void Block()
    {
        _playerVitality.IsBlocking = true;
        PlaySound(SecondaryHitSound);
    }

    internal void UnBlock()
    {
        _playerVitality.IsBlocking = false;
        PlaySound(SecondaryMissSound);
    }
}
