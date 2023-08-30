using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentCarWaypoint : MonoBehaviour
{
    [Header("Oponent Car")]
    public OponentCar oponentCar;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        oponentCar = GetComponent<OponentCar>();

    }

    private void Start()
    {
        oponentCar.LocalDestination(currentWaypoint.GetPosition());

    }

    private void Update()
    {
        if (oponentCar.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWaypoint;
            oponentCar.LocalDestination(currentWaypoint.GetPosition());
        }
    }

}
