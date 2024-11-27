using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using DG.Tweening.Plugins.Options;
/// <summary>
/// SHOP�̕����𓮂�������
/// </summary>
public class FontTweening : MonoBehaviour
{
    TextMeshPro text;

    private float maxFontSize = 13.0f;
    private float minFontSize = 10.0f;
    void Start()
    {
        text = GetComponent<TextMeshPro>();


        var _sequence = DOTween.Sequence();

        _sequence.Append(DOTween.To(() => text.fontSize, x => text.fontSize = x, maxFontSize, 1f)) // 0.5�b�ŃT�C�Y��13��
                 .Append(DOTween.To(() => text.fontSize, x => text.fontSize = x, minFontSize, 1f)) // 0.5�b�ŃT�C�Y��10��
                 .SetLoops(-1, LoopType.Yoyo);
    }
}
