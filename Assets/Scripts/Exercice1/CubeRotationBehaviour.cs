using System.Collections;
using UnityEngine;

public class CubeRotationBehaviour : MonoBehaviour
{
    // Exercice 1

    public void Rotate()
    {
        StopAllCoroutines();
        StartCoroutine(RotateCube());
    }

    public IEnumerator RotateCube()
    {
        var timer = 0f;

        while (timer < 5f)
        {
            timer += Time.deltaTime;
            gameObject.transform.Rotate(transform.rotation.x + 60, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    public void StopRotation()
    {
        StopAllCoroutines();
    }
}
