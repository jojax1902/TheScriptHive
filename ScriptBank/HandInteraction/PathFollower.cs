using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Kinematic
{
    FollowPath myMoveType;
    LookWhereGoing myRotateType;

    public GameObject[] myWayPts;

    // Start is called before the first frame update
    private void Awake()
    {
        myWayPts[0] = GameObject.FindGameObjectWithTag("Waypoint01");
        myWayPts[1] = GameObject.FindGameObjectWithTag("Waypoint02");
        myWayPts[2] = GameObject.FindGameObjectWithTag("Waypoint03");
        myWayPts[3] = GameObject.FindGameObjectWithTag("Waypoint04");
    }
    void Start()
    {


        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.wayPts = myWayPts;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;


    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
