using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentCar : MonoBehaviour
{
    [Header("Car Engine")]
    public float movingSpeed;
    public float turningSpeed = 50f;
    public float breakSpeed = 12f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

   


    private void Update()
    {
        Drive();

    }
    public void Drive()
    {
           
        
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= breakSpeed)
            {
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //move vehicle
                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }
            else
            {
                destinationReached = true;
            }
        }
    }

    public void LocalDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
}
