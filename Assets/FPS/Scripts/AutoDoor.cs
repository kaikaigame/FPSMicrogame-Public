using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public float openDuration = 0.5f;
    public float openDist;
    public Transform doorObj;
    public Vector3 openDir;

    public bool canClose = true;
    Vector3 originPos;

    void Start()
    {
        originPos = doorObj.localPosition;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveDoor(false));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!canClose)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveDoor(true));
        }
    }

    IEnumerator MoveDoor(bool isClosing)
    {
        float percent = 0f;

        while (percent < 1)
        {
            percent += Time.deltaTime / openDuration;

            if (isClosing)
            {
                doorObj.localPosition = Vector3.Lerp
                    (originPos + openDir * openDist, originPos, percent);
            }
            else
            {
                //平滑移动
                doorObj.localPosition = Vector3.Lerp
                    (originPos, originPos + openDir * openDist, percent);
            }

            yield return null;
        }
    }
}
