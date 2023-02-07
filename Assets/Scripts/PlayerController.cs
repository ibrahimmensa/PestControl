using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject Gun;
    public int PlayerHealth;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Gun.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //this is the angle that the weapon must rotate around to face the cursor
        angle = Mathf.Clamp(angle, -30, 30);
        Quaternion rotation = Quaternion.AngleAxis(angle - 0, Vector3.forward); //Vector 3. forward is z axis
        Gun.transform.rotation = rotation;

        //Touch Input
        if(Input.touchCount > 0)
        {
            Touch TouchInputPos = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(0))
            {
                Vector2 directionTouch = Camera.main.ScreenToWorldPoint(new Vector3(TouchInputPos.position.x, TouchInputPos.position.y,Camera.main.nearClipPlane)) - Gun.transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //this is the angle that the weapon must rotate around to face the cursor
                angle = Mathf.Clamp(angle, -30, 30);
                rotation = Quaternion.AngleAxis(angle - 0, Vector3.forward); //Vector 3. forward is z axis
                Gun.transform.rotation = rotation;
            }
        }
    }
    public void ShootAnimation()
    {
        StartCoroutine(ReturnAnimation());
    }
    IEnumerator ReturnAnimation()
    {
        Gun.transform.localPosition = new Vector3(-0.27f, 0.135f, 0);
        yield return new WaitForSeconds(0.05f);
        Gun.transform.localPosition = new Vector3(-0.25f, 0.135f, 0);
    }
    public void UpdateHealth()
    {
        if(PlayerHealth >= 0)
        {
            healthSlider.value = PlayerHealth;
        }
    }
}
