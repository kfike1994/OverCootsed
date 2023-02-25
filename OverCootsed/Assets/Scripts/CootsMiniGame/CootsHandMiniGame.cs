using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CootsHandMiniGame : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0.1f,1)]float movementFactor;

    [SerializeField] float handspeed;
    [SerializeField] float clickpower;
    private float update;

        void Awake()
    {
        update = 0.0f;
    }
    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        update += Time.deltaTime;
        if (update > 5.0f)
        {
            Vector3 offset = movementVector  * movementFactor;
            transform.position = startingPosition + offset;
        
            if(movementFactor < 1)
            {
                 movementFactor = movementFactor +handspeed*Time.deltaTime;
            }
        
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                movementFactor = movementFactor -clickpower;
            }
         
            if(movementFactor > 1)
            {
                Lose();
            }

            if(transform.position.x > 3.1f || update >= 35f)
            {
                Win();
            }
        }
    }
    void Lose()
    {
        Debug.Log("you LOSE");

        PlayerPrefs.SetInt("rating", 0);
        SceneManager.LoadScene("ScoreScreen");
    }
    void Win()
    {
        Debug.Log("win");
        PlayerPrefs.SetInt("rating", 1);
        SceneManager.LoadScene("ScoreScreen");
    }
}
