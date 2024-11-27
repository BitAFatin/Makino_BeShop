using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// HP�̉����X�N���v�g
/// </summary>
public class HpBarManager : MonoBehaviour
{
    [SerializeField] private Image hpImage;

    Color originalColor;
    private GameObject player;
    [SerializeField] private PlayerParameter playerParameter;

    /// <summary>
    /// ���݂�HP��\��
    /// </summary>
    /// <param name="hp"></param>
    public void ShowCurrentHp(float hp)
    {
        if (hpImage == null)
        {
            Debug.LogError("hpImage is missing");
        }
        else
        {
            hpImage.fillAmount = hp;
        }
    }
}
