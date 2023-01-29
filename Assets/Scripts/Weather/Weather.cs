using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    [Header("WeatherObjects")]
    private int index;
    private GameObject _weather => _allWeathers[index];
    [SerializeField] private GameObject []_allWeathers;
    [Header("TimeAction")]
    [SerializeField] private float _timeWeatherActive; //время действия
    [SerializeField] private float _maxTimeWeanterActive; // максимальное время длительности погодного условия
    [SerializeField] private float _minTimeWeanterActive; // минимальное время длительности погодного условия
    [Header("TimerBeforeActivation")]
    [SerializeField] private float _timer; // время до появления погодного условия
    [SerializeField] private float _maxTimerWeanter; // максимальное время длительности ожидания до погодного условия
    [SerializeField] private float _minTimerWeanter; // минимальное время длительности ожидания до погодного условия
    [Header("Other")]
    [SerializeField] private int _size; // размер массива

   private void Start() 
   {
        _timer = Random.Range(_minTimerWeanter, _maxTimerWeanter);
   }
   private void Update() 
   
   {
    WeatherPlay();
   }
   
    private void WeatherPlay()
    { 
        if(_timeWeatherActive > 0)
        {
            _timeWeatherActive -= Time.deltaTime;
        }
        if(_timer > 0 && _timeWeatherActive <= 0)
        {
            _timer -= Time.deltaTime;
        }
        //
        if (_timer <= 0 && _timeWeatherActive <= 0)
        {
            _timeWeatherActive = Random.Range(_minTimeWeanterActive, _maxTimeWeanterActive);

            _weather.SetActive(false);
            index = Random.Range(0, _allWeathers.Length);

            if(!_weather.activeSelf)
            {
                _weather.SetActive(true);
            }
            if(_timer <= 0)
            {
            _timer = Random.Range(_minTimerWeanter, _maxTimerWeanter); 
            }
                        
        }
    }
}
