using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    void Update()
    {
        ////�X�y�[�X�L�[��������particle���Đ�
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("WADA");
        //    particle.Play();
        //}
        ////���V�t�g�L�[���N���b�N�����particle���~
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    Debug.Log("WWWW");
        //    particle.Stop();
        //}
    }
}
