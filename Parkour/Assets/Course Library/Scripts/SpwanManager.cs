using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    #region 欄位
    //定義用來存取 預製件 Prefab 的遊戲物件
    public GameObject obPrefab;
    
    //定義要生成物件的位置
    public Vector3 spwanPos = new Vector3(30, 0, 0);

    public float starDelay =2;
    public float repeatRate =3;

    private PlayerController playerController;
    #endregion
    void Start()
    {
        InvokeRepeating("SpwanO", starDelay, repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    #region 方法
    void SpwanO()
    {
        if (playerController.gameOver == false)
        {
            //使用 Instantiate 函式，可用來生成其他遊戲物件(通常是預製件 Prefabs)
            Instantiate(obPrefab, spwanPos, obPrefab.transform.rotation);
        }
    }
    #endregion
}
