using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Pathfinder : Kinematic
{
    public Node start;
    public Node goal;
    Graph myGraph;

    FollowPath myMoveType;
    LookWhereGoing myRotateType;

    GameObject[] myPath;

    void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        Graph myGraph = new Graph();
        myGraph.Build();
        List<Connection> path = Dijkstra.pathfind(myGraph, start, goal);
        myPath = new GameObject[path.Count + 1];
        int i = 0;
        foreach (Connection c in path)
        {
            Debug.Log("from " + c.getFromNode() + " to " + c.getToNode() + " @" + c.getCost());
            myPath[i] = c.getFromNode().gameObject;
            i++;
        }
        myPath[i] = goal.gameObject;

        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.path = myPath;
    }

    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }

}
