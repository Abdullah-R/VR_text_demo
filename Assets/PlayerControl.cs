using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerControl : MonoBehaviour
{
    public float totalTime = 0.0f;
    public int speed = 0;
    public float rotSpeed = 0.0f;
    public GameObject greyWall;
    public GameObject redWall;
    public GameObject greenWall;
    public GameObject pinkWall;
    public GameObject yellowWall;
    public GameObject purpleWall;
    public GameObject orangeWall;

    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        // get input data from keyboard or controller
        float rotate = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");
        // update player position based on input
        Vector3 position = transform.position;
        position.x += moveForward * speed * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
        position.z += moveForward * speed * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
        transform.Rotate(0.0f, rotate * rotSpeed, 0.0f);

        transform.position = position;

        totalTime += Time.deltaTime;
        if(totalTime > 1.0f)
        {
            StartCoroutine(GetText());
            totalTime = 0.0f;
        }
    }

    IEnumerator GetText()
    {
        //first request receives texted data
        UnityWebRequest www = UnityWebRequest.Get("https://abdullah-r.api.stdlib.com/rifftext@dev/row1/");
        //second request resets database
        UnityWebRequest www2 = UnityWebRequest.Get("https://abdullah-r.api.stdlib.com/rifftext@dev/clearRow/");
        yield return www.SendWebRequest();
        string[] nouns = www.downloadHandler.text.Split('"');
        string finalString = nouns[3];
        // interprets message
        if (!finalString.Equals("default"))
        {
            yield return www2.SendWebRequest();

            if (finalString.Equals("Begin maze"))
            {
                Destroy(greyWall);
            }
            else if (finalString.Equals("Red"))
            {
                Destroy(redWall);
            }
            else if (finalString.Equals("Green"))
            {
                Destroy(greenWall);
            }
            else if (finalString.Equals("Pink"))
            {
                Destroy(pinkWall);
            }
            else if (finalString.Equals("Yellow"))
            {
                Destroy(yellowWall);
            }
            else if (finalString.Equals("Purple"))
            {
                Destroy(purpleWall);
            }
            else if (finalString.Equals("Orange"))
            {
                Destroy(orangeWall);
            }


        }

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(finalString);
        }
    }
}
