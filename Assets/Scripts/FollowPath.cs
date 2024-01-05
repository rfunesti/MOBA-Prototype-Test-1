using UnityEngine;

// This script sends orders to NavMover to follow the path
[RequireComponent(typeof(NavMover))]
public class FollowPath : MonoBehaviour, ITask
{
    NavMover navMover;
    public NavPath path;
    public int pathIndex;
    public bool followInReverse = false;

    void Awake() => navMover = GetComponent<NavMover>();

    // Update is called once per frame
    // We'll repurpose this script as a Task,
    // by adding the ITask interface and change Update() to Evaluate()
    public bool Evaluate()
    {
        if (!path) return false;

        if (navMover.DestinationReached(path.pathPoints[pathIndex]))
        {
            pathIndex = followInReverse ? pathIndex - 1 : pathIndex + 1;

            if (path.loop)
            {
                if (pathIndex < 0) pathIndex = path.pathPoints.Count - 1;
                if (pathIndex >= path.pathPoints.Count) pathIndex = 0;
            }
            else
            {
                pathIndex = Mathf.Clamp(pathIndex, 0, path.pathPoints.Count - 1);
            }
        }

        navMover.Destination = path.pathPoints[pathIndex];
        return true;
    }
}
