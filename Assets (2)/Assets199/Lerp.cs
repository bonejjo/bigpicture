using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Lerp : MonoBehaviour {
    public int sceneCnt=0;
	public int count;
	public float timeTakenDuringLerp = 1f;
	//public float distanceToMove = 0.01f;
	private bool _isLerping;
	private Vector3 _startPosition;
	private Vector3 _endPosition;
	private float _timeStartedLerping;
    public bool check = true;
    GameObject g;
    private void Start()
    {
        g = GameObject.FindGameObjectWithTag("pic");
    }
    void StartLerping()
	{
		_isLerping = true;
		_timeStartedLerping = Time.time;

		_startPosition = transform.position;
		_endPosition = new Vector3 (-0.3f, 0.6f,0.18f);
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)) {

          	GameObject[] qu = GameObject.FindGameObjectsWithTag("quad");

            if (qu.Length > 0)
            {
                Destroy(qu[0].gameObject);
            }
			count++;
            
            if (qu.Length <= 0) {
                this.GetComponent<WaterBuoyancy.FloatingObject>().enabled = true;
                this.GetComponent<Rigidbody>().useGravity = true;
                //SceneManager.LoadScene("03_step1");
      

                //enabled = false;
                //StartCoroutine(WaitForIt());
                //Application.LoadLevel("03_step1");
                //StartLerping ();   
            }
            

        }
        
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1000);
        check = true;
    }
    void FixedUpdate()
		{
		if (_isLerping) {
			float timeSinceStarted = Time.time - _timeStartedLerping;
			float percentageComplete = timeSinceStarted / timeTakenDuringLerp;

			transform.position = Vector3.Lerp (_startPosition, _endPosition, percentageComplete);

			if (percentageComplete >= 1.0f) {
				_isLerping = false;
			}

		}

		}
}
