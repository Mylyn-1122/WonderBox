using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class SceneLoader : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string SceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        LoadScene();
    }
}
