using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    // platforma vermemizin nedeni alt�n spriteni a��p kapayacak
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
