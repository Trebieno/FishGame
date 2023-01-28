using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private GameObject _panelLoad;
    [SerializeField] private GameObject _timer;

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
        if(_time >= 5)
        {
            _panelLoad.SetActive(false);
            Destroy(_timer);
        }
    }
}
