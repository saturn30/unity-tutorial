using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Background : MonoBehaviour
{
   private float moveSpeed = 3f;
   void Update()
   {
      transform.position += Vector3.down * moveSpeed * Time.deltaTime;
      if(transform.position.y < -12){
         transform.position = new Vector3(0, 12);
      }
   }
}
