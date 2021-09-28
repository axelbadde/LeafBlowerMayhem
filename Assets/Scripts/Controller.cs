using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletDirection;

    private Actions controls;

    private bool canFire = true;

    private Camera main;


    private void Awake() 
    {
        controls = new Actions();
    
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        controls.Player.Fire.performed += _ => PlayerFire();

    }
    private void PlayerFire() 
    {
        if (!canFire) return;
    
    
    
    
        Vector2 mouseposition = controls.Player.MousePosition.ReadValue<Vector2>();
        mouseposition = Camera.main.ScreenToViewportPoint(mouseposition);
        GameObject g = Instantiate(bullet, bulletDirection.position, bulletDirection.rotation);
        g.SetActive(true);
        StartCoroutine(CanFire());
    }

    
    IEnumerator CanFire() 
    {

        canFire = false;
        yield return new WaitForSeconds(.1f);
        canFire = true; 
    
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 mouseScreenPosition = controls.Player.MousePosition.ReadValue<Vector2>();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 targetDirection = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        

        
    }
}
