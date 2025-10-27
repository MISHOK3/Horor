using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2Script : MonoBehaviour
{
    public GameObject door;
    public float delay = 5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kay2"))
        {
            StartCoroutine(DeactivateAndReactivate());
        }
    }

    private IEnumerator DeactivateAndReactivate()
    {
        // выключаем дверь
        door.SetActive(false); // "открываем" дверь — можно пройти
        yield return new WaitForSeconds(delay);
        door.SetActive(true); 
        // завершаем корутину
        yield break;
    }
}
