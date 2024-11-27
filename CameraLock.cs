using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// �J���������b�N���邽�߂̃X�N���v�g
/// </summary>
public class CameraLock : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook freeLookCamera;

    private float originalXAxisValue;
    private float originalYAxisValue;

    private void Start()
    {
        if (freeLookCamera == null)
        {
            freeLookCamera = GetComponent<CinemachineFreeLook>();
        }
    }

    /// <summary>
    /// ���_�ړ������b�N
    /// </summary>
    public void LockCameraRotation()
    {
        // ���݂̒l��ۑ�
        originalXAxisValue = freeLookCamera.m_XAxis.Value;
        originalYAxisValue = freeLookCamera.m_YAxis.Value;

        // �l���Œ肵�Ď��_�ړ��𖳌���
        freeLookCamera.m_XAxis.Value = originalXAxisValue;
        freeLookCamera.m_YAxis.Value = originalYAxisValue;

        // �ǉ��ŁA����Ȃ��悤�ɂ���
        freeLookCamera.m_XAxis.m_InputAxisName = "";
        freeLookCamera.m_YAxis.m_InputAxisName = "";
    }

    /// <summary>
    /// ���_�ړ����b�N������
    /// </summary>
    public void UnlockCameraRotation()
    {
        // ���b�N����
        freeLookCamera.m_XAxis.m_InputAxisName = "Mouse X"; // �܂��͓K�؂ȓ��͖�
        freeLookCamera.m_YAxis.m_InputAxisName = "Mouse Y"; // �܂��͓K�؂ȓ��͖�

        // ���Ƃ̉�]��Ԃɖ߂�
        freeLookCamera.m_XAxis.Value = originalXAxisValue;
        freeLookCamera.m_YAxis.Value = originalYAxisValue;
    }
}
