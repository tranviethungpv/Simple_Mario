using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = Mathf.Abs(Player.transform.position.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + distance, transform.position.z);
    }
}
