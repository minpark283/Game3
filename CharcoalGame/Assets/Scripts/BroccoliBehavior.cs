using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BroccoliBehavior : MonoBehaviour {

    public float speed;
    public float attackRange;
    public GameObject player;

    public GameObject hitBox;

    NavMeshAgent navAgent;

    public int health;

    public float[,] grid;

    bool doStuff = false;

    //public GameObject player;
    
	// Use this for initialization
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.Warp(this.transform.position);
        //navAgent.speed = speed;
        navAgent.destination = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Come up with some condition to prevent doing pathfinding every frame
        //print(this.transform.position.x);
        //print(this.transform.position.z);
        //print(Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
        //    + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))));
        if (Mathf.Sqrt(((this.transform.position.x - player.transform.position.x) * (this.transform.position.x - player.transform.position.x))
            + ((this.transform.position.z - player.transform.position.z) * (this.transform.position.z - player.transform.position.z))) <= attackRange)
        {
            if (navAgent.isStopped != true)
                navAgent.isStopped = true;
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.destination = player.transform.position;
        }
		
	}

    void Hit(int damage)
    {
        //Deal damage and check for death
        health = health - damage;
        if(health <= 0)
        {
            //play a death animation maybe?
            this.Die();
        }
        //Possibly a hit animation?
    }

    void Die()
    {
        //Put other stuff, like animations, in here
        GameObject.Destroy(this);
    }

    /*List<Vector2> FindPath(int targX, int targZ)
    {
        //print("targ is " + targX + " " + targZ);
        bool found = false;
        Dictionary<Vector2, int> dist = new Dictionary<Vector2, int>();
        Dictionary<Vector2, Vector2> prev = new Dictionary<Vector2, Vector2>();

        for(int x = 0; x < grid.GetLength(0); x++)
        {
            for(int z = 0; z < grid.GetLength(1); z++)
            {
                dist[new Vector2(x, z)] = int.MaxValue;
                prev[new Vector2(x, z)] = new Vector2(-1,-1);
            }
        }

        List<Vector2> queue = new List<Vector2>();
        Vector2 startLoc = new Vector2(Mathf.FloorToInt(this.transform.position.x) + 5, Mathf.FloorToInt(this.transform.position.z) + 5);

        dist[startLoc] = 0;
        //print("targ is " + targX + " " + targZ);
        queue.Add(startLoc);

        while(queue.Count != 0)
        {
            int smallest = 0;
            for(int x = 0; x < queue.Count; x++)
            {
                if(dist[queue[x]] < dist[queue[smallest]])
                    smallest = x;
            }

            foreach(Vector2 node in GetPossibleMoves(Mathf.RoundToInt(queue[smallest].x), Mathf.RoundToInt(queue[smallest].y)))
            {
                //print("move from " + queue[smallest] + " is: " + node);
                if (node.x == targX && node.y == targZ)
                {
                    found = true;
                    int alt = dist[queue[smallest]] + 1;
                    if (alt < dist[new Vector2(targX, targZ)])
                    {
                        prev[node] = queue[smallest];
                        dist[node] = alt;
                    }
                }

                else
                {
                    //print(node);
                    if (dist[node] == int.MaxValue)
                        queue.Add(node);

                    int alt = dist[queue[smallest]] + 1;

                    if (alt < dist[node])
                    {
                        dist[node] = alt;
                        prev[node] = queue[smallest];
                    }
                }
            }
            queue.Remove(queue[smallest]);
        }

        if(found)
        {
            List<Vector2> ret = new List<Vector2>();
            Vector2 current = new Vector2(targX, targZ);
            while(prev[current] != new Vector2(-1,-1))
            {
                ret.Add(prev[current]);
                current = prev[current];
            }

            ret.Reverse();
            return ret;
        }
        else 
            return null;
    }

    List<Vector2> GetPossibleMoves(int x, int z)
    {
        //print(grid.GetLength(0) + " " + grid.GetLength(1));

        
        List<Vector2> ret = new List<Vector2>();
        if (x + 1 < grid.GetLength(0) && z + 1 < grid.GetLength(1))
        {
            //print("possible move: " + (x + 1) + " " + (z + 1));
            if (grid[x + 1, z + 1] != 1)
                ret.Add(new Vector2(x + 1, z + 1));
        }

        if (x + 1 < grid.GetLength(0))
            if(grid[x + 1, z] != 1)
                ret.Add(new Vector2(x + 1, z));

        if (x + 1 < grid.GetLength(0) && z - 1 >= 0)
            if(grid[x + 1, z - 1] != 1)
                ret.Add(new Vector2(x + 1, z - 1));

        if (z - 1 >= 0)
            if(grid[x, z - 1] != 1)
                ret.Add(new Vector2(x, z - 1));

        if (x - 1 >= 0 && z - 1 >= 0)
            if(grid[x - 1, z - 1] != 1)
                ret.Add(new Vector2(x - 1, z - 1));

        if (x - 1 >= 0)
            if(grid[x - 1, z] != 1)
                ret.Add(new Vector2(x - 1, z));

        if (x - 1 >= 0 && z + 1 < grid.GetLength(1))
            if(grid[x - 1, z + 1] != 1)
                ret.Add(new Vector2(x - 1, z + 1));

        if (z + 1 < grid.GetLength(1))
            if(grid[x, z + 1] != 1)
                ret.Add(new Vector2(x, z + 1));

        return ret;
    }

    void GiveGrid(float[,] newGrid)
    {
        grid = newGrid;
        print("got here to GiveGrid");
        doStuff = true;
    }*/
}
