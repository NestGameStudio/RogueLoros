﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> SpellTypes;

    private SpellType currentType = SpellType.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
