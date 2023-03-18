using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
   SpriteRenderer blood;
   
    // Start is called before the first frame update
    void Start()
    {
        blood = GetComponent<SpriteRenderer>();
        Color color = blood.material.color;
        color.a = 0f;
        blood.material.color = color;

        StartCoroutine("Fadeout");
    }

    IEnumerator Fadeout()
    {
        for (float f = 1; f >= -0.05; f -= 0.05f)
        {
            Color color = blood.material.color;
            color.a = f;
            blood.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
