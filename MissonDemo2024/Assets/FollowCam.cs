using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // Static point of intrest (POI)

    [Header("Inscribed")]
    public float easing = 0.05f; 
    public Vector2 minXY = Vector2.zero; //Vector.zero is [0,0]

    [Header("Dynamic")] //Desired Z pos of the camera 
     public float camZ; 


     void Awake(){  
        camZ = this.transform.position.z;
    }

    void FixedUpdate() //A single-line if statement doesnt require braces 
    {
        if (POI == null) { return; }
        //Get the position of the poi 
        Vector3 destination = POI.transform.position;
        //Limit the minimum values of destination.x and destination.y
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //Interpolate form the current Camrea position toward destination 
        destination = Vector3.Lerp(transform.position, destination, easing);
        //Force destionation.z to be camZ to keep the camrea far enough away  
        destination.z = camZ;
        //Set the camrea to the desitination 
        transform.position = destination;
    }
    
}
