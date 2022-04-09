using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : EnemyScript
{
    private Animator _animator;

    new public void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Idle");
        base.Start();
    }

    public void CatJump()
    {
        
    }

    public void MouthAttack()
    {

    }

    public void TailAttack()
    {

    }
}
