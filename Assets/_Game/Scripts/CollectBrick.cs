using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrick : MonoBehaviour
{
    // Start is called before the first frame update
    public Stack<GameObject> brickStacks;
    public GameObject brickStack;
    public GameObject brickPrefabs;
    public GameObject nomalBrickPrefabs;
    public float brickHeight = 0.3f;
    private float speed = 0.2f;
    public GameObject winPos;
    public Transform tf;
    public GameObject playerMesh;
    public Animator anim;
    private bool isEndGame = false;

    public GameObject openChest;
    public GameObject closeChest;
   
    void Start()
    {
        brickStacks = new Stack<GameObject>();
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            SetWin();
        }
    }

    public void ChangeHeightModel()
    {
        playerMesh.transform.localPosition = new Vector3(playerMesh.transform.localPosition.x, 0.3f * brickStacks.Count, playerMesh.transform.localPosition.z);
    }

    public void AddBrick()
    {
        GameObject brick = Instantiate(brickPrefabs, brickStack.transform);
        brickStacks.Push(brick);
        brick.transform.localPosition = new Vector3(0, (brickStacks.Count - 1) * brickHeight, 0);
        ChangeHeightModel();
    }

    public void RemoveBrick(GameObject brickPos)
    {
        GameObject brick = brickStacks.Pop();
        brick.transform.position = new Vector3(brickPos.transform.position.x, tf.position.y - brickHeight, brickPos.transform.position.z);
        Instantiate(nomalBrickPrefabs, brickPos.transform);
        Destroy(brick);
        ChangeHeightModel();
    }

    public void SetWin()
    {
        tf.position = Vector3.MoveTowards(tf.position, winPos.transform.position, speed);
        StartCoroutine("OpenChest");
    }

    IEnumerator OpenChest()
    {
        yield return new WaitForSeconds(1.5f);
        openChest.SetActive(true);
        closeChest.SetActive(false);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
            AddBrick();
        }

        if (other.gameObject.CompareTag("RemoveBrick"))
        {
            
            RemoveBrick(other.gameObject);
            other.GetComponent<Collider>().enabled = false;
            //Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("finish");
            //tf.position = Vector3.MoveTowards(tf.position, winPos.transform.position,speed);
            isEndGame = true;
        }
        if (other.gameObject.CompareTag("Win"))
        {
            anim.SetBool("IsWin", true);
            anim.SetBool("IsIdle", false);
        }
    }

}
