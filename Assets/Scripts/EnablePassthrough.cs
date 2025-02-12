using UnityEngine;
using Meta;
using System.Collections;

public class EnablePassthrough : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 0.2f;
    [SerializeField] Camera cam;
    OVRPassthroughLayer passthroughLayer;

    bool passthroughOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        passthroughLayer = FindFirstObjectByType<OVRPassthroughLayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            passthroughOn = !passthroughOn;
            passthroughLayer.enabled = passthroughOn;

            if (passthroughOn) { StartCoroutine(PassthroughFade()); }
            else { StartCoroutine(VirtualFade()); }
        }
    }

    IEnumerator PassthroughFade()
    {
        cam.clearFlags = CameraClearFlags.SolidColor;
        float alpha = 1.0f;
        Color c = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
        cam.backgroundColor = c;
        while (alpha > 0)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            c = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
            cam.backgroundColor = c;
            yield return null;
        }
        alpha = 0;
        cam.backgroundColor = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
    }

    IEnumerator VirtualFade()
    {
        float alpha = 0f;
        Color c = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
        cam.backgroundColor = c;
        while (alpha < 1)
        {
            alpha += fadeSpeed * Time.deltaTime;
            c = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
            cam.backgroundColor = c;
            yield return null;
        }
        alpha = 1;
        cam.backgroundColor = new Color(cam.backgroundColor.r, cam.backgroundColor.g, cam.backgroundColor.b, alpha);
        cam.clearFlags = CameraClearFlags.Skybox;
    }
}
