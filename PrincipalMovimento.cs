using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalMovimento : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed = 24f;

    public float smoothTime = 0.1f;

    float smoothSpeed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0f, z).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle =
                Mathf.Atan2(direction.x, direction.z) *
                Mathf.Rad2Deg +
                cam.eulerAngles.y;
            float angle =
                Mathf
                    .SmoothDampAngle(transform.eulerAngles.y,
                    targetAngle,
                    ref smoothSpeed,
                    smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir =
                Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
