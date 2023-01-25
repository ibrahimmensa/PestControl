using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Gun.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //this is the angle that the weapon must rotate around to face the cursor

        Quaternion rotation = Quaternion.AngleAxis(angle - 0, Vector3.forward); //Vector 3. forward is z axis

        Gun.transform.rotation = rotation;
    }
}
