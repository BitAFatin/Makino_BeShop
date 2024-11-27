using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �G�F�N�}�̃X�N���v�g
/// </summary>
public class Bear : Enemy
{
    [SerializeField] private GameObject enemyManagerObj;
    private EnemyManager _enemyManager;


    [SerializeField] private float bearHealth;
    [SerializeField] private int bearAttackPower;

    [SerializeField] private float bearMoveSpeed = 5f;

    Animator animator;
    //=============�e�A�j���[�V����=============
    [SerializeField] string idle_animation;
    [SerializeField] string attack_animation;
    [SerializeField] string walk_animation;
    [SerializeField] string dead_animation;
    //==========================================

    private bool playerIsHere = false;
    private GameObject player;

    private float destroyDelay = 0.7f;
    private float distanceToPlayer = 3.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        health = bearHealth;
        attackPower = bearAttackPower;

        canMove = true;

        player = GameObject.FindWithTag("Player");
        _enemyManager = enemyManagerObj.GetComponent<EnemyManager>();
    }

    void Update()
    {
        
    }

    public override void EnemyMove(bool foundPlayer, Vector3 playerPosition)
    {
        if (canMove == true)
        {
            playerIsHere = foundPlayer;

            if (foundPlayer == true)
            {
                StartCoroutine(Move(playerPosition));
            }
            else
            {
                animator.Play(idle_animation);
            }
        }
    }

    /// <summary>
    /// �U�����J�n���鏈��
    /// </summary>
    public override void EnemyAttack()
    {
        StartCoroutine(Attack());
    }

    /// <summary>
    /// �U�����~�߂鏈��
    /// </summary>
    public override void EnemyStopAttack()
    {
        StopCoroutine(Attack());
    }

    /// <summary>
    /// �U�����󂯂鏈��
    /// </summary>
    /// <param name="damageAmount"></param>
    public override void EnemyTakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log("now HP �F " +  health);
        if(health <= 0)
        {
            EnemyDead(); 
        }
    }

    /// <summary>
    /// ���񂾏���
    /// </summary>
    public override void EnemyDead()
    {
        animator.Play(dead_animation);
        canMove = false;

        Invoke("DestroyObj", destroyDelay);
    }

    /// <summary>
    /// �폜���鏈��
    /// </summary>
    void DestroyObj()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// �ړ��̃R���[�`��
    /// </summary>
    /// <param name="playerPosition"></param>
    /// <returns></returns>
    IEnumerator Move(Vector3 playerPosition)
    {
        while (playerIsHere == true)
        {
            animator.Play(walk_animation);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, bearMoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, playerPosition) < distanceToPlayer) // �����̂������l
            {
                break; // �ڕW�ʒu�ɓ��B�����烋�[�v�𔲂���
            }

            yield return null;
        }
        
    }
    /// <summary>
    /// �U���̃R���[�`��
    /// </summary>
    /// <returns></returns>
    IEnumerator Attack()
    {
        animator.Play(attack_animation);

        GameObject sFXManagerObj = GameObject.FindGameObjectWithTag("SFXManager");
        SFXManager sFXManager = sFXManagerObj.GetComponent<SFXManager>();
        sFXManager.SetSwingAttackSound();
        EnemySearchPlayer enemySearchPlayer = GetComponent<EnemySearchPlayer>();

        yield return new WaitForSeconds(0.6f);
        enemySearchPlayer.ChackPlayerFrame();
        if (enemySearchPlayer.PlayerInFront == true)
        {
            DoneDamageToPlayer(bearAttackPower);
        }
        yield return new WaitForSeconds(4.4f);
    }
}
