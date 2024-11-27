using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class ResultSceneManager : MonoBehaviour
{
    [SerializeField] private Image resultPanelImage;
    [SerializeField] private TextMeshProUGUI resultText;

    private float delayTime = 4f;
    [SerializeField] private float fadeDuration = 3f;
    //2�b�҂���
    // Start is called before the first frame update
    void Start()
    {
        Invisible(transform);

        DOVirtual.DelayedCall(delayTime, () =>
        {
            FadeIn();
        });
    }

    void Invisible(Transform parent)
    {
        if (resultPanelImage != null)
        {
            Color color = resultPanelImage.color;
            color.a = 0f;
            resultPanelImage.color = color;
        }

        if (resultText != null)
        {
            Color color = resultText.color;
            color.a = 0f;
            resultText.color = color;
        }
    }

    void FadeIn()
    {
        // �p�l���̓����x���t�F�[�h�C��
        if (resultPanelImage != null)
        {
            resultPanelImage.DOFade(0.8f, fadeDuration);
        }
        // �e�L�X�g�iText�j�̓����x���t�F�[�h�C��
        if (resultText != null)
        {
            resultText.DOFade(1f, fadeDuration);
        }
    }
}
