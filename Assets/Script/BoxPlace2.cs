using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxPlace2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] boxPlaces; // ћеста дл€ €щиков
    public GameObject[] boxes; // ящики

    void Update()
    {
        if (AllBoxesPlaced())
        {
            ChangeScene();
        }
    }

    bool AllBoxesPlaced()
    {
        foreach (GameObject place in boxPlaces)
        {
            bool boxFound = false;
            foreach (GameObject box in boxes)
            {
                if (Vector2.Distance(place.transform.position, box.transform.position) < 0.1f)
                {
                    boxFound = true;
                    break;
                }
            }
            if (!boxFound)
            {
                return false;
            }
        }
        return true;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(6);
    }

}
