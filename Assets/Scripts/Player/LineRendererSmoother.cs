using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LineRendererSmoother : MonoBehaviour
{
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Vector3[] _initialState;
    [SerializeField] private float _smoothingLenght = 2;
    [SerializeField] private float _smoothingSections = 10;
}
