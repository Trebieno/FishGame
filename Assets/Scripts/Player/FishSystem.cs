using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fishsystem //����� �������� ������ � ����� ������� �������� ���� namespace � ����������
{
    public class FishSystem : MonoBehaviour
    {
        public int baitindex = 1; //������ �������
        public int fishrank;  //������ ���� (���� �������� ����� ������ ������
        [SerializeField] GameObject buttonToInventory; //������ � ���������
        [SerializeField] GameObject buttonToFish; //������ � �������
        public void FishRank() //��� ������� �������� ��� ������� ���� � �������
        {
            if (baitindex == fishrank)
            {
                ChooseAct();

            }
            //�������� ������� ������ ���� �����

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
            //�������� ���� � ��������� (� �� ����� ���� ���� ���������)
        }
    }
}

