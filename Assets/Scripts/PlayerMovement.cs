using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float Hspeed = 275f, Vspeed = 20000f, kickForce = 5000f;
    private Rigidbody _rb;

    private bool isJump;

    public Transform player;
    public Transform target;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject exitCamera;
    [SerializeField] private GameObject winCamera;
    [SerializeField] private GameObject winPanel;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * Hspeed * Time.fixedDeltaTime;
        _rb.velocity = transform.TransformDirection(new Vector2(h, _rb.velocity.y));
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "JumpObjects")
            isJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "JumpObjects")
            isJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RBarrier")
             _rb.AddForce(new Vector3(1, 0, 0) * kickForce);
        else if (collision.gameObject.tag == "LBarrier")
             _rb.AddForce(new Vector3(-1, 0, 0) * kickForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SpeedTrigger")
            Hspeed = 550f;
        else if (other.gameObject.name == "EndTrigger")
        {
            mainCamera.SetActive(false);

            winPanel.SetActive(true);
            winCamera.SetActive(true);
        }
        else if (other.gameObject.name == "DeathTrigger")
        {
            player.transform.position = target.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "SpeedTrigger")
            Hspeed = 275f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainCamera.SetActive(false);

            exitPanel.SetActive(true);
            exitCamera.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump == true)
            _rb.AddForce(new Vector2(_rb.velocity.x, 1) * Vspeed * Time.fixedDeltaTime);
    }

    public void Escape()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        mainCamera.SetActive(true);

        exitPanel.SetActive(false);
        exitCamera.SetActive(false);
    }
}
