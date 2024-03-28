using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour
{
    Vector3 DefaultScale = new Vector3(1f, 1f, 1f);

    Vector3 HomePosition = new Vector3(-21f, 1.22f, -2f);
    Vector3 HomeRotation = new Vector3(0f, 90f, 0f);

    Vector3 MirrorPosition = new Vector3(4f, 0f, -20f);
    Vector3 MirrorRotation = new Vector3(0f, 180f, 0f);

    
    Vector3 ElevatorPosition = new Vector3(2.738f, -1.335f, 0.798f);
    Vector3 ElevatorRotation = new Vector3(0f, -90f, 0f);
    Vector3 ElevatorScale = new Vector3(0.13f, 0.13f, 0.13f);

    Vector3 PlazaPosition = new Vector3(0.36f, -474f, 42f);
    Vector3 PlazaRotation = new Vector3(0f, 180f, 0f);
    Vector3 PlazaScale = new Vector3(80f, 80f, 80f);
    static bool isCreated = false;

    public GameObject player;
    

    void Start()
    {
        HairController hairController = GetComponent<HairController>();
        hairController.enabled = false;

        if (isCreated)
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        isCreated = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        HairController hairController = GetComponent<HairController>();
        CharacterMove characterMove = GetComponent<CharacterMove>();
        hairController.enabled = false;

        if (scene.name == "Mirror")
        {
            
            characterMove.enabled = false;
            player.SetActive(true);
            transform.position = MirrorPosition;
            transform.rotation = Quaternion.Euler(MirrorRotation);
            transform.localScale = DefaultScale;
            hairController.enabled = true;
        }
        else if (scene.name == "Plaza_verse")
        {
            characterMove.enabled = true;
            player.SetActive(true);
            transform.position = PlazaPosition;
            transform.rotation = Quaternion.Euler(PlazaRotation);
            transform.localScale = PlazaScale;
            hairController.enabled = false;
        }
        else if (scene.name == "Elevator")
        {
            characterMove.enabled = true;
            player.SetActive(true);
            transform.position = ElevatorPosition;
            transform.rotation = Quaternion.Euler(ElevatorRotation);
            transform.localScale = ElevatorScale;
            hairController.enabled = false;
        }

        else if (scene.name == "HomeMinju")
        {
            characterMove.enabled = true;
            player.SetActive(true);
            transform.position = HomePosition;
            transform.rotation = Quaternion.Euler(HomeRotation);
            transform.localScale = DefaultScale;
            hairController.enabled = false;
        }

        else if (scene.name == "furnitureChange")
        {
            player.SetActive(false);
        }
    }
}
