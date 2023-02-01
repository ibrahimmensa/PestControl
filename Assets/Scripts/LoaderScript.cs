using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoaderScript : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadSceneProgress");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadSceneProgress()
    {
            AsyncOperation operation = SceneManager.LoadSceneAsync(1);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                yield return null;
            }
    }
}
