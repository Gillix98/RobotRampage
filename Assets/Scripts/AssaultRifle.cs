﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Gun
{
    protected override void Update()
    {
        base.Update();
        //automatic fire
        if (Input.GetMouseButtonDown(0) && Time.time - lastFireTime > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
