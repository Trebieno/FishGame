using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private void Update() => transform.Translate(1, 0, 1 * Time.deltaTime);
}
