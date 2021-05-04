using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoider : Kinematic
{
    AvoidCollision myMoveType;
    LookWhereGoing myRotateType;

    public Kinematic[] myTargets;

    void Start()
    {
        myMoveType = new AvoidCollision();
        myMoveType.myCharacter = this;
        myMoveType.myTargets = myTargets;

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
