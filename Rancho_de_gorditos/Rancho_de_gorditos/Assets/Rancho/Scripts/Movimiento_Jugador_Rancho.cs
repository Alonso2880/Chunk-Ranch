using UnityEngine;

public class Movimiento_Jugador_Rancho : MonoBehaviour
{
    public float vel, velRot, velCorrer, velCopia;
    public Animator animator;
    private float cordX, cordZ;
    private Vector3 pos;
    private const float fixedY = 0.002f;
    private GameObject Zona, menuPausa, huertoUI, menuInicial;
    public GameObject Rancho, Bosque;
    public int minijuego =0;
    void Start()
    {
        velCopia = vel;
        // Aseguramos la posición Y inicial
        Vector3 startPos = transform.position;
        startPos.y = fixedY;
        transform.position = startPos;
        Zona = GameObject.Find("ZonasUI");
        menuPausa = GameObject.Find("MenuPausa");
        huertoUI = GameObject.Find("HuertoUI");
        menuInicial = GameObject.Find("MenuInicio");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ZonasUI z = Zona.GetComponent<ZonasUI>();
        HuertoUI h = huertoUI.GetComponent<HuertoUI>();
        MenuInicio m = menuInicial.GetComponent<MenuInicio>();
        if (collision.gameObject == Rancho)
        {
            if (!m.menuIncio)
            {
                z.rancho = false;
            }

            if (!m.menuIncio)
            {
                z.rancho = true;
            }
            
        }

        if (collision.gameObject == Bosque)
        {
            
            if (!m.menuIncio)
            {
                z.bosque = false;
            }

            if (!m.menuIncio)
            {
                z.bosque = true;
            }
        }

        if (collision.gameObject.CompareTag("huerto"))
        {
            h.AbrirUI();
        }

        if (collision.gameObject.CompareTag("Minijuego"))
        {
            minijuego += 1;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        MenuPausaUI m = menuPausa.GetComponent<MenuPausaUI>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            m.c.enabled = true;
            Time.timeScale = 0;
        }

       
        
            cordX = Input.GetAxis("Horizontal");
            cordZ = Input.GetAxis("Vertical");
            pos = new Vector3(cordX, 0, cordZ).normalized;

            if (pos != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(pos);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velRot * Time.deltaTime);
            }

            transform.Translate(pos * vel * Time.deltaTime, Space.World);

            // Aplicamos animaciones de caminar
            animator.SetBool("Andar", pos != Vector3.zero);

            // Gestión de correr
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                vel = velCorrer;
                animator.SetBool("Correr", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                vel = velCopia;
                animator.SetBool("Correr", false);
            }

            // Fijar la posición en Y para evitar deriva
            Vector3 curPos = transform.position;
            curPos.y = fixedY;
            transform.position = curPos;
        
        
    }
}


