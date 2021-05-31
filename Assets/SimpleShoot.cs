using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public AudioSource  missaudio;
    public GameObject muzzleFlash;
    public Camera cam;
    public Text tim;
    public Text score;
    public Text accuracy;
    public CanvasGroup fin;
    public Text Final;
    float time=60f;
    int shotsfired=0;
    int shotshit=0;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private float destroyTimer = 2f;


    void Start()
    {
        if (barrelLocation == null){
            //Vector3 v= new Vector3(0,0.0968f,.1795f);
            barrelLocation = transform;
            //barrelLocation.transform.position+=v;
            fin.GetComponent<CanvasGroup>();
        }

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        time-=Time.deltaTime;
        if(time>=0){
            tim.text=time.ToString("0");
            score.text=(shotshit*100).ToString()+"  pts";
            if(shotsfired!=0) accuracy.text=(shotshit*100/shotsfired).ToString("0")+" %";
        }else{
            fin.alpha=1;
            Final.text="Score  :  "+(shotshit*100).ToString()+"  pts\nShots fired  :  "+(shotsfired).ToString()+"\nAccuracy  :  "+(shotshit*100/shotsfired).ToString("0")+" %";
        }
        if(time<=-4){
            Cursor.lockState=CursorLockMode.Confined;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        }
        if (time>=0 && Input.GetButtonDown("Fire1"))
        {
            shotsfired++;
            gunAnimator.SetTrigger("Fire");
            crisp();
        }
    }
    void crisp(){
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,300f)){
            target t =  hit.transform.GetComponent<target>();
            if(t!=null){
                shotshit++;
                t.hit();
            }else missaudio.Play();
        }
    }


    void Shoot()
    {
        if (muzzleFlash)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlash, barrelLocation.position, barrelLocation.rotation);
            Destroy(tempFlash, destroyTimer);
        }
        return;
    }

    void CasingRelease()
    {
    }

}
