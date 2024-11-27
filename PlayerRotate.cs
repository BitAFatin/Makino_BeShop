using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform player; // Player��Transform��Inspector�Őݒ�
    [SerializeField] private CinemachineFreeLook freeLookCamera; // Cinemachine��FreeLookCamera��Inspector�Őݒ�

    void Update()
    {
        if (freeLookCamera != null && player != null)
        {
            // �J�����̐��ʕ������擾
            Vector3 cameraForward = freeLookCamera.transform.forward;
            cameraForward.y = 0; // Y�������[���ɂ��Ēn�ʕ��ʂɉ��������ɂ���
            cameraForward.Normalize(); // ���K��

            // Player�̌������J�����̐��ʕ����ɍ��킹��
            if (cameraForward != Vector3.zero) // �[���x�N�g���������
            {
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
                player.rotation = Quaternion.Slerp(player.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
}
