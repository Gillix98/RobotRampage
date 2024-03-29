﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    override protected void Update()
    {
        base.Update();
        //shotgun and pistol have the same fire rate
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime)
            > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
