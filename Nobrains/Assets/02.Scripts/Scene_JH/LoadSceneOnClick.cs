using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadSceneOnClick : MonoBehaviour, IPointerClickHandler
{
    public void LoadByIndex(int sceneIndex)
    {
    SceneManager.LoadScene (sceneIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
