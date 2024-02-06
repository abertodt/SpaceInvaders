using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int _points;

    private void OnDestroy()
    {
        GameManager.Instance.Points += _points;
    }
}
