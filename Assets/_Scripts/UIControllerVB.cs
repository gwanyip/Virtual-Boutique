using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Common;
using VRStandardAssets.Utils;

public class UIControllerVB : MonoBehaviour
{
    [SerializeField] private UIFader m_IntroUI;     // End video CTAs
    [SerializeField] private UIFader m_OutroUI;     // End video CTAs

    public IEnumerator ShowIntroUI()
    {
        // Wait for the outro to fade in.
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeIn());
    }


    public IEnumerator HideIntroUI()
    {
        // Wait for the outro to fade out.
        yield return StartCoroutine(m_IntroUI.InteruptAndFadeOut());
    }

    public IEnumerator ShowOutroUI()
{
    // Wait for the outro to fade in.
    yield return StartCoroutine(m_OutroUI.InteruptAndFadeIn());
}


public IEnumerator HideOutroUI()
{
    // Wait for the outro to fade out.
    yield return StartCoroutine(m_OutroUI.InteruptAndFadeOut());
}
}
