using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoard : MonoBehaviour
{
    [SerializeField] List<Sprite> storyBoards;

    [SerializeField] Image image;
    [SerializeField] Button btn;

    [SerializeField] List<GameObject> gameObjects;

    int index = 0;

    private void Awake()
    {
        foreach (GameObject i in gameObjects)
        {
            i.SetActive(false);
        }

        image.sprite = storyBoards[index];
        image.gameObject.SetActive(true);
        btn.gameObject.SetActive(true);
    }

    public void NextButton()
    {
        index++;
        Debug.Log(index);
        if(index < storyBoards.Count)
        {
            image.sprite = storyBoards[index];
        }
        else
        {
            foreach(GameObject i in gameObjects)
            {
                i.SetActive(true);
            }

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
