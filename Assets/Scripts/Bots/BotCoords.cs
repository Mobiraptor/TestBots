using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCoords : MonoBehaviour
{
    /*[Header("x")]
    [SerializeField] private float xmin;
    [SerializeField] private float xmax;
    [Header("y")]*/
    [SerializeField] private float y;
    /*[Header("z")]
    [SerializeField] private float zmin;
    [SerializeField] private float zmax;*/

    [SerializeField] private MeshRenderer PlaneBounds;

    private Vector3 CoordVector;
    private Vector3 BotWantedCoords;


    public Vector3 GetBotCoordinates()
    {
        BotWantedCoords = GenerateCoordinates();
        while (Physics.BoxCast(BotWantedCoords, new Vector3(2, 2, 2), new Vector3(2, 2, 2), Quaternion.Euler(0, 0, 0), 2))
        {
            //Debug.Log("changed coords");
            BotWantedCoords = GenerateCoordinates();
            //BotObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        return BotWantedCoords;

    }

    private Vector3 GenerateCoordinates()
    {
        return CoordVector = new Vector3(Random.Range(PlaneBounds.bounds.min.x + 1, PlaneBounds.bounds.max.x - 1), y, Random.Range(PlaneBounds.bounds.min.z + 1, PlaneBounds.bounds.max.z - 1));
    }
}
