using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalCollsion : MonoBehaviour
{
    private GameObject[] arr;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        arr = GameObject.FindGameObjectsWithTag("letter");
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            bool allInactive = true;
            foreach (GameObject objects in arr)
            {
                if (objects.activeInHierarchy)
                {
                    allInactive = false;
                    break;
                }
            }
            if (allInactive)
            {
                done = true;
                Debug.Log("Done");
                GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!done && !other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            //Debug.Log(counter);
        } else if (done)
        {
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("End");
        }
    }
}
