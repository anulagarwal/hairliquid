using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header ("Attributes")]
    public List<Sound> sounds;

    [Header("Component References")]
    public AudioSource source;
    public static SoundManager Instance = null;

    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(EnumsManager.Sound type)
    {
        source.clip = sounds.Find(x => x.type == type).clip;

        source.Play();
    }
}
