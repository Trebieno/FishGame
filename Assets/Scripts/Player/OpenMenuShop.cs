using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuShop : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuyerShop;
    [SerializeField] private GameObject _buttonFishingRodShop;
    [SerializeField] private GameObject _buttonBoatShop;

    private void SetState(GameObject buttonShop, bool state) => buttonShop.SetActive(state);

    private void OnTriggerStay2D(Collider2D collision)
    {
       switch (collision.gameObject.tag) 
       {
            case "ShopBuyer":
                SetState(_buttonBuyerShop, true);
                break;
                
            case "ShopFishingRods":
                SetState(_buttonFishingRodShop, true);
                break;
            
            case "ShopBoat":
                SetState(_buttonBoatShop, true);
                break;
       }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "ShopBuyer":
                SetState(_buttonBuyerShop, false);
                break;

            case "ShopFishingRods":
                SetState(_buttonFishingRodShop, false);
                break;
            
            case "ShopBoat":
                SetState(_buttonBoatShop, false);
                break;
        }
    }
}

