using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material material;
    private float fade;
    public bool IsDissolving { get; set; }

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        fade = 1f;
        IsDissolving = false;
    }

    void Update()
    {
        if(IsDissolving)
        {
            fade -= Time.deltaTime;

            if(fade <= 0f)
            {
                fade = 0f;
                IsDissolving = false;
            }
        }

        material.SetFloat("_Fade", fade);
    }

    public void resetFade()
    {
        fade = 1f;
    }
}
