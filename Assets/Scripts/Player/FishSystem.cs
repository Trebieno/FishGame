using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fishsystem //чтобы получить доступ к этому скрипту добавьте этот namespace в библиотеки
{
    public class FishSystem : MonoBehaviour
    {
        public int baitindex = 1; //индекс наживки
        public int fishrank;  //индекс рыбы (надо задавать через другой скрипт
        [SerializeField] GameObject buttonToInventory; //кнопка в инвентарь
        [SerializeField] GameObject buttonToFish; //кнопка в наживку
        public void FishRank() //это функцию вызывать при касании рыбы и наживки
        {
            if (baitindex == fishrank)
            {
                ChooseAct();

            }
            //реализую систему укусов чуть позже

        }


        void ChooseAct()
        {
            buttonToFish.SetActive(true);
            buttonToFish.SetActive(false);
        }

        public void tofishbutton()
        {
            baitindex += 1;
        }
        public void toinventorybutton()
        {
            //добавить рыбу в инвентарь (я не нашел куда надо добавлять)
        }
    }
}

