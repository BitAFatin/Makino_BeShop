using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class IceMagic : MagicBase
{
    [SerializeField] private SO_Spell spell; //SO_Spell���擾

    private Vector3 targetPointPosition; // ���@�����n����ꏊ�̈ʒu���擾
    private List<GameObject> activeSpells = new List<GameObject>();
    private GameObject currentSpell; // ���˂��ꂽ���@���������

    [SerializeField] float moveSpeed = 5f; // ���@�̑��x
    //[SerializeField] private float spellRange = 10f;

    [SerializeField] GameObject player; // Player���擾
    private PlayerController playerController; // PlayerController���擾

    GameObject castPoint;

    Vector3 screenCenter;
    Vector3 bulletDirection;

    [SerializeField] private GameObject particleManagerObj;
    private GameObject sFXManagerObj;

    private float spellLength = 10.0f;
    private float moveLength = 0.5f;
    private float destroyDelay = 0.7f;
    // IceMagic�̃R���X�g���N�^
    public IceMagic()
    {
        ManaCost = 5;
        MagicDamage = 5;
    }

    void Start()
    {
        playerController = player.GetComponent<PlayerController>(); // player����PlayerController���擾

        screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0).normalized;

        sFXManagerObj = GameObject.FindWithTag("SFXManager");
    }

    void Update()
    {

    }

    public override void Behaviour(Vector3 targetPoint)
    {

        castPoint = GameObject.FindWithTag("CastPoint");
        //DOTween�Ŗ��@�̋���������
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 targetPosition = cameraPosition + cameraForward * spellLength;

        bulletDirection = targetPosition - castPoint.transform.position;

        currentSpell.transform.DOLocalMove(bulletDirection, moveLength).SetRelative(true).SetEase(Ease.Linear);
        Invoke("DestroySpell", destroyDelay);
    }

    public override void Cast(Transform castPoint)
    {
        SpendMana("�ʏ�U��", ManaCost);

        // ���ˎ���targetPoint�̈ʒu���擾
        targetPointPosition = playerController.TargetPoint01.position; // Player��targetPoint���擾

        // ���@�𔭎�
        currentSpell = Instantiate(spell.SpellPrefab, castPoint.position, Quaternion.identity);

        SFXManager sFXManager = sFXManagerObj.GetComponent<SFXManager>();
        sFXManager.SetShotSound();
    }

    void DestroySpell()
    {
        Destroy(currentSpell);
    }


    private void OnCollisionEnter(Collision collision)
    {

        //string collidedObjectName = collision.gameObject.name;

        //// �Փ˂����I�u�W�F�N�g�̖��O��\��
        //Debug.Log("�Փ˂����I�u�W�F�N�g�̖��O: " + collidedObjectName);


        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit enemy");

            IE_TakeDamage e_TakeDamage = collision.gameObject.GetComponent<IE_TakeDamage>();

            e_TakeDamage.EnemyTakeDamage(MagicDamage);

            ContactPoint contact = collision.contacts[0];

            // �Փ˓_�̈ʒu�ix, y, z�j
            Vector3 collisionPoint = contact.point;

            DestroySpell();
        }
    }
}
