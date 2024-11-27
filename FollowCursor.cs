using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �A�C�e���ɃJ�[�\����������ۂɐ�����\������X�N���v�g
/// </summary>
public class FollowCursor : MonoBehaviour
{

    [SerializeField] RectTransform panel;
    [SerializeField] Canvas canvas;

    private float distanceFromCamera = 10f;

    [SerializeField] Vector3 panelOffset;

    private void Start()
    {
        panel = GetComponent<RectTransform>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = distanceFromCamera;
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Debug.Log(worldPosition);

        panel.position = worldPosition + panelOffset;
    }
}
