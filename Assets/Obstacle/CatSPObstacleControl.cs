using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSPObstacleControl : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource slipThud;
    public GameObject mainCam;
    public GameObject levelControl;

    [SerializeField] private EndRunSequence endRunSequence;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Catslide");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        slipThud.Play();
        mainCam.GetComponent<Animator>().enabled = true;
        levelControl.GetComponent<EndRunSequence>().enabled = true;

        StaticData.IsStart = false;
        StaticData.IsEnd = true;

        StartCoroutine(endRunSequence.EndSequence());
    }
}
