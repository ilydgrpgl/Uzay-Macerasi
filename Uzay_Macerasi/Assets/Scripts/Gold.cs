using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // platforma vermemizin nedeni altýn spriteni açýp kapayacak
    [SerializeField]
    GameObject gold = default;

    public void GoldOpen()
    {
        gold.SetActive(true);
    }
    public void GoldClose()
    {
        gold.SetActive(false);
    }

}
