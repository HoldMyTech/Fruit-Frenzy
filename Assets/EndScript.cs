using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScript : MonoBehaviour
{
    //public AudioClip SoundEffect4;
    public AudioSource AS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //AS.PlayOneShot(SoundEffect4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Title"); 
        } 
    }
}