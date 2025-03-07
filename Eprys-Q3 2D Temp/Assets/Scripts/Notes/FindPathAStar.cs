using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class PathMarker
{
    public MapLocation location;
    public float G;
    public float H;
    public float F;
    public GameObject marker;
    public PathMarker parent;
}

//public PathMarker(MapLocation l, float g, float h, float f, GameObject marker, PathMarker p)
//{
//    location = l;
//    G = g;
//}



