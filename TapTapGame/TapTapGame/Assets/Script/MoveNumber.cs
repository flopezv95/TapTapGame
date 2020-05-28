using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNumber : MonoBehaviour
{
    public Vector2 rangeHorizontalSpeed;
    public Vector2 rangeVerticalSpeed;


    private float dirX = 0.0f;
    private float dirY = 0.0f;
    private Vector3 boundaries;
    private Vector3 movableObjectPosition;
    private Rigidbody2D rb;
    private RectTransform rt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        dirX = Random.Range(rangeHorizontalSpeed.x, rangeHorizontalSpeed.y);
        dirY = Random.Range(rangeVerticalSpeed.x, rangeVerticalSpeed.y);
        boundaries = new Vector3(Screen.width, Screen.height,0.0f);
    }
    private void FixedUpdate()
    {
        if (transform.position.x + (rt.rect.width/3)  > boundaries.x || transform.position.x - (rt.rect.width / 3) < 0.0f)
        {
            dirX *= -1;
        }
        if (transform.position.y + (rt.rect.height / 3) > boundaries.y || transform.position.y - (rt.rect.height / 3) < 0.0f)
        {
            dirY *= -1;
        }

        rb.velocity = new Vector2(dirX, dirY);
    }
}
