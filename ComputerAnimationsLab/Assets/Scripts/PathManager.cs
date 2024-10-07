using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{


    [HideInInspector]
    [SerializeField]
    public List<Waypoints> path;

    public GameObject prefab;
    int currentPointIndex = 0;

    public List<GameObject> prefabPoints;

    public List<Waypoints> GetPath()
    {
        if (path == null)
            path = new List<Waypoints>();
        return path;
    }

    public void CreateAddPoint()
    {
        Waypoints go = new Waypoints();
        path.Add(go);
    }

    public Waypoints GetNextTarget()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);
        currentPointIndex = nextPointIndex;
        return path[currentPointIndex]; 
    }

    public void Start()
    {
        prefabPoints = new List<GameObject>();
        foreach( Waypoints p in path )
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go); 
        }
    }

    public void Update()
    {
        for(int i = 0; i < path.Count; i++)
        {
            Waypoints p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }

}
