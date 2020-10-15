using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactive : MonoBehaviour
{
    public static ActiveDesactive instnacia;
    [SerializeField]private GameObject StartLastBattle;
    private void Awake()
    {
        if (instnacia == null) instnacia = this;
    }
    public GameObject _startLastBattle
    {
        get => StartLastBattle;
        set => StartLastBattle = value;
    }
  
    void Update()
    {
        
    }
  
}
