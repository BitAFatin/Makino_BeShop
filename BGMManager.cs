using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGM���Ǘ�����X�N���v�g
/// </summary>
public class BGMManager : MonoBehaviour
{
    LoadScene loadScene;

    AudioSource audioSource;

    //======BGM�N���b�v����======
    [SerializeField] private AudioClip titleBgm;
    [SerializeField] private AudioClip HomeBgm;
    [SerializeField] private AudioClip ShopBgm;
    [SerializeField] private AudioClip StageBgm;
    [SerializeField] private AudioClip ClearBgm;
    [SerializeField] private AudioClip StageSelectBgm;
    //===========================
    private bool playingBgm = false;
    void Start()
    {
        loadScene = GetComponent<LoadScene>();

        audioSource = GetComponent<AudioSource>();

        playingBgm = false;
    }

    void Update()
    {
        //�V�[���ɂ���čĐ�����BGM��ύX
        if (playingBgm == false)
        {
            switch (loadScene.CurrentScene)
            {
                case "TitleScene":
                    audioSource.clip = titleBgm;
                    PlayBgm();
                    break;
                case "HomeScene":
                    audioSource.clip = HomeBgm;
                    PlayBgm();
                    break;
                case "ShopScene":
                    audioSource.clip = ShopBgm;
                    PlayBgm();
                    break;
                case "Stage":
                    audioSource.clip = StageBgm;
                    PlayBgm();
                    break;
                case "ResultScene":
                    audioSource.clip = ClearBgm;
                    PlayBgm();
                    break;
                case "StageSelectScene":
                    audioSource.clip = StageSelectBgm;
                    PlayBgm();
                    break;
            }
        }

        if(playingBgm == false)
        {
            
        }
    }

    /// <summary>
    /// BGM�Đ�
    /// </summary>
    private void PlayBgm()
    {
        audioSource.Play();

        playingBgm = true;
    }
}
