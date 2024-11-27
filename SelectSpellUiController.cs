using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;
/// <summary>
/// ���@��I������UI��\������X�N���v�g
/// </summary>
public class SelectSpellUiController : MonoBehaviour
{
    [SerializeField] private RectTransform panel; // �e�p�l��
    [SerializeField] private float duration = 0.5f; // �A�j���[�V�����̎���
    [SerializeField] private float targetScale = 0.3f; // �ŏI�I�ȃX�P�[��

    MouseCursorController mouseCursorController;
    void Start()
    {
        mouseCursorController = GameObject.FindWithTag("MainCamera").GetComponent<MouseCursorController>();
    }

    private void Update()
    {
        //E�L�[����������UI��\�����A�J�[�\���L��
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            // ������Ԃł̓X�P�[�����������ݒ肵�Ă����i��ʒ����ŏk����ԁj
            panel.localScale = Vector3.zero;

            // �e�p�l���̃X�P�[�����g�傷��
            panel.DOScale(targetScale, duration).SetEase(Ease.OutBack);
            mouseCursorController.CursorLock = false;
        }

        //E�L�[�𗣂���UI���\���ɂ��A�J�[�\������
        else if(Keyboard.current.eKey.wasReleasedThisFrame)
        {
            // �e�p�l���̃X�P�[�����g�傷��
            panel.DOScale(0.0f, duration).SetEase(Ease.OutBack);
            
            mouseCursorController.LockAndStayCenter();
        }
    }
}
