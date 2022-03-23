using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    #region Дж¦м
    public float speed =20;
    private PlayerController playerController;

    public float leftBound = -15;
    #endregion
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (gameObject.transform.position.x < leftBound && gameObject.CompareTag("OOO"))
        {
            Destroy(gameObject);
            print("Delete GameObject.");
        }
    }
}
