using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShop : MonoBehaviour
{
    [SerializeField] private GameObject _shopBuyer;
    [SerializeField] private GameObject _shopFishingRods;
    [SerializeField] private GameObject _shopBoat;

    public void SetStateShop(GameObject shop ,bool state) => shop.SetActive(state);
}
