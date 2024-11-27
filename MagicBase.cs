using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���@�̗v�f�̌p���X�N���v�g
/// </summary>
public abstract class MagicBase : MonoBehaviour, IMagic
{
    
    private string magicName; //���@�̖��O
    private float manaCost; //���@�̃}�i�R�X�g
    private float magicDamage; //���@�̃_���[�W

    //====�v���p�e�B����=======
    public string MagicName { get => magicName; set => magicName = value; }
    internal float ManaCost { get => manaCost; set => manaCost = value; }
    internal float MagicDamage { get => magicDamage; set => magicDamage = value; }
    //===============================


    /// <summary>
    /// �}�i������鏈��
    /// </summary>
    /// <param name="magicName"></param>
    /// <param name="manaCost"></param>
    protected void SpendMana(string magicName, float manaCost)
    {
        Debug.Log("�}�i�R�X�g " + manaCost + " �Ŗ��@ " + magicName + " ���g�����B");
    }

    /// <summary>
    /// /���@���˂̌p�����\�b�h
    /// </summary>
    /// <param name="castPoint"></param>
    public abstract void Cast(Transform castPoint);

    /// <summary>
    /// ���@�̋����̌p�����\�b�h
    /// </summary>
    /// <param name="targetPoint"></param>
    public abstract void Behaviour(Vector3 targetPoint);
}
