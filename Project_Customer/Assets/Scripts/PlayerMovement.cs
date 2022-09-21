using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public float timeLeft = 2f;

    public GameObject pistol;
    
    public AudioSource audioSource;

    public GameObject ammoSwitch;
    private AmmoSwitch _ammoSwitch;

    CharacterController _characterController;
    Vector3 _moveDirection = Vector3.zero;
    float _rotationX;

    [HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public bool hasPistol;
    [HideInInspector]
    public bool gunLoaded = true;
    [HideInInspector]
    public bool npcIsHit;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _ammoSwitch = ammoSwitch.GetComponent<AmmoSwitch>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audioSource.Play();
    }
    private void FixedUpdate()
    {
        int layerMask = 0;
        layerMask = ~layerMask;

        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,
                layerMask, QueryTriggerInteraction.Ignore)) return;
        //Debug.Log(hit.collider.gameObject.tag);
        if (hit.collider.gameObject.CompareTag("NPC") && hasPistol && npcIsHit)
        {
            SceneManager.LoadScene("AimRetryScene");
        }
    }
    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkingSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkingSpeed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = _moveDirection.y;
        _moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
        {
            _moveDirection.y = jumpSpeed;
        }
        else
        {
            _moveDirection.y = movementDirectionY;
        }

        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        _characterController.Move(_moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            _rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (pistol.activeSelf)
        {
            Timer();
            if (timeLeft <= 0)
            {
                hasPistol = true;
            }
        }
        else
        {
            hasPistol = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && gunLoaded && hasPistol)
        {
            if (_ammoSwitch.hasAmmo)
            {
                _ammoSwitch.emptyMagazine.SetActive(true);
            }
            else
            {
                _ammoSwitch.fullMagazine.SetActive(true);
            }
            gunLoaded = false;
            Debug.Log(gunLoaded);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && !gunLoaded && hasPistol)
        {
            if (_ammoSwitch.hasAmmo)
            {
                _ammoSwitch.emptyMagazine.SetActive(false);
            }
            else
            {
                _ammoSwitch.fullMagazine.SetActive(false);
            }
            gunLoaded = true;
            Debug.Log(gunLoaded);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death_Zone"))
        {
            SceneManager.LoadScene("Main_Scene");
        }
    }

    private void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
    }
}
