using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collider)
    {
        print("colliding");
        if (collider.name == "Boundary")
        {
            print("colliding on boundary");
            var boxCollider = collider.GetComponent<BoxCollider2D>();
            float posX = transform.position.x;
            float posY = transform.position.y;

            if (posX <= boxCollider.bounds.min.x || posX >= boxCollider.bounds.max.x)
            {
                posX = transform.position.x * -1;
            }

            if (posY <= boxCollider.bounds.min.y || posY >= boxCollider.bounds.max.y)
            {
                posY = transform.position.y * -1;
            }


            transform.position = new Vector3(posX, posY, 0);
        }
    }
}
