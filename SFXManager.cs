using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
/// <summary>
/// ���ʉ����Đ����鏈��
/// </summary>
public class SFXManager : MonoBehaviour
{
    AudioSource audioSource;
    private string clipName;
    private float sfxLength;
    private bool isPlayingSFX = false;
    //======���ʉ�����===========================
    [SerializeField] private AudioClip startGameSound;
    [SerializeField] private AudioClip startStageSound;
    [SerializeField] private AudioClip selectStageSound;
    [SerializeField] private AudioClip backSound;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip purchaseSound;
    [SerializeField] private AudioClip selectBuyItemSound;
    [SerializeField] private AudioClip changeItemAmountSound;
    [SerializeField] private AudioClip dodgeSound;
    [SerializeField] private AudioClip swingAttackSound;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip healSound;
    //============================================
    public float SfxLength { get => sfxLength; set => sfxLength = value; }
    public bool IsPlayingSFX { get => isPlayingSFX; set => isPlayingSFX = value; }

    private float stepInterval = 0.7f;
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        audioSource = GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "WalkToStageScene")
        {
            StartCoroutine(PlayWalkSound());
        }
    }
    /// <summary>
    /// �U�����˂̉���ݒ�
    /// </summary>
    public void SetShotSound()
    {
        audioSource.clip = shotSound;
        PlaySound();
    }

    /// <summary>
    /// �Q�[���J�n�̉���ݒ�
    /// </summary>
    public void SetGameStartSound()
    {
        audioSource.clip = startGameSound;
        PlaySound();
    }

    /// <summary>
    /// �w������ݒ�
    /// </summary>
    public void SetPurchaseSound()
    {
        audioSource.clip = purchaseSound;
        PlaySound();
    }

    /// <summary>
    /// �w���A�C�e����I����������ݒ�
    /// </summary>
    public void SetSelectBuyItemSound()
    {
        audioSource.clip = selectBuyItemSound;
        PlaySound();
    }

    /// <summary>
    /// �A�C�e���𔃂�����ύX���鉹��ݒ�
    /// </summary>
    public void SetChangeItemAmountSound()
    {
        audioSource.clip = changeItemAmountSound;
        PlaySound();
    }

    /// <summary>
    /// ����̉���ݒ�
    /// </summary>
    public void SetDodgetSound()
    {
        audioSource.clip = dodgeSound;
        PlaySound();
    }

    /// <summary>
    /// �G�̐U�艺�낷�U���̉���ݒ�
    /// </summary>
    public void SetSwingAttackSound()
    {
        audioSource.clip = swingAttackSound;
        PlaySound();
    }

    /// <summary>
    /// �񕜂̉���ݒ�
    /// </summary>
    public void SetHealSound()
    {
        audioSource.clip = healSound;
        PlaySound();
    }

    /// <summary>
    /// �X�e�[�W�Z���N�g�őI�������Ƃ��̉���ݒ�
    /// </summary>
    public void OnClickSelectStage()
    {
        audioSource.clip = selectStageSound;
        PlaySound();
    }

    /// <summary>
    /// �X�e�[�W�J�n�̉���ݒ�
    /// </summary>
    public void OnClickStartStage()
    {
        audioSource.clip = startStageSound;
        PlaySound();
    }

    /// <summary>
    /// �߂�{�^���̉���ݒ�
    /// </summary>
    public void OnClickBackButton()
    {
        audioSource.clip = backSound;
        PlaySound();
    }
    /// <summary>
    /// �����Đ�
    /// </summary>
    public void PlaySound()
    {
        isPlayingSFX = true;
        audioSource.Play();

        StartCoroutine(CalcSFXLength(audioSource.clip.length));
    }

    /// <summary>
    /// ���ʉ��̒������v�Z
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    IEnumerator CalcSFXLength(float length)
    {
        sfxLength = length;
        yield return new WaitForSeconds(length);
        isPlayingSFX = false;
    }

    /// <summary>
    /// �X�e�[�W�Ɉړ����鉉�o�̍ۂ̑����𗬂�
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayWalkSound()
    {
        while (true)
        {
            audioSource.clip = walkSound;
            PlaySound();
            Debug.Log("a");
            yield return new WaitForSeconds(stepInterval);
        }
    }
}