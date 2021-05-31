using UnityEngine;

public class target : MonoBehaviour
{
    public AudioSource hitaudio;
    void Start(){
        GetComponent<Transform>();
    }
    void Update()
    {
        
    }
    public void hit(){
        hitaudio.Play();
        float x = Random.value;
        float y = Random.value;
        float s= Random.value;
        Vector3 v = new Vector3((x-.5f)*140,(y-.15f)*60,100);
        Vector3 k = new Vector3((s+0.6f)*10,(s+0.6f)*10,(s+0.6f)*10);
        transform.position=v;   
        transform.localScale= k;
    }
}
