using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class capsuleController : MonoBehaviour //harus sama dengan nama yang ada di script unity. MonoBehavior adalah default dan desclass. fungsi yang akan sering kita gunakan. kita juga bihasa membuat kelas yang lain misalnya player.
{
    //Contoh Deklarasi Variable
    public float speed = 1f;
    public string hello = "hello world"; //petik dua untuk kalimat.
    public GameObject player;
    int score = 0; //private jika tidak dituliskan scoupe variabelnya.
    Vector3 temp;
    Rigidbody rb;

    int[] number = { 1, 2, 3, 4 };

    private float startPosX;
    private float startPosY;
    private bool moving = false;



    // Start is called before the first frame update
    void Start()//dipanggil satu kali saat file unity kita compile
    {
        //Deklarasi variable di c# harus menuliskan apa tipe data dan akses enkapsulasi
        //vector3 adalah mengikuti ruang 3 dimensi
        //if else statement di C#
        if (score <= 0)
        {
            print("Game Over");
        }
        else
        {
            print("Game Running");
        }

        //for loop statement
        for (int i = 0; i < number.Length; i++)
        {
            print(number[i]);
        }

        //fitur unity

        rb.velocity = new Vector3(0, 5, 5);

    }

    // Update is called once per frame
    void Update()// semua perubahan seperti mengubah posisi, skala, dll di dalam game.
    {

        movement();
        rotate();
        scale();


        if (moving)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.localPosition.z);

        }

        float h = Input.GetAxis("Horizontal") * 10f * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * 10f * Time.deltaTime;

    }

    public void FixedUpdate()
    {
   /*     rb.velocity = new Input*/
    }

    void movement()
    {
        //memindahkan objek di sumbu x dan y
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }



    }

    void rotate()
    {
        if (Input.GetKey(KeyCode.Q)) //Rotate ke kanan
        {
            transform.Rotate(0, 0, 15 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R)) //Rotate ke kiri
        {
            transform.Rotate(0, 0, -15 * Time.deltaTime);
        }
    }

    void scale()
    {
        if (Input.GetKey(KeyCode.M)) //cara menskalakan object sedikit berbeda dengan translate dan rotate.
        {
            temp = transform.localScale;
            temp.x += 1f * Time.deltaTime;
            transform.localScale = temp;
        }
        if (Input.GetKey(KeyCode.N)) //cara menskalakan object sedikit berbeda dengan translate dan rotate.
        {
            temp = transform.localScale;
            temp.y += 1f * Time.deltaTime;
            transform.localScale = temp;
        }
        if (Input.GetKey(KeyCode.H)) //cara menskalakan object sedikit berbeda dengan translate dan rotate.
        {
            temp = transform.localScale;
            temp.x -= 1f * Time.deltaTime;
            transform.localScale = temp;
        }
        if (Input.GetKey(KeyCode.J)) //cara menskalakan object sedikit berbeda dengan translate dan rotate.
        {
            temp = transform.localScale;
            temp.y -= 1f * Time.deltaTime;
            transform.localScale = temp;
        }
    }


}
