using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 欄位
    private Rigidbody playerRb;
    public float jumpForce;  //跳躍力道
    public float gravityModifier; //系統物理重力
    
    public bool isOnground = true; //是否站在地板上
    public bool gameOver = false;
    private Animator playAn;

    public ParticleSystem ps_ex;
    public ParticleSystem ps_dirty;

    public AudioClip ac_jump;
    public AudioClip ac_ex;
    private AudioSource as_player;
    #endregion
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; // 等同 Physics.gravity * Physics.gravity = gravityModifier
        playAn = GetComponent<Animator>();
        as_player = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Jump();
  
    }

    //若與地板有接觸(Enter)，則設為 true
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnground = true; //表示在地板上(避免二段跳)
            ps_dirty.Play();
        } else if (other.gameObject.CompareTag("OOO"))
        {
            gameOver = true; //因為碰撞到障礙物，表示遊戲結束
            print("遊戲結束！");  //在 #Console 視窗顯示 "遊戲結束"
            playAn.SetBool("Death_b", true);
            playAn.SetInteger("DethType_int", 1);
            ps_ex.Play();
            ps_dirty.Stop();
            as_player.PlayOneShot(ac_ex, 1.0f);
        } 
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnground)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnground = false;
            playAn.SetTrigger("Jump_trig");
            ps_dirty.Stop();
            as_player.PlayOneShot(ac_jump, 1.0f);
        }
        if (!isOnground)
        {
            playAn.SetBool("Lean_b", true);
            ps_dirty.Stop();
        }
        else playAn.SetBool("Lean_b", false);
    }

}
