using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float moveSpeed = 1f;

    private void FixedUpdate()
    {
        Vector2 temp = transform.position;
        if (Input.GetAxis("Horizontal") > 0)
        {
            temp.x += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            temp.x -= moveSpeed * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            temp.y += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            temp.y -= moveSpeed * Time.deltaTime;
        }

        transform.position = temp;
    }
}
