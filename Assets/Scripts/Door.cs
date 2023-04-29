using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform doorPosition;
    public bool open = false;
    float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        doorPosition.position = closePosition.position;
    }

    public void OpenClose()
    {
        open = !open;
    }
    // Update is called once per frame
    void Update()
    {
        if(open && Vector3.Distance(doorPosition.position,openPosition.position) > 0.001f)
        {
            doorPosition.position = Vector3.MoveTowards(doorPosition.position,openPosition.position,
                Time.deltaTime * speed);
        }
        if(!open && Vector3.Distance(doorPosition.position,closePosition.position) > 0.001f)
        {
            doorPosition.position = Vector3.MoveTowards(doorPosition.position, closePosition.position,
                Time.deltaTime * speed);
        }
    }
}
