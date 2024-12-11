using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    private float outlineThickness = 0.01f;
   public void ApplyOutline(GameObject obj)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material[] materials = renderer.materials;
                if (materials[1].HasProperty("_OutlineThickness"))
                    materials[1].SetFloat("_OutlineThickness", outlineThickness);
            }
        }
    }

    public void RemoveOutline(GameObject obj)
    {
        if (obj != null)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                Material[] materials = renderer.materials;
                if (materials[1].HasProperty("_OutlineThickness"))
                    materials[1].SetFloat("_OutlineThickness", 0.0f);
            }
        }
    }
}
