using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatScript : EnemyScript
{
    private Animator _animator;
    public GameObject[] JumpPoints;

    public AudioClip JumpSound;
    public float JumpImpactRange;
    public float JumpImpactDmg;
    public ParticleSystem ImpactParticles;

    public AudioClip StompSound;

    public AudioClip MouthAttackSound;

    public AudioClip TailAttackSound;

    public float JumpTime;

    private AudioSource audioSource;
    private System.Random _random = new System.Random();
    private int _lastTime;

    new public void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Idle");

        JumpTime = _animator.runtimeAnimatorController.animationClips[2].length;

        Invoke("CatJump", 3);

        base.Start();
    }

    private void Update()
    {
        if ((int)Time.time % 5 == 0 && (int)Time.time != _lastTime)
        {
            _lastTime = (int)Time.time;
            int thisCase = _random.Next(0, 4);
            switch (thisCase)
            {
                case 1:
                    CatJump();
                    break;
                case 2:
                    TailAttack();
                    break;
                case 3:
                    PawAttack();
                    break;
                case 4:
                    JumpAttack();
                    break;

                default:
                    break;
            }
        }
    }

    public void CatJump()
    {
        _animator.Play("Armature|JumpAttack");
        Vector3 nextJump = JumpPoints[_random.Next(0, JumpPoints.Length)].transform.position;
        transform.DOMove(nextJump, JumpTime);

        Invoke("CatJumpUtil", JumpTime);
    }

    internal void CatJumpUtil()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, JumpImpactRange);
        AudioSource audioSource = GetComponent<AudioSource>();
        ImpactParticles.Play();

        foreach (Collider hit in hitColliders)
        {
            if(hit.GetComponent<PlayerVitality>())
            {
                hit.GetComponent<PlayerVitality>().TakeDamage(JumpImpactDmg);
            }
        }
    }

    public void TailAttack()
    {
        _animator.Play("Armature|TrueSweep");
    }
    public void JumpAttack()
    {
        _animator.Play("Armature|JumpAttack");
    }

    public void PawAttack()
    {
        _animator.Play("Armature|Paw attack");
    }
}
