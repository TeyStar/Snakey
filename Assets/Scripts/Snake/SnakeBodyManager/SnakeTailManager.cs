using UnityEngine;
using System.Collections.Generic;

public class SnakeTailManager : MonoBehaviour
{
    private List<Transform> tailTransforms = new List<Transform>();

    public void Initialize(Transform headTailTransform)
    {
        tailTransforms.Add(headTailTransform);
    }

    public void AddTailTransform(Transform tailTransform)
    {
        tailTransforms.Add(tailTransform);
    }

    public void RemoveTailTransform(Transform tailTransform)
    {
        tailTransforms.Remove(tailTransform);
    }

    public Transform GetTailTransform(int index)
    {
        if (index >= 0 && index < tailTransforms.Count)
        {
            return tailTransforms[index];
        }
        else
        {
            Debug.LogError("Invalid tail transform index");
            return null;
        }
    }

    public Transform GetTailEnd()
    {
        return GetTailTransform(tailTransforms.Count - 1);
    }

    public void ReverseList()
    {
        tailTransforms.Reverse();
    }
}
