using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
   public Transform capsule;

   private void LateUpdate()
   {
    Vector3 newPosition = capsule.position;
    newPosition.y = transform.position.y;
    transform.position = newPosition;

    transform.rotation = Quaternion.Euler(90f, capsule.eulerAngles.y, 0f);
   }
}
