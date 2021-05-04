﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : Kinematic
{
    ObstacleAvoidance myMoveType;
    LookWhereGoing myRotateType;

    void Start()
    {
        myMoveType = new ObstacleAvoidance();
        myMoveType.character = this;
        myMoveType.target = myTarget;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
