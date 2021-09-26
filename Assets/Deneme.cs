using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{

  // f(n) = 4n - 2 formülü ile çembersel obje dağılımı. Bu formül ile halka başına düşen obje sayısını belirliyoruz.
    
   // radiusGap değişkeni, halkalar arasındaki mesafe (dairesel oluşum halka halka oluyor)
   public float radiusGap;
   public int objectCount;
   public GameObject objectPrefab;

   private void Start()
   {
     CreateCirclerPositionedObjects();
   }

   private void CreateCirclerPositionedObjects()
    {
      var spawnCenter = transform.position;
         
      var tempCount = objectCount;
      var tempDistance = 0f;
      var x = 1;
         
      for (int n = 1; tempCount > 0; n = (4 * x) - 2)
      {
        for (int i = 0; i < n && tempCount > 0; i++)
        {
          /* Çember etrafındaki mesafe */  
          var radians = 2 * ((Mathf.PI / n) * i);
         
          /* Vektör yönleri */ 
          var vertical = Mathf.Sin(radians);
          var horizontal = Mathf.Cos(radians); 
         
          var spawnDir = new Vector3 (horizontal, 0, vertical);
         
          /* Spawn pozisyonu */ 
          var spawnPos = spawnCenter + spawnDir * tempDistance;
         
          /* Yaratma */
          var obj = Instantiate (objectPrefab, spawnPos, Quaternion.identity, transform);
    
          tempCount--;
        }
    
        x++;
        tempDistance += radiusGap;
      }
    }
}
