using System.Collections;
using UnityEngine;

public class SkyboxBlend : MonoBehaviour
{
    public Material[] skyboxes;
    public float transitionDuration = 1f;

    private bool transitionStarted;

    public void skyboxBlend()
    {
        if (transitionStarted || skyboxes == null || skyboxes.Length < 2 ||
            skyboxes[0] == null || skyboxes[1] == null)
            return;

        transitionStarted = true;
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        const string exposure = "_Exposure";
        Material current = new Material(skyboxes[0]);
        Material next = new Material(skyboxes[1]);
        float currentExposure = current.GetFloat(exposure);
        float nextExposure = next.GetFloat(exposure);
        float halfDuration = Mathf.Max(0f, transitionDuration) * 0.5f;

        RenderSettings.skybox = current;
        yield return Fade(current, currentExposure, 0f, halfDuration);

        next.SetFloat(exposure, 0f);
        RenderSettings.skybox = next;
        yield return Fade(next, 0f, nextExposure, halfDuration);

        RenderSettings.skybox = skyboxes[1];
        DynamicGI.UpdateEnvironment();
        Destroy(current);
        Destroy(next);
    }

    private static IEnumerator Fade(Material skybox, float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            skybox.SetFloat("_Exposure", Mathf.Lerp(from, to, elapsed / duration));
            yield return null;
        }

        skybox.SetFloat("_Exposure", to);
    }
}
