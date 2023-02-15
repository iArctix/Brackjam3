using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


public class TypeWriter : MonoBehaviour
{
    public TMP_Text textMeshPro;
    public float typingSpeed = 0.05f;

    private void Start()
    {
        StartCoroutine(TypeOutText());
    }

    //Remade it as the other one was dodgy quite simply just goes through making the letters appear in a loop till none left just change speed if u want it faster or slower
    private IEnumerator TypeOutText()
    {
        textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = textMeshPro.textInfo.characterCount;
        int visibleCount = 0;

        while (visibleCount < totalVisibleCharacters)
        {
            int currentCount = visibleCount;
            textMeshPro.maxVisibleCharacters = currentCount;
            while (currentCount <= visibleCount)
            {
                currentCount++;
                textMeshPro.maxVisibleCharacters = currentCount;
                yield return new WaitForSeconds(typingSpeed);
            }
            visibleCount++;
            yield return null;
        }
    }
}