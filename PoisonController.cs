using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ł̋������Ǘ����鏈��
/// </summary>
public class PoisonController : MonoBehaviour
{
    [SerializeField] private GameObject mushParent;
    Mushroom mushroom;
    private BoxCollider poisonCollider;private GameObject player;
    void Start()
    {
        poisonCollider = GetComponent<BoxCollider>();
        poisonCollider.enabled = false;
        mushroom = mushParent.GetComponent<Mushroom>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(mushroom.CanShotPoison == false)
        {
            poisonCollider.enabled = true;
        }
        else
        {
            poisonCollider.enabled = false;
        }
    }

    /// <summary>
    /// �ł��v���C���[�ɐڐG���Ă���Ƃ��̏���
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            mushroom = mushParent.GetComponent<Mushroom>();
            if (mushroom.CanShotPoison == true)
            {
                Debug.Log("canShotPoison");
                
            }
            else
            {
                PlayerParameter playerParameter = player.GetComponent<PlayerParameter>();
                playerParameter.PlayerTakePoison();
                playerParameter.TakePoison = true;
            }
        }
    }
}
