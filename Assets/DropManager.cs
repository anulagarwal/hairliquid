using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public static DropManager Instance = null;

    public List<HairStrand> hairStrands;


    public int strandCount;
    public int incorrectCount;
    public int correctPercentage;

    [Header ("Drops")]
    [SerializeField] private List<Drop> drops;
    public bool isBursting;
    private float startTime;
    [SerializeField] private float burstRate;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       
    }
    private void Update()
    {
        if (isBursting)
        {
            if(startTime + burstRate < Time.time)
            {
                startTime = Time.time;
                BurstDrops();
            }
        }
    }


    public void IncorrectStrand(HairStrand strand)
    {
        incorrectCount++;
        if (strandCount + incorrectCount == hairStrands.Count)
        {
            correctPercentage = (strandCount + incorrectCount) / hairStrands.Count;
            Invoke("EndGame", 1.5f);
        }
    }
    public void CompleteStrand(HairStrand strand)
    {
        strandCount++;

        if (strandCount + incorrectCount == hairStrands.Count)
        {
            correctPercentage = (strandCount + incorrectCount) / hairStrands.Count;
            Invoke("EndGame",1.5f);
        }
    }

    public void AddDrop(Drop d)
    {
        drops.Add(d);
    }

    public void RemoveDrop(Drop d)
    {
        drops.Remove(d);
        Destroy(d.gameObject);
    }

    public void EndGame()
    {
        isBursting = true;
    }

    public void BurstDrops()
    {
        if (drops.Count > 0)
        {
            if (drops[0] != null)
            {
                UIManager.Instance.SpawnAwesomeText(drops[0].transform.position, "+1");
                RemoveDrop(drops[0]);
            }
            else
            {
                drops.RemoveAt(0);
            }
        }
        else
        {
            isBursting = false;
            GameManager.Instance.Win();
        }
    }
}
