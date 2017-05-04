using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {
	private int waveNumber;
	public float distanceX, distanceZ;
	public float[] waveAmplitude;
	public float magnitudeDivider;
    public GameObject Bullet;
    public GameObject BulletPosition;
	//public Vector2[] impactPos;
	//public float[] distance;
	//public float speedWaveSpread;

	Mesh mesh;
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshFilter>().mesh;
	}
	
	// Update is called once per frame
	void Update () {
        KeyProc();

		for (int i=0; i<8; i++){

			waveAmplitude[i] = GetComponent<Renderer>().material.GetFloat("_WaveAmplitude" + (i+1));
			if (waveAmplitude[i] > 0)

			{
				//distance[i] += speedWaveSpread;
				//GetComponent<Renderer>().material.SetFloat("_Distance" + (i+1), distance[i]);
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i+1), waveAmplitude[i] * 0.98f);
			}
			if (waveAmplitude[i] < 0.05)
			{
				GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + (i+1), 0);
				//distance[i] = 0;
			}

		}
	}

    void KeyProc()
    {
        float Hori = Input.GetAxisRaw("Horizontal");
        float Verti = Input.GetAxisRaw("Vertical");

        /*Vector3 Dir = new Vector3(DPoint.position.x - this.transform.position.x, 0, DPoint.position.z - this.transform.position.z);
        Vector3 BulletDir = new Vector3(Tank_Head.transform.position.x - CameraPoint.position.x, 0, Tank_Head.transform.position.z - CameraPoint.position.z);
        BulletDir.Normalize();
        BulletDir.Scale(new Vector3(100, 100, 100));
        */
        if (Input.GetMouseButton(0))
        {
			//GameObject bullet = (GameObject)Instantiate(Bullet, BulletPosition.transform.position, Quaternion.identity);
   			//GameObject.Destroy(bullet);
            //bullet.GetComponent<Rigidbody>().velocity = BulletDir;
        }
        /*
        Dir.Scale(new Vector3(Verti, Verti, Verti));
        this.gameObject.GetComponent<Rigidbody>().velocity = Dir;

        if (Verti != 0)
        {
            this.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, Hori, 0);
        }
        float DeltaX;
        DeltaX = Input.mousePosition.x - Xmouse.x;

        if (Input.mousePosition.x == 0)
        {
            DeltaX = -5;
        }
        else if (Input.mousePosition.x == Screen.width)
        {
            DeltaX = +5;
        }
        Tank_Head.transform.rotation = Quaternion.Euler(0, ((DeltaX * 0.1f) + Tank_Head.transform.rotation.eulerAngles.y), 0);
        Xmouse = Input.mousePosition;*/
    }

	void OnCollisionEnter(Collision col){
		if (col.rigidbody)
		{
			waveNumber++;
			if (waveNumber == 9){
				waveNumber = 1;
			}
			waveAmplitude[waveNumber-1] = 0;
			//distance[waveNumber-1] = 0;

			distanceX = this.transform.position.x - col.gameObject.transform.position.x;
			distanceZ = this.transform.position.z - col.gameObject.transform.position.z;
			//impactPos[waveNumber - 1].x = col.transform.position.x;
			//impactPos[waveNumber - 1].y = col.transform.position.z;

			//GetComponent<Renderer>().material.SetFloat("_xImpact" + waveNumber, col.transform.position.x);
			//GetComponent<Renderer>().material.SetFloat("_zImpact" + waveNumber, col.transform.position.z);

			GetComponent<Renderer>().material.SetFloat("_OffsetX" + waveNumber, distanceX / mesh.bounds.size.x * 2.5f);
			GetComponent<Renderer>().material.SetFloat("_OffsetZ" + waveNumber, distanceZ / mesh.bounds.size.z * 2.5f);

			GetComponent<Renderer>().material.SetFloat("_WaveAmplitude" + waveNumber, col.rigidbody.velocity.magnitude * magnitudeDivider);

		}
	}
}
